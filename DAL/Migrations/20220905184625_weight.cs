using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class weight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "Drags",
                type: "ntext",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Drags",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "Drags");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Drags");
        }
    }
}
