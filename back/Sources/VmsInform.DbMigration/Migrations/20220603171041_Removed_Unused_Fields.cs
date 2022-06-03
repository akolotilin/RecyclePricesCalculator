using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class Removed_Unused_Fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CellPhone",
                table: "partners");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "partners");

            migrationBuilder.DropColumn(
                name: "OfficePhone",
                table: "partners");

            migrationBuilder.DropColumn(
                name: "Skype",
                table: "partners");

            migrationBuilder.DropColumn(
                name: "Viber",
                table: "partners");

            migrationBuilder.DropColumn(
                name: "WhatsApp",
                table: "partners");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CellPhone",
                table: "partners",
                type: "varchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "partners",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OfficePhone",
                table: "partners",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skype",
                table: "partners",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Viber",
                table: "partners",
                type: "varchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WhatsApp",
                table: "partners",
                type: "varchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");
        }
    }
}
