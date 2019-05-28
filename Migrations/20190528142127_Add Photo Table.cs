using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace akaratakapp.Migrations
{
    public partial class AddPhotoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Directons_Directon_ID",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_Addresses_Address_ID",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_Categories_Category_ID",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_Offers_Offer_ID",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Property_FeaturesProperty_ID",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Property",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Property_Directon_ID",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Property_Address_ID",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Property_Category_ID",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "ListingDate",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Balconies",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Bathrooms",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Cladding",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Directon_ID",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Elevator",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Empty",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "GasLine",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Heating",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Internet",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Owners",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Parking",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "PropertyAge",
                table: "Property");

            migrationBuilder.RenameTable(
                name: "Property",
                newName: "Properties");

            migrationBuilder.RenameColumn(
                name: "Category_ID",
                table: "Properties",
                newName: "Views");

            migrationBuilder.RenameColumn(
                name: "Rooms",
                table: "Properties",
                newName: "SubCategory_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Property_Offer_ID",
                table: "Properties",
                newName: "IX_Properties_Offer_ID");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "Properties",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ListingDate",
                table: "Properties",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "Properties",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                column: "Property_ID");

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Property_ID = table.Column<int>(nullable: false),
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
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Property_ID);
                    table.ForeignKey(
                        name: "FK_Features_Directons_Directon_ID",
                        column: x => x.Directon_ID,
                        principalTable: "Directons",
                        principalColumn: "Directon_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Features_Properties_Property_ID",
                        column: x => x.Property_ID,
                        principalTable: "Properties",
                        principalColumn: "Property_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Photo_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    PublicId = table.Column<string>(nullable: true),
                    Property_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Photo_ID);
                    table.ForeignKey(
                        name: "FK_Photos_Properties_Property_ID",
                        column: x => x.Property_ID,
                        principalTable: "Properties",
                        principalColumn: "Property_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_Currency_ID",
                table: "Offers",
                column: "Currency_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_Property_ID",
                table: "Listings",
                column: "Property_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_Address_ID",
                table: "Properties",
                column: "Address_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_SubCategory_ID",
                table: "Properties",
                column: "SubCategory_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_Directon_ID",
                table: "Features",
                column: "Directon_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_Property_ID",
                table: "Photos",
                column: "Property_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Properties_Property_ID",
                table: "Listings",
                column: "Property_ID",
                principalTable: "Properties",
                principalColumn: "Property_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Currencies_Currency_ID",
                table: "Offers",
                column: "Currency_ID",
                principalTable: "Currencies",
                principalColumn: "Currency_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Addresses_Address_ID",
                table: "Properties",
                column: "Address_ID",
                principalTable: "Addresses",
                principalColumn: "Address_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Offers_Offer_ID",
                table: "Properties",
                column: "Offer_ID",
                principalTable: "Offers",
                principalColumn: "Offer_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_SubCategories_SubCategory_ID",
                table: "Properties",
                column: "SubCategory_ID",
                principalTable: "SubCategories",
                principalColumn: "SubCategory_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Features_FeaturesProperty_ID",
                table: "Tags",
                column: "FeaturesProperty_ID",
                principalTable: "Features",
                principalColumn: "Property_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Properties_Property_ID",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Currencies_Currency_ID",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Addresses_Address_ID",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Offers_Offer_ID",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_SubCategories_SubCategory_ID",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Features_FeaturesProperty_ID",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Offers_Currency_ID",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Listings_Property_ID",
                table: "Listings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_Address_ID",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_SubCategory_ID",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ListingDate",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "Properties");

            migrationBuilder.RenameTable(
                name: "Properties",
                newName: "Property");

            migrationBuilder.RenameColumn(
                name: "Views",
                table: "Property",
                newName: "Category_ID");

            migrationBuilder.RenameColumn(
                name: "SubCategory_ID",
                table: "Property",
                newName: "Rooms");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_Offer_ID",
                table: "Property",
                newName: "IX_Property_Offer_ID");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "Listings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ListingDate",
                table: "Listings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "Listings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Listings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Area",
                table: "Property",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Balconies",
                table: "Property",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Bathrooms",
                table: "Property",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Cladding",
                table: "Property",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Property",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Directon_ID",
                table: "Property",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Elevator",
                table: "Property",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Empty",
                table: "Property",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GasLine",
                table: "Property",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Heating",
                table: "Property",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Internet",
                table: "Property",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Owners",
                table: "Property",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Parking",
                table: "Property",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PropertyAge",
                table: "Property",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Property",
                table: "Property",
                column: "Property_ID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Directons_Directon_ID",
                table: "Property",
                column: "Directon_ID",
                principalTable: "Directons",
                principalColumn: "Directon_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Addresses_Address_ID",
                table: "Property",
                column: "Address_ID",
                principalTable: "Addresses",
                principalColumn: "Address_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Categories_Category_ID",
                table: "Property",
                column: "Category_ID",
                principalTable: "Categories",
                principalColumn: "Category_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Offers_Offer_ID",
                table: "Property",
                column: "Offer_ID",
                principalTable: "Offers",
                principalColumn: "Offer_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Property_FeaturesProperty_ID",
                table: "Tags",
                column: "FeaturesProperty_ID",
                principalTable: "Property",
                principalColumn: "Property_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
