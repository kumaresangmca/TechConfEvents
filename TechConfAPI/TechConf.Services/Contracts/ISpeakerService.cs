using TechConf.Models.DTO;
using TechConf.Models.Models;

namespace TechConf.Services.Contracts
{
    public interface ISpeakerService
    {
        public Task<List<SpeakerDTO>> GetAllAsync(int pageNo, int pageSize);
        public Task<SpeakerDTO?> GetByIdAsync(int id);
        public Task<SpeakerDTO> AddAsync(SpeakerDTO speaker);
        public Task<bool> EditAsync(int id, SpeakerDTO speaker);
        public void DeleteAsync(SpeakerDTO speaker);
        public void SaveChangesAsync();
    }
}
