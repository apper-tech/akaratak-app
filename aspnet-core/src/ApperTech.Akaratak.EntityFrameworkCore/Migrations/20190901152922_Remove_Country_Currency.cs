using Microsoft.EntityFrameworkCore.Migrations;

namespace ApperTech.Akaratak.Migrations
{
    public partial class Remove_Country_Currency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCountry_AppCurrency_CurrencyId",
                table: "AppCountry");

            migrationBuilder.DropIndex(
                name: "IX_AppCountry_CurrencyId",
                table: "AppCountry");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "AppCountry");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "AppCountry",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppCountry_CurrencyId",
                table: "AppCountry",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCountry_AppCurrency_CurrencyId",
                table: "AppCountry",
                column: "CurrencyId",
                principalTable: "AppCurrency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
