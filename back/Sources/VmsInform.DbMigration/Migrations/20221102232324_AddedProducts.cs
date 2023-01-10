using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace VmsInform.DbMigration.Migrations
{
    public partial class AddedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true, defaultValue: ""),
                    Pictures = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "product_components_raw",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId1 = table.Column<long>(type: "bigint", nullable: true),
                    GoodId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_components_raw", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_components_raw_goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_components_raw_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_components_raw_products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_components_raw_GoodId",
                table: "product_components_raw",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_product_components_raw_ProductId",
                table: "product_components_raw",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_product_components_raw_ProductId1",
                table: "product_components_raw",
                column: "ProductId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_components_raw");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
