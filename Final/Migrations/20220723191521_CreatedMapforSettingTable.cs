using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class CreatedMapforSettingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Map",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Map",
                table: "Settings");
        }
    }
}
