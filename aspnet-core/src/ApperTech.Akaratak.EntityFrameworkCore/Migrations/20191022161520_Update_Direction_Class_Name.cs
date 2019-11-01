using Microsoft.EntityFrameworkCore.Migrations;

namespace ApperTech.Akaratak.Migrations
{
    public partial class Update_Direction_Class_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFeatures_Direction_DirectionId",
                table: "AppFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Direction",
                table: "Direction");

            migrationBuilder.RenameTable(
                name: "Direction",
                newName: "AppDirection");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppDirection",
                table: "AppDirection",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFeatures_AppDirection_DirectionId",
                table: "AppFeatures",
                column: "DirectionId",
                principalTable: "AppDirection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFeatures_AppDirection_DirectionId",
                table: "AppFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppDirection",
                table: "AppDirection");

            migrationBuilder.RenameTable(
                name: "AppDirection",
                newName: "Direction");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Direction",
                table: "Direction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFeatures_Direction_DirectionId",
                table: "AppFeatures",
                column: "DirectionId",
                principalTable: "Direction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
