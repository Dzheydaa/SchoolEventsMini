using SchoolEventsMini.Data.Enums;
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

        [Required(ErrorMessage = "Името е задължително.")]
        [MaxLength(150, ErrorMessage = "Името не може да е по-дълго от 150 символа.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Датата е задължителна.")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Мястото е задължително.")]
        [MaxLength(150, ErrorMessage = "Мястото не може да е по-дълго от 150 символа.")]
        public string Place { get; set; } = string.Empty;

        public SchoolEventCategory Category { get; set; } = SchoolEventCategory.Other;

        [MaxLength(2000, ErrorMessage = "Описанието не може да е по-дълго от 2000 символа.")]
        public string? Description { get; set; }

        public Guid OrganizerId { get; set; }

        public Organizer Organizer { get; set; } = null!;

        public ICollection<EventRegistration> Registrations { get; set; } = new List<EventRegistration>();

    }




}