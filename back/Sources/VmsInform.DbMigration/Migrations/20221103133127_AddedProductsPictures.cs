using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace VmsInform.DbMigration.Migrations
{
    public partial class AddedProductsPictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pictures",
                table: "products");

            migrationBuilder.CreateTable(
                name: "product_pictures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    PictureId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_pictures_pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_pictures_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_pictures_PictureId",
                table: "product_pictures",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_product_pictures_ProductId",
                table: "product_pictures",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_pictures");

            migrationBuilder.AddColumn<string>(
                name: "Pictures",
                table: "products",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}
