using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class Add_Factory_To_Shipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<long>(
                name: "FactoryId",
                table: "Shipments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_FactoryId",
                table: "Shipments",
                column: "FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Factories_FactoryId",
                table: "Shipments",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Factories_FactoryId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_FactoryId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "Shipments");

            migrationBuilder.AddColumn<long>(
                name: "AddressId",
                table: "Shipments",
                type: "bigint",
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
    }
}
