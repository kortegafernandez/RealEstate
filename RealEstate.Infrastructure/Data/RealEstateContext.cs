using System;
using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Entities;

namespace RealEstate.Infrastructure.Data
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext(DbContextOptions options) : base(options) { }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Owner> Owners { get; set; }        
        public DbSet<PropertyCategory> PropertyCategories { get; set; }
        public DbSet<City> Cities { get; set; }

        public RealEstateContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn();
                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Price).IsRequired();
                entity.Property(e => e.Area).IsRequired();
                entity.Property(e => e.OwnerId).IsRequired();
                entity.Property(e => e.CityId).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Address1).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Address2).HasMaxLength(100);
                entity.Property(e => e.PostalCode).HasMaxLength(15);
                entity.Property(e => e.CategoryId).IsRequired();
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn();
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.IdentificationNumber).IsRequired().HasMaxLength(30);
            });

            modelBuilder.Entity<PropertyCategory>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(20);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
            });

            //Seed data
            modelBuilder.Entity<PropertyCategory>().HasData(
                new PropertyCategory { Id = 1, Name = "Residential", CreatedOn = new DateTime(2021, 1, 24) },
                new PropertyCategory { Id = 2, Name = "Commercial", CreatedOn = new DateTime(2021, 1, 24) },
                new PropertyCategory { Id = 3, Name = "Industrial", CreatedOn = new DateTime(2021, 1, 24) },
                new PropertyCategory { Id = 4, Name = "Raw Land", CreatedOn = new DateTime(2021, 1, 24) }
            );

            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Medellín", CreatedOn = new DateTime(2021, 1, 24) },
                new City { Id = 2, Name = "Bogotá", CreatedOn = new DateTime(2021, 1, 24) },
                new City { Id = 3, Name = "Cali", CreatedOn = new DateTime(2021, 1, 24) },
                new City { Id = 4, Name = "Barranquilla", CreatedOn = new DateTime(2021, 1, 24) }
            );
        }

    }
}
