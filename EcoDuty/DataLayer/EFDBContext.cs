using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorType> SensorTypes { get; set; }
        public DbSet<Technic> Technics { get; set; }
        public DbSet<TechnicType> TechnicTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<PlaceType> PlaceTypes { get; set; }
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Passport)
                .IsUnique();
            builder.Entity<Sensor>()
                .HasIndex(u => u.SerialNumber)
                .IsUnique();
            builder.Entity<Technic>()
                .HasIndex(u => u.AutoNumber)
                .IsUnique();
            builder.Entity<Place>()
               .HasIndex(u => u.Address)
               .IsUnique();
        }
    }

    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EcoDutyDb;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));

            return new EFDBContext(optionsBuilder.Options);
        }
    }

    
}
