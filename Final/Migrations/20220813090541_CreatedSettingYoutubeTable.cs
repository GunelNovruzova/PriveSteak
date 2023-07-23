using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class CreatedSettingYoutubeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Youtube",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Youtube",
                table: "Settings");
        }
    }
}
