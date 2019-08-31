using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ApperTech.Akaratak.Authorization.Roles;
using ApperTech.Akaratak.Authorization.Users;
using ApperTech.Akaratak.MultiTenancy;
using ApperTech.Akaratak.Realestate;

namespace ApperTech.Akaratak.EntityFrameworkCore
{
    public class AkaratakDbContext : AbpZeroDbContext<Tenant, Role, User, AkaratakDbContext>
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Realestate.Features> Features { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }



        /* Define a DbSet for each entity of the application */

        public AkaratakDbContext(DbContextOptions<AkaratakDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Realestate.Features>()
                .HasOne(p => p.Property)
                .WithOne(p => p.Features);


            modelBuilder.Entity<Property>()
                .HasOne(p => p.Address)
                .WithOne(a => a.Property)
                .HasForeignKey<Property>(p => p.AddressId);

            modelBuilder.Entity<Property>()
                .HasOne(p => p.PropertyType);

            modelBuilder.Entity<PropertyType>()
                .HasOne(p => p.Category);


            base.OnModelCreating(modelBuilder);
        }

    }
}

