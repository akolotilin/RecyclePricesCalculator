using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class BasePriceAddPartner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "BaseGoodPrices",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "BaseGoodPrices",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PartnerId",
                table: "BaseGoodPrices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseGoodPrices_PartnerId",
                table: "BaseGoodPrices",
                column: "PartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseGoodPrices_Partners_PartnerId",
                table: "BaseGoodPrices",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseGoodPrices_Partners_PartnerId",
                table: "BaseGoodPrices");

            migrationBuilder.DropIndex(
                name: "IX_BaseGoodPrices_PartnerId",
                table: "BaseGoodPrices");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "BaseGoodPrices");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "BaseGoodPrices");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "BaseGoodPrices");
        }
    }
}
