using Microsoft.EntityFrameworkCore;
using TechConf.Data;
using TechConf.Models.Models;
using TechConf.Repositories.Contracts;

namespace TechConf.Repositories.Implementations
{
    public class EventRepository : BaseRepository, IRepository<Event>
    {
        private readonly TechConfDbContext dbContext;
        public EventRepository(TechConfDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        
        // Get All Events
        public async Task<List<Event>> GetAllAsync(int pageNo, int pageSize)
        {
            return await dbContext.Events.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        // Get Events By Id
        public async Task<Event?> GetByIdAsync(int id)
        {
            return await dbContext.Events.FirstOrDefaultAsync(s => s.Id == id);
        }

        // Add Event
        public async Task<Event> AddAsync(Event model)
        {
            await dbContext.Events.AddAsync(model);
            return model;
        }

        // Update Existing Event
        public async Task<bool> EditAsync(int id, Event model)
        {
            Event? existingEvent = await dbContext.Events.FirstOrDefaultAsync(s => s.Id == id);
            if (existingEvent == null)
            {
                return false;
            }
            else
            {
                dbContext.Entry(existingEvent).State = EntityState.Detached;
            }
            dbContext.Attach(model);
            dbContext.Entry(model).State = EntityState.Modified;
            return true;
        }
       
        // Delete Event
        public void DeleteAsync(Event model)
        {
            dbContext.Events.Remove(model);
        }       
       
    }
}
