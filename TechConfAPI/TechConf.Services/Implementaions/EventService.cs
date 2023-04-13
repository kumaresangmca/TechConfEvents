using TechConf.Mappers.Contracts;
using TechConf.Models.DTO;
using TechConf.Models.Models;
using TechConf.Repositories.Contracts;
using TechConf.Services.Contracts;

namespace TechConf.Services.Implementaions
{
    public class EventService : IService<EventDTO>
    {
        private readonly IRepository<Event> repository;
        private readonly IMapper<Event, EventDTO> mapper;

        public EventService(IRepository<Event> repository,
                                   IMapper<Event, EventDTO> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<List<EventDTO>> GetAllAsync(int pageNo, int pageSize)
        {
            List<EventDTO> EventDTOs = new List<EventDTO>();
            var result = await repository.GetAllAsync(pageNo, pageSize);
            EventDTOs = result.Select(o => mapper.ModelServiceModelToDTOModel(o)).ToList();
            return EventDTOs;
        }
        public async Task<EventDTO?> GetByIdAsync(int id)
        {
            var eventData = await repository.GetByIdAsync(id);
            if (eventData == null)
            {
                return null;
            }
            return mapper.ModelServiceModelToDTOModel(eventData);
        }
        public async Task<EventDTO> AddAsync(EventDTO model)
        {
            var eventEntity = mapper.MapDTOModelToServiceModel(model);
            eventEntity.CreatedDate = DateTime.Now;
            var createdRecord = await repository.AddAsync(eventEntity);
            SaveChangesAsync();
            return mapper.ModelServiceModelToDTOModel(createdRecord);
        }
        public async Task<bool> EditAsync(int id, EventDTO model)
        {
            var eventEntity = mapper.MapDTOModelToServiceModel(model);
            eventEntity.UpdatedDate = DateTime.Now;
            var isEdited = await repository.EditAsync(id, eventEntity);
            SaveChangesAsync();
            return isEdited;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var eventEntity = await repository.GetByIdAsync(id);
            if (eventEntity == null)
            {
                return false;
            }
            repository.DeleteAsync(eventEntity);
            SaveChangesAsync();
            return true;
        }
        public void SaveChangesAsync()
        {
            repository.SaveChangesAsync();
        }
    }
}
