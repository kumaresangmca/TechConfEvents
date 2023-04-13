using TechConf.Models.DTO;

namespace TechConf.Services.Contracts
{
    public interface IEventService
    {
        public Task<List<OrganizationDTO>> GetAllAsync(int pageNo, int pageSize);
        public Task<OrganizationDTO?> GetByIdAsync(int id);
        public Task<OrganizationDTO> AddAsync(OrganizationDTO newEvent);
        public Task<bool> EditAsync(int id, OrganizationDTO editEvent);
        public void DeleteAsync(OrganizationDTO deleteEvent);
        public void SaveChangesAsync();
    }
}
