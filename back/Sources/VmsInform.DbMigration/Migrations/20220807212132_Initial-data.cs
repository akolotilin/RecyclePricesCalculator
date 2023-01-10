using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class Initialdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into price_types (\"IsTransit\", \"Name\") values(False, 'Розница')");
            migrationBuilder.Sql("insert into price_types (\"IsTransit\", \"Name\") values(False, 'Опт-1')");
            migrationBuilder.Sql("insert into price_types (\"IsTransit\", \"Name\") values(False, 'Опт-2')");
            migrationBuilder.Sql("insert into price_types (\"IsTransit\", \"Name\") values(False, 'VIP')");
            migrationBuilder.Sql("insert into price_types (\"IsTransit\", \"Name\") values(True, 'Транзит')");

            migrationBuilder.Sql("insert into users (\"EMail\", \"PasswordHash\", \"FullName\", \"IsActive\", \"IsAdmin\") values('admin@admin.ru', '21232f297a57a5a743894a0e4a801fc3', 'Admin', True, True)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
