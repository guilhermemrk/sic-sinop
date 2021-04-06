using Microsoft.EntityFrameworkCore;
using SICSinop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Admin", CPF = "000.000.000-00", Email = "example@mail.com", CEP = "00000-000", Rank = 1 }
        );

        modelBuilder.Entity<Marker>().HasData(
            new Marker { Id = 1, UserId = 1, Title = "First Marker", Description = "Just a test", Latitude = "123.321312", Longitude = "231.53221", Status = "1" },
            new Marker { Id = 2, UserId = 1, Title = "Second Marker", Description = "Just another test", Latitude = "11.53221", Longitude = "32.321312", Status = "2" }
        );
    }
}