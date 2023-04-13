using TechConf.Data;
using TechConf.Models.Models;

namespace TechConf.Repositories.Contracts
{
    public interface ISpeakerRepository : IBaseRepository
    {
        public Task<List<Speaker>> GetAllAsync(int pageNo, int pageSize);
        public Task<Speaker?> GetByIdAsync(int id);
        public Task<Speaker> AddAsync(Speaker speaker);
        public Task<bool> EditAsync(int id, Speaker speaker);
        public void DeleteAsync(Speaker speaker);
    }
}
