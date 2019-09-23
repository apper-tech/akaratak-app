using Microsoft.EntityFrameworkCore.Migrations;

namespace ApperTech.Akaratak.Migrations
{
    public partial class Features_Tags_Many_to_Many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTag_AppFeatures_FeaturesId",
                table: "AppTag");

            migrationBuilder.DropIndex(
                name: "IX_AppTag_FeaturesId",
                table: "AppTag");

            migrationBuilder.DropColumn(
                name: "FeaturesId",
                table: "AppTag");

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "AppPhoto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FeaturesTag",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false),
                    FeaturesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturesTag", x => new { x.TagId, x.FeaturesId });
                    table.ForeignKey(
                        name: "FK_FeaturesTag_AppFeatures_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "AppFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeaturesTag_AppTag_TagId",
                        column: x => x.TagId,
                        principalTable: "AppTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeaturesTag_FeaturesId",
                table: "FeaturesTag",
                column: "FeaturesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeaturesTag");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "AppPhoto");

            migrationBuilder.AddColumn<int>(
                name: "FeaturesId",
                table: "AppTag",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppTag_FeaturesId",
                table: "AppTag",
                column: "FeaturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTag_AppFeatures_FeaturesId",
                table: "AppTag",
                column: "FeaturesId",
                principalTable: "AppFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
