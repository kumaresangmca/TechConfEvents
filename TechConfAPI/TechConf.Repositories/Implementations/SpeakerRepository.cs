using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TechConf.Common.Constant;
using TechConf.Data;
using TechConf.Models.Models;
using TechConf.Repositories.Contracts;

namespace TechConf.Repositories.Implementations
{
    public class SpeakerRepository : BaseRepository, IRepository<Speaker>
    {
        private readonly TechConfDbContext dbContext;
        private readonly int organizatioId;

        public SpeakerRepository(TechConfDbContext dbContext,
                               IHttpContextAccessor context,
                               IOptions<APIKeyOptions> options) : base(dbContext)
        {
            this.dbContext = dbContext;
            int.TryParse(context.HttpContext.Request.Headers["OrganizationId"], out organizatioId);
        }

        // Get All Speaker
        public async Task<List<Speaker>> GetAllAsync(int pageNo, int pageSize)
        {
            return await dbContext.Speakers.Where(s=> s.OrganizationId == organizatioId).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        // Get Speaker By Id
        public async Task<Speaker?> GetByIdAsync(int id)
        {
            return await dbContext.Speakers.FirstOrDefaultAsync(s => s.OrganizationId == organizatioId && s.Id == id);
        }

        // Add Speaker
        public async Task<Speaker> AddAsync(Speaker model)
        {
            model.OrganizationId = organizatioId;
            await dbContext.Speakers.AddAsync(model);
            return model;
        }

        // Update Existing Speaker
        public async Task<bool> EditAsync(int id, Speaker model)
        {
            Speaker? existingSpeaker = await dbContext.Speakers.FirstOrDefaultAsync(s => s.OrganizationId == organizatioId && s.Id == id);
            if (existingSpeaker == null)
            {
                return false;
            }
            else
            {
                dbContext.Entry(existingSpeaker).State = EntityState.Detached;
            }
            model.OrganizationId = organizatioId;
            model.CreatedDate = existingSpeaker.CreatedDate;
            dbContext.Attach(model);
            dbContext.Entry(model).State = EntityState.Modified;
            return true;
        }

        // Delete Speaker
        public void DeleteAsync(Speaker model)
        {
            dbContext.Speakers.Remove(model);
        }

    }
}
