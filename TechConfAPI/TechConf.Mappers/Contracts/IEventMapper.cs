using TechConf.Models.DTO;
using TechConf.Models.Models;

namespace TechConf.Mappers.Contracts
{
    public interface IEventMapper
    {
        public Event MapToEvent(OrganizationDTO eventDTO);
        public OrganizationDTO MapToEventDTO(Event @event);
    }
}
