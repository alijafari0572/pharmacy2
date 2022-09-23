using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class more_deraile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "More_Detaile",
                table: "Drags",
                type: "ntext",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "More_Detaile",
                table: "Drags");
        }
    }
}
