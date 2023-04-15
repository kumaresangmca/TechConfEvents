using Microsoft.Extensions.Logging;
using TechConf.Mappers.Contracts;
using TechConf.Models.DTO;
using TechConf.Models.Models;
using TechConf.Repositories.Contracts;
using TechConf.Services.Contracts;

namespace TechConf.Services.Implementations
{
    public class SpeakerSessionService : ISpeakerSessionService<SpeakerSessionDTO>
    {
        private readonly ISpeakerSessionsRepository<SpeakerSession> repository;
        private readonly IMapper<SpeakerSession, SpeakerSessionDTO> mapper;

        public SpeakerSessionService(ISpeakerSessionsRepository<SpeakerSession> repository,
                                   IMapper<SpeakerSession, SpeakerSessionDTO> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<List<SpeakerSessionDTO>> GetAllAsync(int pageNo, int pageSize)
        {
            List<SpeakerSessionDTO> SpeakerSessionDTOs = new List<SpeakerSessionDTO>();
            var result = await repository.GetAllAsync(pageNo, pageSize);
            SpeakerSessionDTOs = result.Select(o => mapper.ModelServiceModelToDTOModel(o)).ToList();
            return SpeakerSessionDTOs;
        }
        public async Task<List<SpeakerSessionDTO>> GetAllByEventIdAsync(int eventId,int pageNo, int pageSize)
        {
            List<SpeakerSessionDTO> SpeakerSessionDTOs = new List<SpeakerSessionDTO>();
            var result = await repository.GetAllByEventIdAsync(eventId, pageNo, pageSize);
            SpeakerSessionDTOs = result.Select(o => mapper.ModelServiceModelToDTOModel(o)).ToList();
            return SpeakerSessionDTOs;
        }
        public async Task<SpeakerSessionDTO?> GetByIdAsync(int id)
        {
            var speaker = await repository.GetByIdAsync(id);
            if (speaker == null)
            {
                return null;
            }
            return mapper.ModelServiceModelToDTOModel(speaker);
        }
        public async Task<SpeakerSessionDTO?> GetByEventAndSessionIdAsync(int eventId, int id)
        {
            var speaker = await repository.GetByEventAndSessionIdAsync(eventId, id);
            if (speaker == null)
            {
                return null;
            }
            return mapper.ModelServiceModelToDTOModel(speaker);
        }
        public async Task<SpeakerSessionDTO> AddAsync(SpeakerSessionDTO model)
        {
            var speaker = mapper.MapDTOModelToServiceModel(model);
            speaker.CreatedDate = DateTime.Now;
            var createdRecord = await repository.AddAsync(speaker);
            SaveChangesAsync();
            return mapper.ModelServiceModelToDTOModel(createdRecord);
        }
        public async Task<bool> EditAsync(int id, SpeakerSessionDTO model)
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
