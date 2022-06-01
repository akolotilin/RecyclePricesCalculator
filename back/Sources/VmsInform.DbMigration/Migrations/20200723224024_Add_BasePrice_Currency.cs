using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class Add_BasePrice_Currency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CurrencyId",
                table: "BaseGoodPrices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseGoodPrices_CurrencyId",
                table: "BaseGoodPrices",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseGoodPrices_Currencies_CurrencyId",
                table: "BaseGoodPrices",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseGoodPrices_Currencies_CurrencyId",
                table: "BaseGoodPrices");

            migrationBuilder.DropIndex(
                name: "IX_BaseGoodPrices_CurrencyId",
                table: "BaseGoodPrices");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "BaseGoodPrices");
        }
    }
}
