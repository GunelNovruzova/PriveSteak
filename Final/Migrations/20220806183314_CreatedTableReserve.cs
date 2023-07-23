using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class CreatedTableReserve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReserveId",
                table: "Tables",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TableCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    TableCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserves_TableCategories_TableCategoryId",
                        column: x => x.TableCategoryId,
                        principalTable: "TableCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tables_ReserveId",
                table: "Tables",
                column: "ReserveId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_TableCategoryId",
                table: "Reserves",
                column: "TableCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Reserves_ReserveId",
                table: "Tables",
                column: "ReserveId",
                principalTable: "Reserves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Reserves_ReserveId",
                table: "Tables");

            migrationBuilder.DropTable(
                name: "Reserves");

            migrationBuilder.DropTable(
                name: "TableCategories");

            migrationBuilder.DropIndex(
                name: "IX_Tables_ReserveId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "ReserveId",
                table: "Tables");
        }
    }
}
