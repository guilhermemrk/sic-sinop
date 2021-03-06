using SICSinop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SICSinop.Infrastructure.Data.Context
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Marker> Markers { get; set; }
    }
}

// dotnet ef migrations add InitialCreate -s SICSinop.API -p SICSinop.Infrastructure
// dotnet ef database update -p SICSinop.API
