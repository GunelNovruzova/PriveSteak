using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class CreatedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "HomeIntros");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEN",
                table: "HomeIntros",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionEN",
                table: "HomeIntros");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "HomeIntros",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
