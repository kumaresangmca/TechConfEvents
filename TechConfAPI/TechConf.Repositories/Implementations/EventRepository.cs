using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TechConf.Common.Constant;
using TechConf.Data;
using TechConf.Models.Models;
using TechConf.Repositories.Contracts;

namespace TechConf.Repositories.Implementations
{
    public class EventRepository : BaseRepository, IEventsRepository<Event>
    {
        private readonly TechConfDbContext dbContext;
        private readonly int organizatioId;
        public EventRepository(TechConfDbContext dbContext,
                               IHttpContextAccessor context) : base(dbContext)
        {
            this.dbContext = dbContext;
            int.TryParse(context.HttpContext.Request.Headers["OrganizationId"], out organizatioId);
        }

        // Get All Events
        public async Task<List<Event>> GetAllAsync(int pageNo, int pageSize)
        {
            return await dbContext.Events.Include(e => e.Speaker).Where(e => e.OrganizationId == organizatioId).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        // Get Events By Id
        public async Task<Event?> GetByIdAsync(int id)
        {
            return await dbContext.Events.FirstOrDefaultAsync(e => e.OrganizationId == organizatioId && e.Id == id);
        }

        // Add Event
        public async Task<Event> AddAsync(Event model)
        {
            model.OrganizationId = organizatioId;
            await dbContext.Events.AddAsync(model);
            return model;
        }

        // Update Existing Event
        public async Task<bool> EditAsync(int id, Event model)
        {
            Event? existingEvent = await dbContext.Events.FirstOrDefaultAsync(e => e.OrganizationId == organizatioId && e.Id == id);
            if (existingEvent == null)
            {
                return false;
            }
            else
            {
                dbContext.Entry(existingEvent).State = EntityState.Detached;
            }
            model.OrganizationId = organizatioId;
            dbContext.Attach(model);
            dbContext.Entry(model).State = EntityState.Modified;
            return true;
        }

        // Delete Event
        public void DeleteAsync(Event model)
        {
            dbContext.Events.Remove(model);
        }

        //Download Events
        public async Task<Event?> DownloadEventByIdAsync(int id)
        {
          return await dbContext.Events.Include(e => e.Speaker).Include(e => e.Sessions).FirstOrDefaultAsync(e => e.Id == id);
        }


    }
}
