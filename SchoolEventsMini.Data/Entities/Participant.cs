using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEventsMini.Data.Entities
{
    public class Participant
    {
        [Key]
        public Guid ParticipantId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<EventRegistration> Registrations { get; set; } = new List<EventRegistration>();
    }
}
