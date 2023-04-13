using TechConf.Data;
using TechConf.Models.Models;

namespace TechConf.Repositories.Contracts
{
    public interface IEventRepository : IBaseRepository
    {
        public Task<List<Event>> GetAllAsync(int pageNo, int pageSize);
        public Task<Event?> GetByIdAsync(int id);
        public Task<Event> AddAsync(Event newEvent);
        public Task<bool> EditAsync(int id, Event editEvent);
        public void DeleteAsync(Event deleteEvent);
    }
}
