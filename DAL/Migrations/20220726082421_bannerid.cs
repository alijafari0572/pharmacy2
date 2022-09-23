using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class bannerid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DragId",
                table: "Banners",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DragId",
                table: "Banners");
        }
    }
}
