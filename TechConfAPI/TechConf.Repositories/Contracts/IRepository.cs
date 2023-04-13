using TechConf.Data;

namespace TechConf.Repositories.Contracts
{
    public interface IRepository<ServiceModel> : IBaseRepository where ServiceModel : class
    {
        public Task<List<ServiceModel>> GetAllAsync(int pageNo, int pageSize);
        public Task<ServiceModel?> GetByIdAsync(int id);
        public Task<ServiceModel> AddAsync(ServiceModel model);
        public Task<bool> EditAsync(int id, ServiceModel model);
        public void DeleteAsync(ServiceModel model);
    }
}
