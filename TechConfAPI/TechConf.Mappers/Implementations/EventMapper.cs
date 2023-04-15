using TechConf.Mappers.Contracts;
using TechConf.Models.DTO;
using TechConf.Models.Models;

namespace TechConf.Mappers.Implementations
{
    public class EventMapper : IMapper<Event, EventDTO>
    {
        private readonly IMapper<Speaker, SpeakerDTO> speakerMapper;
        private readonly IMapper<SpeakerSession, SpeakerSessionDTO> sessionMapper;
        public EventMapper(IMapper<Speaker, SpeakerDTO> speakerMapper,
            IMapper<SpeakerSession, SpeakerSessionDTO> sessionMapper)
        {
            this.speakerMapper = speakerMapper;
            this.sessionMapper = sessionMapper;
        }
        public Event MapDTOModelToServiceModel(EventDTO dataDTO)
        {
            return new Event
            {
                Id = dataDTO.Id,
                Title = dataDTO.Title,
                Description = dataDTO.Description,
                EventDate = dataDTO.EventDate,
                SpeakerId = dataDTO.SpeakerId,
                Venu = dataDTO.Venu,
                Website = dataDTO.Website,
                LinkForDetails = dataDTO.LinkForDetails,
                OrganizationId = dataDTO.OrganizationId,
                Type = dataDTO.Type
            };
        }

        public EventDTO ModelServiceModelToDTOModel(Event data)
        {
            var eventDTO =new EventDTO
            {
                Id = data.Id,
                Title = data.Title,
                Description = data.Description,
                EventDate = data.EventDate,
                SpeakerId = data.SpeakerId,
                Venu = data.Venu,
                Website = data.Website,
                LinkForDetails = data.LinkForDetails,
                OrganizationId = data.OrganizationId,
                Type = data.Type
            };
            if (data.Speaker != null)
            {
                eventDTO.speaker = speakerMapper.ModelServiceModelToDTOModel(data.Speaker);
            }
            if (data.Sessions != null && data.Sessions.Any())
            {
                foreach (var session in data.Sessions)
                {
                    eventDTO.Sessions.Add(sessionMapper.ModelServiceModelToDTOModel(session));
                }
            }
            return eventDTO;
        }
    }
}
