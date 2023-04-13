using TechConf.Models.DTO;
using TechConf.Models.Models;

namespace TechConf.Mappers.Contracts
{
    public interface ISpeakerMapper
    {
        public Speaker MapToSpeaker(SpeakerDTO speakerDTO);
        public SpeakerDTO MapToSpeakerDTO(Speaker speaker);
    }
}
