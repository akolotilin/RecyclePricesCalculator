using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class Add_Factory_To_BasePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FactoryId",
                table: "BaseGoodPrices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseGoodPrices_FactoryId",
                table: "BaseGoodPrices",
                column: "FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseGoodPrices_Factories_FactoryId",
                table: "BaseGoodPrices",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseGoodPrices_Factories_FactoryId",
                table: "BaseGoodPrices");

            migrationBuilder.DropIndex(
                name: "IX_BaseGoodPrices_FactoryId",
                table: "BaseGoodPrices");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "BaseGoodPrices");
        }
    }
}
