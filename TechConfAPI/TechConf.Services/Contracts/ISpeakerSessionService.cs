namespace TechConf.Services.Contracts
{
    public interface ISpeakerSessionService<DTOModel> : IService<DTOModel> where DTOModel : class
    {
        public Task<List<DTOModel>> GetAllByEventIdAsync(int eventId, int pageNo, int pageSize);
        public Task<DTOModel?> GetByEventAndSessionIdAsync(int eventId, int id);
    }
}
