using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinfast.models;

namespace Vinfast.api.Models
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<version> versions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Versions Table
            modelBuilder.Entity<version>().HasData(
               new version { VersionId = 1, VersionName = "Tiêu Chuẩn" });
            modelBuilder.Entity<version>().HasData(
               new version { VersionId = 2, VersionName = "Nâng Cao" });
            modelBuilder.Entity<version>().HasData(
               new version { VersionId = 3, VersionName = "Cao Cấp" });

            // Seed Products Table
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Name = "LUX A2.0",
                ProductId = 1,
                Price = 800000000,
                PhotoPath = "image/a20.png"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Name = "LUX SA2.0",
                ProductId = 2,
                Price = 1200000000,
                PhotoPath = "image/sa20.png"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Name = "Fadil",
                ProductId = 3,
                Price = 362000000,
                PhotoPath = "image/fadil.png"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Name = "President",
                ProductId = 4,
                Price = 3800000000,
                PhotoPath = "image/president.png"
            });

        }
    }
}
