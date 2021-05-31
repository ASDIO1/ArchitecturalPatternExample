using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI.Data
{
    public class PastryShopDbContext : DbContext
    {
        public DbSet<ProductEntity> Categories { get; set; }
        // public DbSet<PlayerEntity> Players { get; set; }

        public PastryShopDbContext(DbContextOptions<PastryShopDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductEntity>().ToTable("Categories");
            modelBuilder.Entity<ProductEntity>().Property(c => c.Id).ValueGeneratedOnAdd();
            //modelBuilder.Entity<CategoryEntity>().HasMany(t => t.Players).WithOne(p => p.Team);

            /*modelBuilder.Entity<PlayerEntity>().ToTable("Players");
            modelBuilder.Entity<PlayerEntity>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<PlayerEntity>().HasOne(p => p.Team).WithMany(t => t.Players);*/

            //dotnet tool install --global dotnet-ef
            //dotnet ef migrations add InitialCreate
            //dotnet ef database update
        }
    }
}
