using EventHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Configurations
{
    public class OrganizerProfileConfiguration
      : IEntityTypeConfiguration<OrganizerProfile>
    {
        public void Configure(
            EntityTypeBuilder<OrganizerProfile> builder)
        {
            builder.HasKey(p => p.OrganizerProfileId);

            builder.Property(p => p.Biography);

            builder.Property(p => p.Website);

            builder.Property(p => p.Logo);

            // One-to-One Relationship
            builder.HasOne(p => p.Organizer)
                   .WithOne(o => o.Profile)
                   .HasForeignKey<OrganizerProfile>(
                       p => p.OrganizerId);
        }
    }
    }
