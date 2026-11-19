using Microsoft.EntityFrameworkCore;
using SchoolEventsMini.Data;
using SchoolEventsMini.Data.Entities;
using SchoolEventsMini.Data.Enums;
using SchoolEventsMini.Services.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEventsMini.Services
{
    public class SchoolEventService : ISchoolEventService
    {
        private readonly SchoolEventsDbContext _db;

        public SchoolEventService(SchoolEventsDbContext context)
        {
            _db = context;
        }

        public async Task Create(string name, DateTime? date, string place,
            SchoolEventCategory category, string? description, Guid organizerId)
        {
            var schoolEvent = new SchoolEvent
            {
                SchoolEventId = Guid.NewGuid(),
                Name = name,
                Date = date,
                Place = place,
                Category = category,
                Description = description,
                OrganizerId = organizerId
            };

            _db.SchoolEvents.Add(schoolEvent);
            await _db.SaveChangesAsync();
        }

        public Task<List<SchoolEvent>> GetAll()
        {
            return _db.SchoolEvents
                .OrderBy(e => e.Name)
                .ToListAsync();
        }
    }
}
