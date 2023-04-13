using TechConf.Mappers.Contracts;
using TechConf.Models.DTO;
using TechConf.Models.Models;

namespace TechConf.Mappers.Implementations
{
    public class SpeakerMapper : IMapper<Speaker, SpeakerDTO>
    {
        public Speaker MapDTOModelToServiceModel(SpeakerDTO dataDTO)
        {
            return new Speaker
            {
                 Id = dataDTO.Id,
                 Name = dataDTO.Name,
                 Bio = dataDTO.Bio,
                 Email = dataDTO.Email,
                 SocialLinks = dataDTO.SocialLinks                 
            };
        }

        public SpeakerDTO ModelServiceModelToDTOModel(Speaker data)
        {
            return new SpeakerDTO
            {
                Id = data.Id,
                Name = data.Name,
                Bio = data.Bio,
                Email = data.Email,
                SocialLinks = data.SocialLinks
            };
        }
    }
}
