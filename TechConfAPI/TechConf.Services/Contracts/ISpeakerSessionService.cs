using TechConf.Models.DTO;
using TechConf.Models.Models;

namespace TechConf.Services.Contracts
{
    public interface ISpeakerSessionService
    {
        public Task<List<SpeakerSessionDTO>> GetAllAsync(int pageNo, int pageSize);
        public Task<SpeakerSessionDTO?> GetByIdAsync(int id);
        public Task<SpeakerSessionDTO> AddAsync(SpeakerSessionDTO speakerSession);
        public Task<bool> EditAsync(int id, SpeakerSessionDTO speakerSession);
        public void DeleteAsync(SpeakerSessionDTO speakerSession);
        public void SaveChangesAsync();
    }
}
