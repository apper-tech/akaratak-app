using Microsoft.EntityFrameworkCore.Migrations;

namespace ApperTech.Akaratak.Migrations
{
    public partial class Photo_Property_FK_Optional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPhoto_AppProperty_PropertyId",
                table: "AppPhoto");

            migrationBuilder.DropIndex(
                name: "IX_AppPhoto_PropertyId",
                table: "AppPhoto");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "AppPhoto");

            migrationBuilder.CreateIndex(
                name: "IX_AppPhoto_Photo",
                table: "AppPhoto",
                column: "Photo");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPhoto_AppProperty_Photo",
                table: "AppPhoto",
                column: "Photo",
                principalTable: "AppProperty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPhoto_AppProperty_Photo",
                table: "AppPhoto");

            migrationBuilder.DropIndex(
                name: "IX_AppPhoto_Photo",
                table: "AppPhoto");

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "AppPhoto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppPhoto_PropertyId",
                table: "AppPhoto",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPhoto_AppProperty_PropertyId",
                table: "AppPhoto",
                column: "PropertyId",
                principalTable: "AppProperty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
