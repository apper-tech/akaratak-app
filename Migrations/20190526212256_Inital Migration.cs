using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace akaratakapp.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Category_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(maxLength: 20, nullable: false),
                    CategoryDescription = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Category_ID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Country_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryCode = table.Column<string>(maxLength: 2, nullable: false),
                    CountryName = table.Column<string>(maxLength: 20, nullable: false),
                    CountryNativeName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Country_ID);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Currency_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrencyName = table.Column<string>(maxLength: 20, nullable: false),
                    CurrencySign = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Currency_ID);
                });

            migrationBuilder.CreateTable(
                name: "Directons",
                columns: table => new
                {
                    Directon_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    South = table.Column<bool>(nullable: false),
                    East = table.Column<bool>(nullable: false),
                    West = table.Column<bool>(nullable: false),
                    North = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directons", x => x.Directon_ID);
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Listing_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_ID = table.Column<int>(nullable: false),
                    Property_ID = table.Column<int>(nullable: false),
                    ListingDate = table.Column<DateTime>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    Views = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Listing_ID);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Offer_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sale = table.Column<float>(nullable: false),
                    Rent = table.Column<float>(nullable: false),
                    Invest = table.Column<float>(nullable: false),
                    Swap = table.Column<bool>(nullable: false),
                    Currency_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Offer_ID);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    SubCategory_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category_ID = table.Column<int>(nullable: false),
                    SubCategoryName = table.Column<string>(maxLength: 20, nullable: false),
                    SubCategoryDescription = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.SubCategory_ID);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_Category_ID",
                        column: x => x.Category_ID,
                        principalTable: "Categories",
                        principalColumn: "Category_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    City_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Country_ID = table.Column<int>(nullable: false),
                    CityName = table.Column<string>(maxLength: 20, nullable: false),
                    CityNativeName = table.Column<string>(maxLength: 20, nullable: false),
                    CityLatinName = table.Column<string>(maxLength: 20, nullable: false),
                    Latitude = table.Column<float>(maxLength: 25, nullable: false),
                    Longitude = table.Column<float>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.City_ID);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_Country_ID",
                        column: x => x.Country_ID,
                        principalTable: "Countries",
                        principalColumn: "Country_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Address_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Country_ID = table.Column<int>(nullable: true),
                    City_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Address_ID);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_City_ID",
                        column: x => x.City_ID,
                        principalTable: "Cities",
                        principalColumn: "City_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_Country_ID",
                        column: x => x.Country_ID,
                        principalTable: "Countries",
                        principalColumn: "Country_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Property_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address_ID = table.Column<int>(nullable: false),
                    Offer_ID = table.Column<int>(nullable: false),
                    Directon_ID = table.Column<int>(nullable: false),
                    Cladding = table.Column<bool>(nullable: false),
                    Empty = table.Column<bool>(nullable: false),
                    Heating = table.Column<bool>(nullable: false),
                    GasLine = table.Column<bool>(nullable: false),
                    Internet = table.Column<bool>(nullable: false),
                    Elevator = table.Column<bool>(nullable: false),
                    Parking = table.Column<bool>(nullable: false),
                    Area = table.Column<int>(nullable: false),
                    Owners = table.Column<int>(nullable: false),
                    Rooms = table.Column<int>(nullable: false),
                    Bathrooms = table.Column<int>(maxLength: 10, nullable: false),
                    Balconies = table.Column<int>(maxLength: 10, nullable: false),
                    PropertyAge = table.Column<int>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    Category_ID = table.Column<int>(nullable: false),
                    Lister_ID = table.Column<int>(nullable: false),
                    ExtraData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Property_ID);
                    table.ForeignKey(
                        name: "FK_Property_Directons_Directon_ID",
                        column: x => x.Directon_ID,
                        principalTable: "Directons",
                        principalColumn: "Directon_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_Addresses_Address_ID",
                        column: x => x.Address_ID,
                        principalTable: "Addresses",
                        principalColumn: "Address_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_Categories_Category_ID",
                        column: x => x.Category_ID,
                        principalTable: "Categories",
                        principalColumn: "Category_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_Offers_Offer_ID",
                        column: x => x.Offer_ID,
                        principalTable: "Offers",
                        principalColumn: "Offer_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Tag_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TagName = table.Column<string>(maxLength: 20, nullable: false),
                    TagDescription = table.Column<string>(maxLength: 50, nullable: false),
                    FeaturesProperty_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Tag_ID);
                    table.ForeignKey(
                        name: "FK_Tags_Property_FeaturesProperty_ID",
                        column: x => x.FeaturesProperty_ID,
                        principalTable: "Property",
                        principalColumn: "Property_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_City_ID",
                table: "Addresses",
                column: "City_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Country_ID",
                table: "Addresses",
                column: "Country_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Country_ID",
                table: "Cities",
                column: "Country_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_Directon_ID",
                table: "Property",
                column: "Directon_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_Address_ID",
                table: "Property",
                column: "Address_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_Category_ID",
                table: "Property",
                column: "Category_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_Offer_ID",
                table: "Property",
                column: "Offer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_Category_ID",
                table: "SubCategories",
                column: "Category_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_FeaturesProperty_ID",
                table: "Tags",
                column: "FeaturesProperty_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "Directons");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
