using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class CreatedTopLeftTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageHeigth",
                table: "Reserves");

            migrationBuilder.DropColumn(
                name: "ImagePosition",
                table: "Reserves");

            migrationBuilder.DropColumn(
                name: "ImageWidth",
                table: "Reserves");

            migrationBuilder.AddColumn<string>(
                name: "ImagePositionLEFT",
                table: "Reserves",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePositionTOP",
                table: "Reserves",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePositionLEFT",
                table: "Reserves");

            migrationBuilder.DropColumn(
                name: "ImagePositionTOP",
                table: "Reserves");

            migrationBuilder.AddColumn<string>(
                name: "ImageHeigth",
                table: "Reserves",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePosition",
                table: "Reserves",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageWidth",
                table: "Reserves",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
