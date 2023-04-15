using TechConf.Models.DTO;

namespace TechConf.Services.Contracts
{
    public interface IEventService<DTOModel> : IService<DTOModel> where DTOModel : class
    {
        public Task<DTOModel?> DownloadEventByIdAsync(int id);
    }
}
