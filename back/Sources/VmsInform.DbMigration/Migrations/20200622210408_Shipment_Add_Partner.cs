using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class Shipment_Add_Partner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PartnerId",
                table: "Shipments",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_PartnerId",
                table: "Shipments",
                column: "PartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Partners_PartnerId",
                table: "Shipments",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Partners_PartnerId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_PartnerId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "Shipments");
        }
    }
}
