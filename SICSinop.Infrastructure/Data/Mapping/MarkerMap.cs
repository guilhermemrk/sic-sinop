using SICSinop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Data.Mapping
{
    public class MarkerMap : IEntityTypeConfiguration<Marker>
    {
        public void Configure(EntityTypeBuilder<Marker> builder)
        {
            builder
                .ToTable("Marker");
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.UserId);
            builder
                .Property(x => x.Title);
            builder
                .Property(x => x.Description);
            builder
                .Property(x => x.Latitude);
            builder
                .Property(x => x.Longitude);
            builder
                .Property(x => x.Status);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Markers)
                .HasForeignKey(x => x.UserId);
        }
    }
}
