using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class PartnerGoodToSell_Currency_Set_NotNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartnerGoodsToSell_Currencies_CurrencyId",
                table: "PartnerGoodsToSell");

            migrationBuilder.AlterColumn<long>(
                name: "CurrencyId",
                table: "PartnerGoodsToSell",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PartnerGoodsToSell_Currencies_CurrencyId",
                table: "PartnerGoodsToSell",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartnerGoodsToSell_Currencies_CurrencyId",
                table: "PartnerGoodsToSell");

            migrationBuilder.AlterColumn<long>(
                name: "CurrencyId",
                table: "PartnerGoodsToSell",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_PartnerGoodsToSell_Currencies_CurrencyId",
                table: "PartnerGoodsToSell",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
