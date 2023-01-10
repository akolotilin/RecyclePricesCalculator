using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace VmsInform.DbMigration.Migrations
{
    public partial class AddedProductGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GroupId",
                table: "products",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "product_groups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_groups_product_groups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "product_groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_GroupId",
                table: "products",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_product_groups_ParentId",
                table: "product_groups",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_product_groups_GroupId",
                table: "products",
                column: "GroupId",
                principalTable: "product_groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_product_groups_GroupId",
                table: "products");

            migrationBuilder.DropTable(
                name: "product_groups");

            migrationBuilder.DropIndex(
                name: "IX_products_GroupId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "products");
        }
    }
}
