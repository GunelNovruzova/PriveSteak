using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class CreatedImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Reserves",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImagePosition",
                table: "Reserves",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Reserves");

            migrationBuilder.DropColumn(
                name: "ImagePosition",
                table: "Reserves");
        }
    }
}
