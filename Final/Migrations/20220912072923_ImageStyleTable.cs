using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class ImageStyleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageHeigth",
                table: "Reserves",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageWidth",
                table: "Reserves",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageHeigth",
                table: "Reserves");

            migrationBuilder.DropColumn(
                name: "ImageWidth",
                table: "Reserves");
        }
    }
}
