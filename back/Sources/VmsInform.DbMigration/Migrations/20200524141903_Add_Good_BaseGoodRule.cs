using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class Add_Good_BaseGoodRule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BaseGoodRuleId",
                table: "Good",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BaseGoodRules",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseGoodId = table.Column<long>(nullable: false),
                    Multiplier = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Add = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseGoodRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseGoodRules_Good_BaseGoodId",
                        column: x => x.BaseGoodId,
                        principalTable: "Good",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Good_BaseGoodRuleId",
                table: "Good",
                column: "BaseGoodRuleId",
                unique: true,
                filter: "[BaseGoodRuleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BaseGoodRules_BaseGoodId",
                table: "BaseGoodRules",
                column: "BaseGoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Good_BaseGoodRules_BaseGoodRuleId",
                table: "Good",
                column: "BaseGoodRuleId",
                principalTable: "BaseGoodRules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Good_BaseGoodRules_BaseGoodRuleId",
                table: "Good");

            migrationBuilder.DropTable(
                name: "BaseGoodRules");

            migrationBuilder.DropIndex(
                name: "IX_Good_BaseGoodRuleId",
                table: "Good");

            migrationBuilder.DropColumn(
                name: "BaseGoodRuleId",
                table: "Good");
        }
    }
}
