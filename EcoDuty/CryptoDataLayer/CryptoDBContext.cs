using CryptoDataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace CryptoDataLayer
{
    public class CryptoDBContext : DbContext
    {
        public DbSet<Crypto> Cryptos { get; set; }
        public CryptoDBContext(DbContextOptions<CryptoDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Crypto>()
                .HasIndex(u => u.UserId)
                .IsUnique();
        }
    }

    public class CryptoDBContextFactory : IDesignTimeDbContextFactory<CryptoDBContext>
    {
        public CryptoDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CryptoDBContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CryptoUserDb;Trusted_Connection=True;MultipleActiveResultSets=true",
                                        b => b.MigrationsAssembly("CryptoDataLayer"));

            return new CryptoDBContext(optionsBuilder.Options);
        }
    }
}
