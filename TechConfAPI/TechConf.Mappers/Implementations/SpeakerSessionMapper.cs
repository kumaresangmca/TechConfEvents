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
                EventId = dataDTO.EventId,
                SpeakerId = dataDTO.SpeakerId,
                StartTime = dataDTO.StartTime,
                EndTime = dataDTO.EndTime
            };
        }

        public SpeakerSessionDTO ModelServiceModelToDTOModel(SpeakerSession data)
        {
            return new SpeakerSessionDTO
            {
                Id = data.Id,
                EventId = data.EventId,
                SpeakerId = data.SpeakerId,
                StartTime = data.StartTime,
                EndTime = data.EndTime
            };
        }
    }
}
