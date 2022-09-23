using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class free : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "OrderDrags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "OrderDrags",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
