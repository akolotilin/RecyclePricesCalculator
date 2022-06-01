using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class GoodGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GoodGroupId",
                table: "Good",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "GoodGroups",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    ParentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodGroups_GoodGroups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "GoodGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Good_GoodGroupId",
                table: "Good",
                column: "GoodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodGroups_ParentId",
                table: "GoodGroups",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Good_GoodGroups_GoodGroupId",
                table: "Good",
                column: "GoodGroupId",
                principalTable: "GoodGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Good_GoodGroups_GoodGroupId",
                table: "Good");

            migrationBuilder.DropTable(
                name: "GoodGroups");

            migrationBuilder.DropIndex(
                name: "IX_Good_GoodGroupId",
                table: "Good");

            migrationBuilder.DropColumn(
                name: "GoodGroupId",
                table: "Good");
        }
    }
}
