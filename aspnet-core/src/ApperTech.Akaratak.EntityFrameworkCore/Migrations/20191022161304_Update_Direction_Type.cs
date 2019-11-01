using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApperTech.Akaratak.Migrations
{
    public partial class Update_Direction_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direction",
                table: "AppFeatures");

            migrationBuilder.AddColumn<int>(
                name: "DirectionId",
                table: "AppFeatures",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Direction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    West = table.Column<bool>(nullable: false),
                    East = table.Column<bool>(nullable: false),
                    North = table.Column<bool>(nullable: false),
                    South = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direction", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppFeatures_DirectionId",
                table: "AppFeatures",
                column: "DirectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFeatures_Direction_DirectionId",
                table: "AppFeatures",
                column: "DirectionId",
                principalTable: "Direction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFeatures_Direction_DirectionId",
                table: "AppFeatures");

            migrationBuilder.DropTable(
                name: "Direction");

            migrationBuilder.DropIndex(
                name: "IX_AppFeatures_DirectionId",
                table: "AppFeatures");

            migrationBuilder.DropColumn(
                name: "DirectionId",
                table: "AppFeatures");

            migrationBuilder.AddColumn<string>(
                name: "Direction",
                table: "AppFeatures",
                nullable: false,
                defaultValue: "");
        }
    }
}
