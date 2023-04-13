using Microsoft.EntityFrameworkCore;
using TechConf.Data;
using TechConf.Models.Models;
using TechConf.Repositories.Contracts;

namespace TechConf.Repositories.Implementaions
{
    public class SpeakerRepository : BaseRepository, IRepository<Speaker>
    {
        private readonly TechConfDbContext dbContext;
        public SpeakerRepository(TechConfDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        
        // Get All Speaker
        public async Task<List<Speaker>> GetAllAsync(int pageNo, int pageSize)
        {
            return await dbContext.Speakers.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        // Get Speaker By Id
        public async Task<Speaker?> GetByIdAsync(int id)
        {
            return await dbContext.Speakers.FirstOrDefaultAsync(s => s.Id == id);
        }

        // Add Speaker
        public async Task<Speaker> AddAsync(Speaker model)
        {
            await dbContext.Speakers.AddAsync(model);
            return model;
        }

        // Update Existing Speaker
        public async Task<bool> EditAsync(int id, Speaker model)
        {
            Speaker? existingSpeaker = await dbContext.Speakers.FirstOrDefaultAsync(s => s.Id == id);
            if (existingSpeaker == null)
            {
                return false;
            }
            else
            {
                dbContext.Entry(existingSpeaker).State = EntityState.Detached;
            }
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
