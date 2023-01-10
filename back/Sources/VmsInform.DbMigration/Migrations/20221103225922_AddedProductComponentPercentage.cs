using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class AddedProductComponentPercentage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Percentage",
                table: "product_components_raw",
                type: "numeric(5,3)",
                precision: 5,
                scale: 3,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "product_components_raw");
        }
    }
}
