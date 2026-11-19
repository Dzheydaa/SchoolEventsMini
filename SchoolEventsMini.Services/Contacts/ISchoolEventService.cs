using SchoolEventsMini.Data.Entities;
using SchoolEventsMini.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEventsMini.Services.Contacts
{
    public interface ISchoolEventService
    {
        Task<List<SchoolEvent>> GetAll();

        Task Create(string name, DateTime? date, string place,
            SchoolEventCategory category, string? description, Guid organizerId);
    }
}
