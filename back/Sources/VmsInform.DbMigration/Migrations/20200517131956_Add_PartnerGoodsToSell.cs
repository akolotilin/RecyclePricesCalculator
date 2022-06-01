using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class Add_PartnerGoodsToSell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartnerGoodsToSell",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerId = table.Column<long>(nullable: false),
                    GoodId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerGoodsToSell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnerGoodsToSell_Good_GoodId",
                        column: x => x.GoodId,
                        principalTable: "Good",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartnerGoodsToSell_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartnerGoodsToSell_PartnerId",
                table: "PartnerGoodsToSell",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerGoodsToSell_GoodId_PartnerId",
                table: "PartnerGoodsToSell",
                columns: new[] { "GoodId", "PartnerId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnerGoodsToSell");
        }
    }
}
