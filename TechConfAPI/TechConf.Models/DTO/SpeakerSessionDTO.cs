using System.ComponentModel.DataAnnotations;

namespace TechConf.Models.DTO
{
    public class SpeakerSessionDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int EventId { get; set; }
        public EventDTO? Event { get; set; }
        [Required]
        public int SpeakerId { get; set; }
        public SpeakerDTO? speaker { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
