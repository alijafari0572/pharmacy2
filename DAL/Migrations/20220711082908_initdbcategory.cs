using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initdbcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxOrder",
                table: "Drags",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinOrder",
                table: "Drags",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Drag_Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DragId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drag_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drag_Category_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drag_Category_Drags_DragId",
                        column: x => x.DragId,
                        principalTable: "Drags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drag_Category_CategoryId",
                table: "Drag_Category",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Drag_Category_DragId",
                table: "Drag_Category",
                column: "DragId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drag_Category");

            migrationBuilder.DropColumn(
                name: "MaxOrder",
                table: "Drags");

            migrationBuilder.DropColumn(
                name: "MinOrder",
                table: "Drags");
        }
    }
}
