using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI.Data
{
    public class PastryShopDbContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }

        public PastryShopDbContext(DbContextOptions<PastryShopDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductEntity>().ToTable("Products");
            modelBuilder.Entity<ProductEntity>().Property(p => p.Id).ValueGeneratedOnAdd();

            //dotnet tool install --global dotnet-ef
            //dotnet ef migrations add InitialCreate
            //dotnet ef database update
        }
    }
}
