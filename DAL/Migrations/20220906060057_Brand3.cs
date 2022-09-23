using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Brand3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "En_Name",
                table: "Brands",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "Brands",
                type: "ntext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pic",
                table: "Brands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "En_Name",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Pic",
                table: "Brands");
        }
    }
}
