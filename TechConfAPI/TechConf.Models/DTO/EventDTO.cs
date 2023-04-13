using System.ComponentModel.DataAnnotations;
using TechConf.Models.Enum;

namespace TechConf.Models.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime EventDate { get; set; }
        [Required]
        public EventType Type { get; set; }
        [Required]
        public string Venu { get; set; } = string.Empty;
        [Required]
        public string Website { get; set; } = string.Empty;
        [Required]
        public string LinkForDetails { get; set; } = string.Empty;
        [Required]
        public int SpeakerId { get; set; }
        public SpeakerDTO? speaker { get; set; }

        [Required]
        public int OrganizationId { get; set; }        
        public OrganizationDTO? organization { get; set; }
    }
}
