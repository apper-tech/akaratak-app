using Microsoft.EntityFrameworkCore.Migrations;

namespace ApperTech.Akaratak.Migrations
{
    public partial class Add_City_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAddress_AppCity_CityId",
                table: "AppAddress");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "AppAddress",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppAddress_AppCity_CityId",
                table: "AppAddress",
                column: "CityId",
                principalTable: "AppCity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAddress_AppCity_CityId",
                table: "AppAddress");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "AppAddress",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AppAddress_AppCity_CityId",
                table: "AppAddress",
                column: "CityId",
                principalTable: "AppCity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
