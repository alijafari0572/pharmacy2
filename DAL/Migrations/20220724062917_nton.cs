using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class nton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DragCategories",
                table: "DragCategories");

            migrationBuilder.DropIndex(
                name: "IX_DragCategories_DragId",
                table: "DragCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DragCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DragCategories",
                table: "DragCategories",
                columns: new[] { "DragId", "CategoryId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DragCategories",
                table: "DragCategories");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DragCategories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DragCategories",
                table: "DragCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DragCategories_DragId",
                table: "DragCategories",
                column: "DragId");
        }
    }
}
