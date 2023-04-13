using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechConf.Models.DTO
{
    public class OrganizationDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string ApiKey { get; set; } = string.Empty;
    }
}
