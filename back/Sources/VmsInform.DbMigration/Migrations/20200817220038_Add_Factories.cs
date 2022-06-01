using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class Add_Factories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: false),
                    MinGarbage = table.Column<decimal>(type: "decimal(15,2)", nullable: false, defaultValue: 0m),
                    MaxGarbage = table.Column<decimal>(type: "decimal(15,2)", nullable: false, defaultValue: 0m),
                    Distance = table.Column<decimal>(type: "decimal(15,2)", nullable: false, defaultValue: 0m),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartnerFactory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerId = table.Column<long>(nullable: false),
                    FactoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerFactory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnerFactory_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartnerFactory_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartnerFactory_FactoryId",
                table: "PartnerFactory",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerFactory_PartnerId",
                table: "PartnerFactory",
                column: "PartnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnerFactory");

            migrationBuilder.DropTable(
                name: "Factories");
        }
    }
}
