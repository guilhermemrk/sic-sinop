using SICSinop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Data.Mapping
{
    public class MarkerCommentMap : IEntityTypeConfiguration<MarkerComment>
    {
        public void Configure(EntityTypeBuilder<MarkerComment> builder)
        {
            builder
                .ToTable("MarkerComment");
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.UserId);
            builder
                .Property(x => x.MarkerId);
            builder
                .Property(x => x.Message);
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.MarkerComments)
	            .HasForeignKey(x => x.UserId);
            builder
                .HasOne(x => x.Marker)
                .WithMany(x => x.MarkerComments)
	            .HasForeignKey(x => x.MarkerId);
        }
    }
}
