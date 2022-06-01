using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class Add_Shipments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastEditorId = table.Column<long>(nullable: false),
                    LastEdit = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<long>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    ShipmentDate = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipments_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipments_Users_LastEditorId",
                        column: x => x.LastEditorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_CreatorId",
                table: "Shipments",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_LastEditorId",
                table: "Shipments",
                column: "LastEditorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shipments");
        }
    }
}
