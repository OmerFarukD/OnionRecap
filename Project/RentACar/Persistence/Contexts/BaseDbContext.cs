using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public BaseDbContext( DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(a =>
            {
                a.ToTable("Brands").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Models);
            });

            modelBuilder.Entity<Model>(a =>
            {
                a.ToTable("Models").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.BrandId).HasColumnName("BrandId");
                a.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
                a.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
                a.HasOne(p => p.Brand);

            });

            Brand[] brandEntitySeeds = {new(1, "Kara Passat"), new(2, "Kurşun izli Passat")};
            modelBuilder.Entity<Brand>().HasData(brandEntitySeeds);


            Model[] modelEntitySeeds = { new(1,1,"2016 Model",1500,""), new(2, 1, "2019 Model", 2500, ""), new(3, 1, "2022 Model", 3500, "")};
            modelBuilder.Entity<Model>().HasData(modelEntitySeeds);
        }
    }
}
