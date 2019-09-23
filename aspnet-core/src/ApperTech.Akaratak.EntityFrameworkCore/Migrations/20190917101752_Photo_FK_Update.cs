using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApperTech.Akaratak.Migrations
{
    public partial class Photo_FK_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPhoto_AppProperty_Photo",
                table: "AppPhoto");

            migrationBuilder.DropIndex(
                name: "IX_AppPhoto_Photo",
                table: "AppPhoto");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "AppPhoto");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPhoto_AppProperty_PropertyId",
                table: "AppPhoto");

            migrationBuilder.DropIndex(
                name: "IX_AppPhoto_PropertyId",
                table: "AppPhoto");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "AppPhoto",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
    }
}
