using Microsoft.EntityFrameworkCore;
using akaratak_app.Models;


namespace akaratak_app.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Address> Address { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Directon> Directon { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<Listing> Listing { get; set; }
        public DbSet<Offer> Offer { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Tags> Tags { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Features>()
            .HasOne(p => p.Property)
            .WithOne(p => p.Features)
            .HasForeignKey<Features>(p => p.PropertyID);


            modelBuilder.Entity<Property>()
            .HasOne(p => p.Address)
            .WithOne(a => a.Property)
            .HasForeignKey<Property>(p => p.AddressID);

            modelBuilder.Entity<Property>()
            .HasOne(p => p.SubCategory)
            .WithMany(a => a.Property)
            .HasForeignKey(p => p.SubCategoryID);

            modelBuilder.Entity<Property>()
            .HasOne(p => p.Listing)
            .WithOne(a => a.Property)
            .HasForeignKey<Property>(p => p.ListingID);

            modelBuilder.Entity<Features>()
           .HasOne(f => f.Directon);

            modelBuilder.Entity<SubCategory>()
            .HasOne(p => p.Category)
            .WithMany(a => a.SubCategory)
            .HasForeignKey(p => p.CategoryID);

            base.OnModelCreating(modelBuilder);
        }
    }
}