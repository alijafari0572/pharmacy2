using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class @finally : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFinaly",
                table: "Orders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinaly",
                table: "Orders");
        }
    }
}
