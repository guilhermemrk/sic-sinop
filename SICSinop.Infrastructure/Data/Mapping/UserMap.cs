using SICSinop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("User");
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.Name);
            builder
                .Property(x => x.CPF);
            builder
                .Property(x => x.Email);
            builder
                .Property(x => x.CEP);
            builder
                .Property(x => x.Rank);
            builder
                .HasMany(x => x.Markers)
                .WithOne(x => x.User);
                    
        }
    }
}
