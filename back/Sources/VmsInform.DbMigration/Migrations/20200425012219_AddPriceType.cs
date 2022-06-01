using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class AddPriceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBuyer",
                table: "Partners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSeller",
                table: "Partners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPricesUpdateDate",
                table: "Partners",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PriceType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartnerPriceType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerId = table.Column<long>(nullable: false),
                    PriceTypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerPriceType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnerPriceType_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartnerPriceType_PriceType_PriceTypeId",
                        column: x => x.PriceTypeId,
                        principalTable: "PriceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartnerPriceType_PartnerId",
                table: "PartnerPriceType",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerPriceType_PriceTypeId",
                table: "PartnerPriceType",
                column: "PriceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnerPriceType");

            migrationBuilder.DropTable(
                name: "PriceType");

            migrationBuilder.DropColumn(
                name: "IsBuyer",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "IsSeller",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "LastPricesUpdateDate",
                table: "Partners");
        }
    }
}
