using TechConf.Models.DTO;
using TechConf.Models.Models;

namespace TechConf.Mappers.Contracts
{
    public interface ISpeakerSessionMapper
    {
        public SpeakerSession MapToSpeakerSession(SpeakerSessionDTO speakerSessionDTO);
        public SpeakerSessionDTO MapToSpeakerSessionDTO(SpeakerSession speaker);
    }
}
