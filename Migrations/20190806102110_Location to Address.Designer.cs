﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using akaratak_app.Data;

namespace akaratakapp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190806102110_Location to Address")]
    partial class LocationtoAddress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("akaratak_app.Models.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityID");

                    b.Property<string>("Location");

                    b.Property<string>("Street");

                    b.Property<string>("ZipCode");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("akaratak_app.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("akaratak_app.Models.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryID");

                    b.Property<string>("LatinName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<float>("Latitude")
                        .HasMaxLength(50);

                    b.Property<float>("Longitude")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NativeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("akaratak_app.Models.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NativeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("akaratak_app.Models.Currency", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("LocalSign")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Sign")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("akaratak_app.Models.Directon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("East");

                    b.Property<bool>("North");

                    b.Property<bool>("South");

                    b.Property<bool>("West");

                    b.HasKey("ID");

                    b.ToTable("Directon");
                });

            modelBuilder.Entity("akaratak_app.Models.Features", b =>
                {
                    b.Property<int>("PropertyID");

                    b.Property<int>("Area");

                    b.Property<int>("Balconies")
                        .HasMaxLength(10);

                    b.Property<int>("Bathrooms")
                        .HasMaxLength(10);

                    b.Property<int>("Bedrooms")
                        .HasMaxLength(10);

                    b.Property<bool>("Cladding");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("DirectonID");

                    b.Property<bool>("Elevator");

                    b.Property<bool>("Empty");

                    b.Property<bool>("GasLine");

                    b.Property<bool>("Heating");

                    b.Property<bool>("Internet");

                    b.Property<int>("Owners");

                    b.Property<bool>("Parking");

                    b.Property<int>("PropertyAge")
                        .HasMaxLength(10);

                    b.Property<int>("Rooms");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("PropertyID");

                    b.HasIndex("DirectonID");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("akaratak_app.Models.Listing", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("UserID");

                    b.HasKey("ID");

                    b.ToTable("Listing");
                });

            modelBuilder.Entity("akaratak_app.Models.Offer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrencyID");

                    b.Property<float>("Invest");

                    b.Property<float>("Rent");

                    b.Property<float>("Sale");

                    b.Property<bool>("Swap");

                    b.HasKey("ID");

                    b.HasIndex("CurrencyID");

                    b.ToTable("Offer");
                });

            modelBuilder.Entity("akaratak_app.Models.Photo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<bool>("IsMain");

                    b.Property<int?>("PropertyID");

                    b.Property<string>("PublicId");

                    b.Property<string>("Url");

                    b.HasKey("ID");

                    b.HasIndex("PropertyID");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("akaratak_app.Models.Property", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressID");

                    b.Property<DateTime>("ExpireDate");

                    b.Property<string>("ExtraData");

                    b.Property<DateTime>("ListingDate");

                    b.Property<int>("ListingID");

                    b.Property<int>("OfferID");

                    b.Property<DateTime>("PublishDate");

                    b.Property<int>("SubCategoryID");

                    b.Property<int>("Views");

                    b.HasKey("ID");

                    b.HasIndex("AddressID")
                        .IsUnique();

                    b.HasIndex("ListingID")
                        .IsUnique();

                    b.HasIndex("OfferID");

                    b.HasIndex("SubCategoryID");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("akaratak_app.Models.SubCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("SubCategory");
                });

            modelBuilder.Entity("akaratak_app.Models.Tags", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("FeaturesPropertyID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("FeaturesPropertyID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("akaratak_app.Models.Address", b =>
                {
                    b.HasOne("akaratak_app.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityID");
                });

            modelBuilder.Entity("akaratak_app.Models.City", b =>
                {
                    b.HasOne("akaratak_app.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("akaratak_app.Models.Features", b =>
                {
                    b.HasOne("akaratak_app.Models.Directon", "Directon")
                        .WithMany()
                        .HasForeignKey("DirectonID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("akaratak_app.Models.Property", "Property")
                        .WithOne("Features")
                        .HasForeignKey("akaratak_app.Models.Features", "PropertyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("akaratak_app.Models.Offer", b =>
                {
                    b.HasOne("akaratak_app.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("akaratak_app.Models.Photo", b =>
                {
                    b.HasOne("akaratak_app.Models.Property", "Property")
                        .WithMany("Photos")
                        .HasForeignKey("PropertyID");
                });

            modelBuilder.Entity("akaratak_app.Models.Property", b =>
                {
                    b.HasOne("akaratak_app.Models.Address", "Address")
                        .WithOne("Property")
                        .HasForeignKey("akaratak_app.Models.Property", "AddressID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("akaratak_app.Models.Listing", "Listing")
                        .WithOne("Property")
                        .HasForeignKey("akaratak_app.Models.Property", "ListingID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("akaratak_app.Models.Offer", "Offer")
                        .WithMany()
                        .HasForeignKey("OfferID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("akaratak_app.Models.SubCategory", "SubCategory")
                        .WithMany("Property")
                        .HasForeignKey("SubCategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("akaratak_app.Models.SubCategory", b =>
                {
                    b.HasOne("akaratak_app.Models.Category", "Category")
                        .WithMany("SubCategory")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("akaratak_app.Models.Tags", b =>
                {
                    b.HasOne("akaratak_app.Models.Features")
                        .WithMany("Tags")
                        .HasForeignKey("FeaturesPropertyID");
                });
#pragma warning restore 612, 618
        }
    }
}
