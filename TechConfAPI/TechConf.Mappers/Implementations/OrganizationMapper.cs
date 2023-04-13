using System.Reflection;
using TechConf.Mappers.Contracts;
using TechConf.Models.DTO;
using TechConf.Models.Models;

namespace TechConf.Mappers.Implementations
{
    public class OrganizationMapper : IMapper<Organization, OrganizationDTO>
    {
        public Organization MapDTOModelToServiceModel(OrganizationDTO modelDTO)
        {
            return new Organization
            {
                Id = modelDTO.Id,
                Name = modelDTO.Name,
                ApiKey = modelDTO.ApiKey,
                Code = modelDTO.Code
            };
        }

        public OrganizationDTO ModelServiceModelToDTOModel(Organization model)
        {
            return new OrganizationDTO
            {
                Id = model.Id,
                Name = model.Name,
                ApiKey = model.ApiKey,
                Code = model.Code
            };
        }
    }
}
