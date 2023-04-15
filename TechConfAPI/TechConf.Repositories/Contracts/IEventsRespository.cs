using TechConf.Models.Models;

namespace TechConf.Repositories.Contracts
{
    public interface IEventsRepository<ServiceModel> : IRepository<ServiceModel> where ServiceModel : class
    {
       public Task<ServiceModel?> DownloadEventByIdAsync(int id);

    }
}
