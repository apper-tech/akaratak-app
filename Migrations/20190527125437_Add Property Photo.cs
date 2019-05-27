using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace akaratakapp.Migrations
{
    public partial class AddPropertyPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "ListingDate",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Listings");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "Property",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ListingDate",
                table: "Property",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "Property",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Property",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Photo_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    PublicId = table.Column<string>(nullable: true),
                    Property_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Photo_ID);
                    table.ForeignKey(
                        name: "FK_Photos_Property_Property_ID",
                        column: x => x.Property_ID,
                        principalTable: "Property",
                        principalColumn: "Property_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_Property_ID",
                table: "Photos",
                column: "Property_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "ListingDate",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Property");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "Listings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ListingDate",
                table: "Listings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "Listings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Listings",
                nullable: false,
                defaultValue: 0);
        }
    }
}
