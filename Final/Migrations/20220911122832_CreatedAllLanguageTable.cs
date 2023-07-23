using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class CreatedAllLanguageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TitleAZ",
                table: "TableCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleRU",
                table: "TableCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsDescriptionAZ",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsDescriptionRU",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsTitleAZ",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsTitleRU",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionAZ",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionRU",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameAZ",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameRU",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionAZ",
                table: "HomeIntros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionRU",
                table: "HomeIntros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntroAZ",
                table: "HomeIntros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntroRU",
                table: "HomeIntros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleAZ",
                table: "HomeIntros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleRU",
                table: "HomeIntros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameAZ",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameRU",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionAZ",
                table: "AboutIntros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionRU",
                table: "AboutIntros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeatureAZ",
                table: "AboutIntros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeatureRU",
                table: "AboutIntros",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleAZ",
                table: "TableCategories");

            migrationBuilder.DropColumn(
                name: "TitleRU",
                table: "TableCategories");

            migrationBuilder.DropColumn(
                name: "ContactUsDescriptionAZ",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ContactUsDescriptionRU",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ContactUsTitleAZ",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ContactUsTitleRU",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "DescriptionAZ",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DescriptionRU",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NameAZ",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NameRU",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DescriptionAZ",
                table: "HomeIntros");

            migrationBuilder.DropColumn(
                name: "DescriptionRU",
                table: "HomeIntros");

            migrationBuilder.DropColumn(
                name: "IntroAZ",
                table: "HomeIntros");

            migrationBuilder.DropColumn(
                name: "IntroRU",
                table: "HomeIntros");

            migrationBuilder.DropColumn(
                name: "TitleAZ",
                table: "HomeIntros");

            migrationBuilder.DropColumn(
                name: "TitleRU",
                table: "HomeIntros");

            migrationBuilder.DropColumn(
                name: "NameAZ",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NameRU",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DescriptionAZ",
                table: "AboutIntros");

            migrationBuilder.DropColumn(
                name: "DescriptionRU",
                table: "AboutIntros");

            migrationBuilder.DropColumn(
                name: "FeatureAZ",
                table: "AboutIntros");

            migrationBuilder.DropColumn(
                name: "FeatureRU",
                table: "AboutIntros");
        }
    }
}
