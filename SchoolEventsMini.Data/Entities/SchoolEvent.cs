using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEventsMini.Data.Entities
{
   
    public class SchoolEvent
    {
        public Guid SchoolEventId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(150)]
        public string Place { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Category { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
