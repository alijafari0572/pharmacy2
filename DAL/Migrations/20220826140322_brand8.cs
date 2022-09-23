using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class brand8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Drags",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "En_Namee",
                table: "Drags",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Off_Price_Perset",
                table: "Drags",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drags_BrandId",
                table: "Drags",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drags_Brand_BrandId",
                table: "Drags",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drags_Brand_BrandId",
                table: "Drags");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Drags_BrandId",
                table: "Drags");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Drags");

            migrationBuilder.DropColumn(
                name: "En_Namee",
                table: "Drags");

            migrationBuilder.DropColumn(
                name: "Off_Price_Perset",
                table: "Drags");
        }
    }
}
