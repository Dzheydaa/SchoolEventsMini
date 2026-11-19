using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEventsMini.Data.Entities
{
    public class EventRegistration
    {
        //[Key]
        public Guid EventRegistrationId { get; set; }

        //[Required]
        public Guid SchoolEventId { get; set; }

        //[Required]
        public Guid ParticipantId { get; set; }

        // Navigation properties
        public SchoolEvent SchoolEvent { get; set; } = null!;
        public Participant Participant { get; set; } = null!;
    }
}
