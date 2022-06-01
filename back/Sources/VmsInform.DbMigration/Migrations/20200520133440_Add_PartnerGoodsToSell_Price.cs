using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class Add_PartnerGoodsToSell_Price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "PartnerGoodsToSell",
                type: "decimal(15,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_PartnerGoodsToSell_GoodId",
                table: "PartnerGoodsToSell",
                column: "GoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PartnerGoodsToSell_GoodId",
                table: "PartnerGoodsToSell");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PartnerGoodsToSell");
        }
    }
}
