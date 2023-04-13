namespace TechConf.Repositories.Contracts
{
    public interface IOrganizationRepository<ServiceModel> : IRepository<ServiceModel> where ServiceModel : class
    {
        public Task<string?> GetAPIKeyByCodeAsync(string code);

    }
}
