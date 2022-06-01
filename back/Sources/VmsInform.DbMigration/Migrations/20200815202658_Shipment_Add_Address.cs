using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class Shipment_Add_Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AddressId",
                table: "Shipments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_AddressId",
                table: "Shipments",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_PartnerShipmentAddresses_AddressId",
                table: "Shipments",
                column: "AddressId",
                principalTable: "PartnerShipmentAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_PartnerShipmentAddresses_AddressId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_AddressId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Shipments");
        }
    }
}
