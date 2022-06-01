using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VmsInform.DbMigration.Migrations
{
    public partial class Goods_Add_Guid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "GoodGroups",
                nullable: false,
                defaultValueSql: "newid()");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Good",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Good",
                nullable: false,
                defaultValueSql: "newid()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "GoodGroups");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Good");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Good");
        }
    }
}
