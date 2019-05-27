using Microsoft.EntityFrameworkCore.Migrations;

namespace akaratakapp.Migrations
{
    public partial class UpdateRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Directons_Directon_ID",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Property_FeaturesProperty_ID",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Property_Directon_ID",
                table: "Property");

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

            migrationBuilder.DropColumn(
                name: "Rooms",
                table: "Property");

            migrationBuilder.CreateTable(
                name: "Properties",
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
                    table.PrimaryKey("PK_Properties", x => x.Property_ID);
                    table.ForeignKey(
                        name: "FK_Properties_Directons_Directon_ID",
                        column: x => x.Directon_ID,
                        principalTable: "Directons",
                        principalColumn: "Directon_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Property_Property_ID",
                        column: x => x.Property_ID,
                        principalTable: "Property",
                        principalColumn: "Property_ID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Properties_Directon_ID",
                table: "Properties",
                column: "Directon_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Property_Property_ID",
                table: "Listings",
                column: "Property_ID",
                principalTable: "Property",
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
                name: "FK_Tags_Properties_FeaturesProperty_ID",
                table: "Tags",
                column: "FeaturesProperty_ID",
                principalTable: "Properties",
                principalColumn: "Property_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Property_Property_ID",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Currencies_Currency_ID",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Properties_FeaturesProperty_ID",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Offers_Currency_ID",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Listings_Property_ID",
                table: "Listings");

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

            migrationBuilder.AddColumn<int>(
                name: "Rooms",
                table: "Property",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Property_Directon_ID",
                table: "Property",
                column: "Directon_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Directons_Directon_ID",
                table: "Property",
                column: "Directon_ID",
                principalTable: "Directons",
                principalColumn: "Directon_ID",
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
