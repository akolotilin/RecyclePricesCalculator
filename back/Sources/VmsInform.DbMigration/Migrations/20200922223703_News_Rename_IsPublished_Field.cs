using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class News_Rename_IsPublished_Field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "News");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "News",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "News");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "News",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
