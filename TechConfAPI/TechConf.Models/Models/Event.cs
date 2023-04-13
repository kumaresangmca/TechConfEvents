using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechConf.Models.Enum;

namespace TechConf.Models.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [ForeignKey("Speaker")]
        public int SpeakerId { get; set; }
        public Speaker? Speaker { get; set; }

        [Required]
        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
