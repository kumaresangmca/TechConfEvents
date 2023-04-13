using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechConf.Data;
using TechConf.Models.Models;

namespace TechConf.Repositories.Contracts
{
    public interface ISpeakerSessionRepository : IBaseRepository
    {
        public Task<List<SpeakerSession>> GetAllAsync(int pageNo, int pageSize);
        public Task<SpeakerSession?> GetByIdAsync(int id);
        public Task<SpeakerSession> AddAsync(SpeakerSession speakerSession);
        public Task<bool> EditAsync(int id, SpeakerSession speakerSession);
        public void DeleteAsync(SpeakerSession speakerSession);
    }
}
