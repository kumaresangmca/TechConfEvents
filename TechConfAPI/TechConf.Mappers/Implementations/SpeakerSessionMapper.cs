using TechConf.Mappers.Contracts;
using TechConf.Models.DTO;
using TechConf.Models.Models;

namespace TechConf.Mappers.Implementations
{
    public class SpeakerSessionMapper : IMapper<SpeakerSession, SpeakerSessionDTO>
    {
        public SpeakerSession MapDTOModelToServiceModel(SpeakerSessionDTO dataDTO)
        {
            return new SpeakerSession
            {
                Id = dataDTO.Id,
                Name = dataDTO.Name,
                EventId = dataDTO.EventId,
                StartTime = dataDTO.StartTime,
                EndTime = dataDTO.EndTime
            };
        }

        public SpeakerSessionDTO ModelServiceModelToDTOModel(SpeakerSession data)
        {
            return new SpeakerSessionDTO
            {
                Id = data.Id,
                Name = data.Name,
                EventId = data.EventId,
                StartTime = data.StartTime,
                EndTime = data.EndTime
            };
        }
    }
}
