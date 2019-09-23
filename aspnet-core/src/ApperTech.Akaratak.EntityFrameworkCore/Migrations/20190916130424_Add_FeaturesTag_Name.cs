using Microsoft.EntityFrameworkCore.Migrations;

namespace ApperTech.Akaratak.Migrations
{
    public partial class Add_FeaturesTag_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeaturesTag_AppFeatures_FeaturesId",
                table: "FeaturesTag");

            migrationBuilder.DropForeignKey(
                name: "FK_FeaturesTag_AppTag_TagId",
                table: "FeaturesTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeaturesTag",
                table: "FeaturesTag");

            migrationBuilder.RenameTable(
                name: "FeaturesTag",
                newName: "AppFeaturesTag");

            migrationBuilder.RenameIndex(
                name: "IX_FeaturesTag_FeaturesId",
                table: "AppFeaturesTag",
                newName: "IX_AppFeaturesTag_FeaturesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppFeaturesTag",
                table: "AppFeaturesTag",
                columns: new[] { "TagId", "FeaturesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppFeaturesTag_AppFeatures_FeaturesId",
                table: "AppFeaturesTag",
                column: "FeaturesId",
                principalTable: "AppFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppFeaturesTag_AppTag_TagId",
                table: "AppFeaturesTag",
                column: "TagId",
                principalTable: "AppTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFeaturesTag_AppFeatures_FeaturesId",
                table: "AppFeaturesTag");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFeaturesTag_AppTag_TagId",
                table: "AppFeaturesTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppFeaturesTag",
                table: "AppFeaturesTag");

            migrationBuilder.RenameTable(
                name: "AppFeaturesTag",
                newName: "FeaturesTag");

            migrationBuilder.RenameIndex(
                name: "IX_AppFeaturesTag_FeaturesId",
                table: "FeaturesTag",
                newName: "IX_FeaturesTag_FeaturesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeaturesTag",
                table: "FeaturesTag",
                columns: new[] { "TagId", "FeaturesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturesTag_AppFeatures_FeaturesId",
                table: "FeaturesTag",
                column: "FeaturesId",
                principalTable: "AppFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturesTag_AppTag_TagId",
                table: "FeaturesTag",
                column: "TagId",
                principalTable: "AppTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
