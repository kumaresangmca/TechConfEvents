using TechConf.Models.DTO;
using TechConf.Models.Models;

namespace TechConf.Mappers.Contracts
{
    public interface IOrganizationMapper
    {
        public Organization MapToOrganization(OrganizationDTO organizationDTO);
        public OrganizationDTO MapToOrganizationDTO(Organization organization);
    }
}
