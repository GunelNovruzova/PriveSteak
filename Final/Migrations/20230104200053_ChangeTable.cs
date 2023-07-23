using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class ChangeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainEmail",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Contacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainEmail",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
