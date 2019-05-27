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
    [Migration("20190527125437_Add Property Photo")]
    partial class AddPropertyPhoto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("akaratak_app.Models.Address", b =>
                {
                    b.Property<int>("Address_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("City_ID");

                    b.Property<int?>("Country_ID");

                    b.HasKey("Address_ID");

                    b.HasIndex("City_ID");

                    b.HasIndex("Country_ID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("akaratak_app.Models.Category", b =>
                {
                    b.Property<int>("Category_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Category_ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("akaratak_app.Models.City", b =>
                {
                    b.Property<int>("City_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityLatinName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("CityNativeName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("Country_ID");

                    b.Property<float>("Latitude")
                        .HasMaxLength(25);

                    b.Property<float>("Longitude")
                        .HasMaxLength(25);

                    b.HasKey("City_ID");

                    b.HasIndex("Country_ID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("akaratak_app.Models.Country", b =>
                {
                    b.Property<int>("Country_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("CountryNativeName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Country_ID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("akaratak_app.Models.Currency", b =>
                {
                    b.Property<int>("Currency_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrencyName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("CurrencySign")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Currency_ID");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("akaratak_app.Models.Directon", b =>
                {
                    b.Property<int>("Directon_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("East");

                    b.Property<bool>("North");

                    b.Property<bool>("South");

                    b.Property<bool>("West");

                    b.HasKey("Directon_ID");

                    b.ToTable("Directons");
                });

            modelBuilder.Entity("akaratak_app.Models.Features", b =>
                {
                    b.Property<int>("Property_ID");

                    b.Property<int>("Area");

                    b.Property<int>("Balconies")
                        .HasMaxLength(10);

                    b.Property<int>("Bathrooms")
                        .HasMaxLength(10);

                    b.Property<bool>("Cladding");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Directon_ID");

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

                    b.HasKey("Property_ID");

                    b.HasIndex("Directon_ID");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("akaratak_app.Models.Listing", b =>
                {
                    b.Property<int>("Listing_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Property_ID");

                    b.Property<int>("User_ID");

                    b.HasKey("Listing_ID");

                    b.HasIndex("Property_ID");

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("akaratak_app.Models.Offer", b =>
                {
                    b.Property<int>("Offer_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Currency_ID");

                    b.Property<float>("Invest");

                    b.Property<float>("Rent");

                    b.Property<float>("Sale");

                    b.Property<bool>("Swap");

                    b.HasKey("Offer_ID");

                    b.HasIndex("Currency_ID");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("akaratak_app.Models.Photo", b =>
                {
                    b.Property<int>("Photo_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<bool>("IsMain");

                    b.Property<int?>("Property_ID");

                    b.Property<string>("PublicId");

                    b.Property<string>("Url");

                    b.HasKey("Photo_ID");

                    b.HasIndex("Property_ID");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("akaratak_app.Models.Property", b =>
                {
                    b.Property<int>("Property_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Address_ID");

                    b.Property<int>("Category_ID");

                    b.Property<DateTime>("ExpireDate");

                    b.Property<string>("ExtraData");

                    b.Property<int>("Lister_ID");

                    b.Property<DateTime>("ListingDate");

                    b.Property<int>("Offer_ID");

                    b.Property<DateTime>("PublishDate");

                    b.Property<int>("Views");

                    b.HasKey("Property_ID");

                    b.HasIndex("Address_ID");

                    b.HasIndex("Category_ID");

                    b.HasIndex("Offer_ID");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("akaratak_app.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCategory_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category_ID");

                    b.Property<string>("SubCategoryDescription")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SubCategoryName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("SubCategory_ID");

                    b.HasIndex("Category_ID");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("akaratak_app.Models.Tags", b =>
                {
                    b.Property<int>("Tag_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FeaturesProperty_ID");

                    b.Property<string>("TagDescription")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Tag_ID");

                    b.HasIndex("FeaturesProperty_ID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("akaratak_app.Models.Address", b =>
                {
                    b.HasOne("akaratak_app.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("City_ID");

                    b.HasOne("akaratak_app.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("Country_ID");
                });

            modelBuilder.Entity("akaratak_app.Models.City", b =>
                {
                    b.HasOne("akaratak_app.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("Country_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("akaratak_app.Models.Features", b =>
                {
                    b.HasOne("akaratak_app.Models.Directon", "Directon")
                        .WithMany()
                        .HasForeignKey("Directon_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("akaratak_app.Models.Property", "Property")
                        .WithOne("Features")
                        .HasForeignKey("akaratak_app.Models.Features", "Property_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("akaratak_app.Models.Listing", b =>
                {
                    b.HasOne("akaratak_app.Models.Property", "Property")
                        .WithMany()
                        .HasForeignKey("Property_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("akaratak_app.Models.Offer", b =>
                {
                    b.HasOne("akaratak_app.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("Currency_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("akaratak_app.Models.Photo", b =>
                {
                    b.HasOne("akaratak_app.Models.Property", "Property")
                        .WithMany("Photos")
                        .HasForeignKey("Property_ID");
                });

            modelBuilder.Entity("akaratak_app.Models.Property", b =>
                {
                    b.HasOne("akaratak_app.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("Address_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("akaratak_app.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("Category_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("akaratak_app.Models.Offer", "Offer")
                        .WithMany()
                        .HasForeignKey("Offer_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("akaratak_app.Models.SubCategory", b =>
                {
                    b.HasOne("akaratak_app.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("Category_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("akaratak_app.Models.Tags", b =>
                {
                    b.HasOne("akaratak_app.Models.Features")
                        .WithMany("Tags")
                        .HasForeignKey("FeaturesProperty_ID");
                });
#pragma warning restore 612, 618
        }
    }
}
