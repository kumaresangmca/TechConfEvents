using TechConf.Mappers.Contracts;
using TechConf.Mappers.Implementations;
using TechConf.Models.DTO;
using TechConf.Models.Models;
using TechConf.Repositories.Contracts;
using TechConf.Repositories.Implementations;
using TechConf.Services.Contracts;
using TechConf.Services.Implementations;

namespace TechConf.Web
{
    public class ConfigureServices
    {
        public static void RegisterRepositories(IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped<IOrganizationRepository<Organization>, OrganizationRepository>();
            servicesCollection.AddScoped<IRepository<Speaker>, SpeakerRepository>();
            servicesCollection.AddScoped<IEventsRepository<Event>, EventRepository>();
            servicesCollection.AddScoped<ISpeakerSessionsRepository<SpeakerSession>, SpeakerSessionRepository>();
        }

        public static void RegisterServices(IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped<IOrganizationService<OrganizationDTO>, OrganizationService>();
            servicesCollection.AddScoped<IService<SpeakerDTO>, SpeakerService>();
            servicesCollection.AddScoped<IEventService<EventDTO>, EventService>();
            servicesCollection.AddScoped<ISpeakerSessionService<SpeakerSessionDTO>, SpeakerSessionService>();
        }

        public static void RegisterMappers(IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped<IMapper<Organization, OrganizationDTO>, OrganizationMapper>();
            servicesCollection.AddScoped<IMapper<Speaker, SpeakerDTO>, SpeakerMapper>();
            servicesCollection.AddScoped<IMapper<Event, EventDTO>, EventMapper>();
            servicesCollection.AddScoped<IMapper<SpeakerSession, SpeakerSessionDTO>, SpeakerSessionMapper>();
        }
    }
}
