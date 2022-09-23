using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Brand4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Brands",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "Brands",
                type: "ntext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "En_Country",
                table: "Brands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Detail",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "En_Country",
                table: "Brands");
        }
    }
}
