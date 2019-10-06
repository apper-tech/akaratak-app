using Microsoft.EntityFrameworkCore.Migrations;

namespace ApperTech.Akaratak.Migrations
{
    public partial class User_Profile_Expansion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "AbpUsers",
                newName: "WebsiteUrl");

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedinUrl",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterUrl",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_PhotoId",
                table: "AbpUsers",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AppPhoto_PhotoId",
                table: "AbpUsers",
                column: "PhotoId",
                principalTable: "AppPhoto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AppPhoto_PhotoId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_PhotoId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "LinkedinUrl",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "TwitterUrl",
                table: "AbpUsers");

            migrationBuilder.RenameColumn(
                name: "WebsiteUrl",
                table: "AbpUsers",
                newName: "PhotoUrl");
        }
    }
}
