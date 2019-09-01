using Microsoft.EntityFrameworkCore.Migrations;

namespace ApperTech.Akaratak.Migrations
{
    public partial class City_Country_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppCountry_CurrencyId",
                table: "AppCountry");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AppCurrency",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AppCountry_CurrencyId",
                table: "AppCountry",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppCountry_CurrencyId",
                table: "AppCountry");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AppCurrency");

            migrationBuilder.CreateIndex(
                name: "IX_AppCountry_CurrencyId",
                table: "AppCountry",
                column: "CurrencyId",
                unique: true);
        }
    }
}
