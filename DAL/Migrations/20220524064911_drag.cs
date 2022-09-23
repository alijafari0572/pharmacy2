using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class drag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pic",
                table: "Drags",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pic",
                table: "Drags");
        }
    }
}
