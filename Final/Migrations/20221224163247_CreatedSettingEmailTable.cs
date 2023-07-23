using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class CreatedSettingEmailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressAZ",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressRU",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressAZ",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AddressRU",
                table: "Settings");
        }
    }
}
