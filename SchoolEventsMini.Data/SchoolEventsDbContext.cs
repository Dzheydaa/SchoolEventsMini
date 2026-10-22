using Microsoft.EntityFrameworkCore;
using SchoolEventsMini.Data.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SchoolEventsMini.Data
{
    public class SchoolEventsDbContext : DbContext
    {
        public SchoolEventsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<SchoolEvent> SchoolEvents => Set<SchoolEvent>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SchoolEvent>(entity =>
            {
                entity.HasKey(e => e.SchoolEventId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000);
            });
        }
    }
}