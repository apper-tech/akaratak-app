using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace akaratakapp.Migrations
{
    public partial class InitalMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 2, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    NativeName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Sign = table.Column<string>(maxLength: 20, nullable: false),
                    LocalSign = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Directon",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    South = table.Column<bool>(nullable: false),
                    East = table.Column<bool>(nullable: false),
                    West = table.Column<bool>(nullable: false),
                    North = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directon", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Listing",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listing", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    NativeName = table.Column<string>(maxLength: 20, nullable: false),
                    LatinName = table.Column<string>(maxLength: 20, nullable: false),
                    Latitude = table.Column<float>(maxLength: 25, nullable: false),
                    Longitude = table.Column<float>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sale = table.Column<float>(nullable: false),
                    Rent = table.Column<float>(nullable: false),
                    Invest = table.Column<float>(nullable: false),
                    Swap = table.Column<bool>(nullable: false),
                    CurrencyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Offer_Currency_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryID = table.Column<int>(nullable: true),
                    CityID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Address_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressID = table.Column<int>(nullable: false),
                    SubCategoryID = table.Column<int>(nullable: false),
                    OfferID = table.Column<int>(nullable: false),
                    ListingID = table.Column<int>(nullable: false),
                    ListingDate = table.Column<DateTime>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    Views = table.Column<int>(nullable: false),
                    ExtraData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Property_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_Listing_ListingID",
                        column: x => x.ListingID,
                        principalTable: "Listing",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_Offer_OfferID",
                        column: x => x.OfferID,
                        principalTable: "Offer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_SubCategory_SubCategoryID",
                        column: x => x.SubCategoryID,
                        principalTable: "SubCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    PropertyID = table.Column<int>(nullable: false),
                    DirectonID = table.Column<int>(nullable: false),
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
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.PropertyID);
                    table.ForeignKey(
                        name: "FK_Features_Directon_DirectonID",
                        column: x => x.DirectonID,
                        principalTable: "Directon",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Features_Property_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Property",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    PublicId = table.Column<string>(nullable: true),
                    PropertyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Photo_Property_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Property",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    FeaturesPropertyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tags_Features_FeaturesPropertyID",
                        column: x => x.FeaturesPropertyID,
                        principalTable: "Features",
                        principalColumn: "PropertyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityID",
                table: "Address",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryID",
                table: "Address",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryID",
                table: "City",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Features_DirectonID",
                table: "Features",
                column: "DirectonID");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_CurrencyID",
                table: "Offer",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PropertyID",
                table: "Photo",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_AddressID",
                table: "Property",
                column: "AddressID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Property_ListingID",
                table: "Property",
                column: "ListingID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Property_OfferID",
                table: "Property",
                column: "OfferID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_SubCategoryID",
                table: "Property",
                column: "SubCategoryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryID",
                table: "SubCategory",
                column: "CategoryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_FeaturesPropertyID",
                table: "Tags",
                column: "FeaturesPropertyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Directon");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Listing");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
