using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class CreatedDescriptionTableforAboutIntro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "AboutIntros");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AboutIntros",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AboutIntros");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AboutIntros",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
