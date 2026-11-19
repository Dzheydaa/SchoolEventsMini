using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEventsMini.Data.Entities
{
    public class Organizer
    {
        //[Key]
        public Guid OrganizerId { get; set; }

        //[Required]
        //[MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<SchoolEvent> SchoolEvents { get; set; } = new List<SchoolEvent>();
    }
}
