using Microsoft.EntityFrameworkCore;
using TechConf.Data;
using TechConf.Models.Models;
using TechConf.Repositories.Contracts;

namespace TechConf.Repositories.Implementaions
{
    public class SpeakerSessionRepository : BaseRepository, IRepository<SpeakerSession>
    {
        private readonly TechConfDbContext dbContext;
        public SpeakerSessionRepository(TechConfDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        
        // Get All Speaker Session
        public async Task<List<SpeakerSession>> GetAllAsync(int pageNo, int pageSize)
        {
            return await dbContext.SpeakerSessions.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        // Get Speaker Session By Id
        public async Task<SpeakerSession?> GetByIdAsync(int id)
        {
            return await dbContext.SpeakerSessions.FirstOrDefaultAsync(s => s.Id == id);
        }

        // Add Speaker Session
        public async Task<SpeakerSession> AddAsync(SpeakerSession model)
        {
            await dbContext.SpeakerSessions.AddAsync(model);
            return model;
        }

        // Update Existing Speaker Session
        public async Task<bool> EditAsync(int id, SpeakerSession model)
        {
            SpeakerSession? existingSpeakerSession = await dbContext.SpeakerSessions.FirstOrDefaultAsync(s => s.Id == id);
            if (existingSpeakerSession == null)
            {
                return false;
            }
            else
            {
                dbContext.Entry(existingSpeakerSession).State = EntityState.Detached;
            }
            dbContext.Attach(model);
            dbContext.Entry(model).State = EntityState.Modified;
            return true;
        }
       
        // Delete Speaker Session
        public void DeleteAsync(SpeakerSession model)
        {
            dbContext.SpeakerSessions.Remove(model);
        }       
       
    }
}
