using Microsoft.EntityFrameworkCore;
using SchoolEventsMini.Data.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SchoolEventsMini.Data
{
    public class SchoolEventsDbContext : DbContext
    {
        public SchoolEventsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Organizer> Organizers => Set<Organizer>();
        public DbSet<SchoolEvent> SchoolEvents => Set<SchoolEvent>();
        public DbSet<Participant> Participants => Set<Participant>();
        public DbSet<EventRegistration> EventRegistrations => Set<EventRegistration>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Organizer>(entity =>
            {
                entity.HasKey(o => o.OrganizerId);
                entity.Property(o => o.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<SchoolEvent>(entity =>
            {
                entity.HasKey(e => e.SchoolEventId);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Place).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Category).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(2000);

                // One Organizer has many SchoolEvents
                entity.HasOne(e => e.Organizer)
    .WithMany(o => o.SchoolEvents)
    .HasForeignKey(e => e.OrganizerId)
    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.HasKey(p => p.ParticipantId);
                entity.Property(p => p.FullName).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<EventRegistration>(entity =>
            {
                entity.HasKey(r => r.EventRegistrationId);

                // One SchoolEvent has many EventRegistrations
                entity.HasOne(r => r.SchoolEvent)
                    .WithMany(e => e.Registrations)
                    .HasForeignKey(r => r.SchoolEventId)
                    .OnDelete(DeleteBehavior.Cascade);

                // One Participant has many EventRegistrations
                entity.HasOne(r => r.Participant)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(r => r.ParticipantId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}