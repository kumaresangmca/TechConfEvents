using TechConf.Mappers.Contracts;
using TechConf.Models.DTO;
using TechConf.Models.Models;
using TechConf.Repositories.Contracts;
using TechConf.Services.Contracts;

namespace TechConf.Services.Implementations
{
    public class OrganizationService : IOrganizationService<OrganizationDTO>
    {
        private readonly IOrganizationRepository<Organization> repository;
        private readonly IMapper<Organization, OrganizationDTO> mapper;

        public OrganizationService(IOrganizationRepository<Organization> repository,
                                   IMapper<Organization, OrganizationDTO> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        // Get All Organization
        public async Task<List<OrganizationDTO>> GetAllAsync(int pageNo, int pageSize)
        {
            List<OrganizationDTO> organizationDTOs = new List<OrganizationDTO>();
            var result = await repository.GetAllAsync(pageNo, pageSize);
            organizationDTOs = result.Select(o => mapper.ModelServiceModelToDTOModel(o)).ToList();
            return organizationDTOs;
        }

        public async Task<string?> GetAPIKeyByCodeAsync(string code)
        {
            var apiKey = await repository.GetAPIKeyByCodeAsync(code);          
            return apiKey;
        }

        public async Task<OrganizationDTO?> GetByIdAsync(int id)
        {
            var organization = await repository.GetByIdAsync(id);
            if(organization == null)
            {
                return null;
            }
            return mapper.ModelServiceModelToDTOModel(organization);
            
        }
        public Task<OrganizationDTO> AddAsync(OrganizationDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(int id, OrganizationDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }


        public void SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
