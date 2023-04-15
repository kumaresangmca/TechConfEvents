using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using TechConf.Common.Constant;
using TechConf.Mappers.Contracts;
using TechConf.Models.DTO;
using TechConf.Models.Models;
using TechConf.Repositories.Contracts;
using TechConf.Services.Contracts;

namespace TechConf.Services.Implementations
{
    public class SpeakerService : IService<SpeakerDTO>
    {
        private readonly IRepository<Speaker> repository;
        private readonly IMapper<Speaker, SpeakerDTO> mapper;

        public SpeakerService(IRepository<Speaker> repository,
                              IMapper<Speaker, SpeakerDTO> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<List<SpeakerDTO>> GetAllAsync(int pageNo, int pageSize)
        {
            List<SpeakerDTO> speakerDTOs = new List<SpeakerDTO>();
            var result = await repository.GetAllAsync(pageNo, pageSize);
            speakerDTOs = result.Select(o => mapper.ModelServiceModelToDTOModel(o)).ToList();
            return speakerDTOs;
        }
        public async Task<SpeakerDTO?> GetByIdAsync(int id)
        {
            var speaker = await repository.GetByIdAsync(id);
            if (speaker == null)
            {
                return null;
            }
            return mapper.ModelServiceModelToDTOModel(speaker);
        }
        public async Task<SpeakerDTO> AddAsync(SpeakerDTO model)
        {
            var speaker = mapper.MapDTOModelToServiceModel(model);
            speaker.CreatedDate = DateTime.Now;
            var createdRecord = await repository.AddAsync(speaker);
            SaveChangesAsync();
            return mapper.ModelServiceModelToDTOModel(createdRecord);
        }
        public async Task<bool> EditAsync(int id, SpeakerDTO model)
        {
            var speaker = mapper.MapDTOModelToServiceModel(model);
            speaker.UpdatedDate = DateTime.Now;
            var isEdited = await repository.EditAsync(id, speaker);
            SaveChangesAsync();
            return isEdited;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var speaker = await repository.GetByIdAsync(id);
            if (speaker == null)
            {
                return false;
            }
            repository.DeleteAsync(speaker);
            SaveChangesAsync();
            return true;
        }
        public void SaveChangesAsync()
        {
            repository.SaveChangesAsync();
        }
    }

}
