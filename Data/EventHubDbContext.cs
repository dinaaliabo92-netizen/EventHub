using EventHub.Configurations;
using EventHub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Data
{
    public class EventHubDbContext : DbContext
    {
        public EventHubDbContext()
        {
        }

        public EventHubDbContext(
            DbContextOptions<EventHubDbContext> options)
            : base(options)
        {
        }

        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<Badge> Badges { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=.;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration Classes
            modelBuilder.ApplyConfiguration(
                new OrganizerProfileConfiguration());

            modelBuilder.ApplyConfiguration(
                new BadgeConfiguration());

            // Event Configuration - Fluent API directly

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Titel)
                      .IsRequired();

                entity.Property(e => e.Description)
                      .IsRequired();

                entity.Property(e => e.StartDate)
                      .IsRequired();

                entity.Property(e => e.EndDate)
                      .IsRequired(false);

                entity.Property(e => e.MaxAttendees)
                      .IsRequired();

                // One-to-Many Relationship
                entity.HasOne(e => e.Organizer)
                      .WithMany(o => o.Events)
                      .HasForeignKey(e => e.OrganizerId);
            });
        }
    }
}