using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class Add_Factory_To_Offers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PartnerGoodsToSell_GoodId_PartnerId",
                table: "PartnerGoodsToSell");

            migrationBuilder.AddColumn<long>(
                name: "FactoryId",
                table: "PartnerGoodsToSell",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartnerGoodsToSell_FactoryId",
                table: "PartnerGoodsToSell",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerGoodsToSell_GoodId_PartnerId_FactoryId",
                table: "PartnerGoodsToSell",
                columns: new[] { "GoodId", "PartnerId", "FactoryId" },
                unique: true,
                filter: "[FactoryId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PartnerGoodsToSell_Factories_FactoryId",
                table: "PartnerGoodsToSell",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartnerGoodsToSell_Factories_FactoryId",
                table: "PartnerGoodsToSell");

            migrationBuilder.DropIndex(
                name: "IX_PartnerGoodsToSell_FactoryId",
                table: "PartnerGoodsToSell");

            migrationBuilder.DropIndex(
                name: "IX_PartnerGoodsToSell_GoodId_PartnerId_FactoryId",
                table: "PartnerGoodsToSell");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "PartnerGoodsToSell");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerGoodsToSell_GoodId_PartnerId",
                table: "PartnerGoodsToSell",
                columns: new[] { "GoodId", "PartnerId" },
                unique: true);
        }
    }
}
