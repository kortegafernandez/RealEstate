using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Entities;

namespace RealEstate.Infrastructure.Data
{
    public class RealEstateContext:DbContext
    {
        public RealEstateContext(DbContextOptions options) : base(options) { }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PropertyCategory> PropertyCategories { get; set; }

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
                entity.Property(e => e.AddressId).IsRequired();
                entity.Property(e => e.CategoryId).IsRequired();
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn();
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.IdentificationNumber).IsRequired().HasMaxLength(30);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn();
                entity.Property(e => e.City).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Country).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Address1).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Address2).HasMaxLength(100);
                entity.Property(e => e.PostalCode).HasMaxLength(15);
            });

            modelBuilder.Entity<PropertyCategory>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
            });
        }

    }
}
