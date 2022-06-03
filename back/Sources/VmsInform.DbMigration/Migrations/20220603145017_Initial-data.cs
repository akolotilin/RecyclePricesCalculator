using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class Initialdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into price_types (IsTransit, Name) values(0, 'Розница')");
            migrationBuilder.Sql("insert into price_types (IsTransit, Name) values(0, 'Опт-1')");
            migrationBuilder.Sql("insert into price_types (IsTransit, Name) values(0, 'Опт-2')");
            migrationBuilder.Sql("insert into price_types (IsTransit, Name) values(0, 'VIP')");
            migrationBuilder.Sql("insert into price_types (IsTransit, Name) values(1, 'Транзит')");

            migrationBuilder.Sql("insert into users (EMail, PasswordHash, FullName, IsActive, IsAdmin) values('admin@admin.ru', 'c4ca4238a0b923820dcc509a6f75849b', 'Admin', 1, 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
