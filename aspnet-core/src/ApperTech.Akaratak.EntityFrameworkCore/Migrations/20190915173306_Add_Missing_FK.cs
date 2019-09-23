using Microsoft.EntityFrameworkCore.Migrations;

namespace ApperTech.Akaratak.Migrations
{
    public partial class Add_Missing_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCity_AppCountry_CountryId",
                table: "AppCity");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOffer_AppCurrency_CurrencyId",
                table: "AppOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPropertyType_AppCategory_CategoryId",
                table: "AppPropertyType");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "AppPropertyType",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "AppOffer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "AppCity",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppCity_AppCountry_CountryId",
                table: "AppCity",
                column: "CountryId",
                principalTable: "AppCountry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppOffer_AppCurrency_CurrencyId",
                table: "AppOffer",
                column: "CurrencyId",
                principalTable: "AppCurrency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPropertyType_AppCategory_CategoryId",
                table: "AppPropertyType",
                column: "CategoryId",
                principalTable: "AppCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCity_AppCountry_CountryId",
                table: "AppCity");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOffer_AppCurrency_CurrencyId",
                table: "AppOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPropertyType_AppCategory_CategoryId",
                table: "AppPropertyType");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "AppPropertyType",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "AppOffer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "AppCity",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AppCity_AppCountry_CountryId",
                table: "AppCity",
                column: "CountryId",
                principalTable: "AppCountry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppOffer_AppCurrency_CurrencyId",
                table: "AppOffer",
                column: "CurrencyId",
                principalTable: "AppCurrency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPropertyType_AppCategory_CategoryId",
                table: "AppPropertyType",
                column: "CategoryId",
                principalTable: "AppCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
