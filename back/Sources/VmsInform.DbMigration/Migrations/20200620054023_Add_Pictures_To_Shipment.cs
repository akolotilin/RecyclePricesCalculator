using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class Add_Pictures_To_Shipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ShipmentId",
                table: "Pictures",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ShipmentId",
                table: "Pictures",
                column: "ShipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Shipments_ShipmentId",
                table: "Pictures",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Shipments_ShipmentId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_ShipmentId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "ShipmentId",
                table: "Pictures");
        }
    }
}
