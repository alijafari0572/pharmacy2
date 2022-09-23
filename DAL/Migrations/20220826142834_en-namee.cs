using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ennamee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "En_Namee",
                table: "Drags");

            migrationBuilder.AddColumn<string>(
                name: "En_Name",
                table: "Drags",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "En_Name",
                table: "Drags");

            migrationBuilder.AddColumn<string>(
                name: "En_Namee",
                table: "Drags",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
