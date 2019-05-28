using Microsoft.EntityFrameworkCore;
using akaratak_app.Models;


namespace akaratak_app.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Directon> Directons { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Tags> Tags { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>()
            .HasOne(p => p.Features)
            .WithOne(p => p.Property)
            .HasForeignKey<Property>(p => p.Property_ID);

            modelBuilder.Entity<Features>()
            .HasOne(p => p.Property)
            .WithOne(p => p.Features)
            .HasForeignKey<Features>(p => p.Property_ID);


            modelBuilder.Entity<Property>()
            .HasOne(p => p.Address)
            .WithOne(a => a.Property)
            .HasForeignKey<Property>(p => p.Address_ID);

            modelBuilder.Entity<Property>()
            .HasOne(p => p.SubCategory)
            .WithOne(a => a.Property)
            .HasForeignKey<Property>(p => p.SubCategory_ID);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}