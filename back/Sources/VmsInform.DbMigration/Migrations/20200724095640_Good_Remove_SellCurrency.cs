using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class Good_Remove_SellCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Good_Currencies_SellCurrencyId",
                table: "Good");

            migrationBuilder.DropIndex(
                name: "IX_Good_SellCurrencyId",
                table: "Good");

            migrationBuilder.DropColumn(
                name: "SellCurrencyId",
                table: "Good");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SellCurrencyId",
                table: "Good",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Good_SellCurrencyId",
                table: "Good",
                column: "SellCurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Good_Currencies_SellCurrencyId",
                table: "Good",
                column: "SellCurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
