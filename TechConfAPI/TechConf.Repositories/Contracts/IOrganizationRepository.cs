using TechConf.Models.Models;

namespace TechConf.Repositories.Contracts
{
    public interface IOrganizationRepository<ServiceModel> : IRepository<ServiceModel> where ServiceModel : class
    {
        public Task<Organization?> GetByCodeAsync(string code);
        public Task<Organization?> GetByApiKeyAsync(string apiKey);

    }
}
