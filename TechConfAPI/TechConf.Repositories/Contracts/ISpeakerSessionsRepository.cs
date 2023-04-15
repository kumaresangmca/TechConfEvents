using TechConf.Models.Models;

namespace TechConf.Repositories.Contracts
{
    public interface ISpeakerSessionsRepository<ServiceModel> : IRepository<ServiceModel> where ServiceModel : class
    {
        public Task<List<ServiceModel>> GetAllByEventIdAsync(int eventId, int pageNo, int pageSize);
        public Task<ServiceModel?> GetByEventAndSessionIdAsync(int eventId, int id);

    }
}
