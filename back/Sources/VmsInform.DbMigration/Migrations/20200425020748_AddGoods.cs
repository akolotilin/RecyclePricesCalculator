using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class AddGoods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Good",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Comment = table.Column<string>(maxLength: 1000, nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Good", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoodSurcharge",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodId = table.Column<long>(nullable: false),
                    PriceTypeId = table.Column<long>(nullable: false),
                    Surcharge = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodSurcharge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodSurcharge_Good_GoodId",
                        column: x => x.GoodId,
                        principalTable: "Good",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodSurcharge_PriceType_PriceTypeId",
                        column: x => x.PriceTypeId,
                        principalTable: "PriceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodSurcharge_GoodId",
                table: "GoodSurcharge",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodSurcharge_PriceTypeId",
                table: "GoodSurcharge",
                column: "PriceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodSurcharge");

            migrationBuilder.DropTable(
                name: "Good");
        }
    }
}
