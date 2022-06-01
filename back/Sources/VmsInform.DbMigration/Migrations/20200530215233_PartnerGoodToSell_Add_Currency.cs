using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class PartnerGoodToSell_Add_Currency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CurrencyId",
                table: "PartnerGoodsToSell",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartnerGoodsToSell_CurrencyId",
                table: "PartnerGoodsToSell",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartnerGoodsToSell_Currencies_CurrencyId",
                table: "PartnerGoodsToSell",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql(@"
            if not exists (select top 1 * from Currencies where Code='RUR')
            insert into Currencies values ('Рубли','RUR', 1)
            if not exists (select top 1 * from Currencies where Code='USD')
            insert into Currencies values ('Доллары','USD', 1)
            if not exists (select top 1 * from Currencies where Code='EUR')
            insert into Currencies values ('Евро','EUR', 1)
            declare @rurId bigint
            select @rurId=Id from Currencies where Code = 'RUR'
            update PartnerGoodsToSell set CurrencyId=@rurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartnerGoodsToSell_Currencies_CurrencyId",
                table: "PartnerGoodsToSell");

            migrationBuilder.DropIndex(
                name: "IX_PartnerGoodsToSell_CurrencyId",
                table: "PartnerGoodsToSell");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "PartnerGoodsToSell");
        }
    }
}
