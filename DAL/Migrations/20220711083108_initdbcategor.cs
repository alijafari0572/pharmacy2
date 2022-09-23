using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initdbcategor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drag_Category_Categories_CategoryId",
                table: "Drag_Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Drag_Category_Drags_DragId",
                table: "Drag_Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drag_Category",
                table: "Drag_Category");

            migrationBuilder.RenameTable(
                name: "Drag_Category",
                newName: "DragCategories");

            migrationBuilder.RenameIndex(
                name: "IX_Drag_Category_DragId",
                table: "DragCategories",
                newName: "IX_DragCategories_DragId");

            migrationBuilder.RenameIndex(
                name: "IX_Drag_Category_CategoryId",
                table: "DragCategories",
                newName: "IX_DragCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DragCategories",
                table: "DragCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DragCategories_Categories_CategoryId",
                table: "DragCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DragCategories_Drags_DragId",
                table: "DragCategories",
                column: "DragId",
                principalTable: "Drags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DragCategories_Categories_CategoryId",
                table: "DragCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_DragCategories_Drags_DragId",
                table: "DragCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DragCategories",
                table: "DragCategories");

            migrationBuilder.RenameTable(
                name: "DragCategories",
                newName: "Drag_Category");

            migrationBuilder.RenameIndex(
                name: "IX_DragCategories_DragId",
                table: "Drag_Category",
                newName: "IX_Drag_Category_DragId");

            migrationBuilder.RenameIndex(
                name: "IX_DragCategories_CategoryId",
                table: "Drag_Category",
                newName: "IX_Drag_Category_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drag_Category",
                table: "Drag_Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drag_Category_Categories_CategoryId",
                table: "Drag_Category",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drag_Category_Drags_DragId",
                table: "Drag_Category",
                column: "DragId",
                principalTable: "Drags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
