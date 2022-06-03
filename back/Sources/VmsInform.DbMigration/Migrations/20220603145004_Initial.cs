using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace VmsInform.DbMigration.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "currencies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(15,2)", nullable: false, defaultValue: 0m),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "factories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    MinGarbage = table.Column<decimal>(type: "decimal(15,2)", nullable: false, defaultValue: 0m),
                    MaxGarbage = table.Column<decimal>(type: "decimal(15,2)", nullable: false, defaultValue: 0m),
                    Distance = table.Column<decimal>(type: "decimal(15,2)", nullable: false, defaultValue: 0m),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "good_groups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    Guid = table.Column<string>(type: "varchar(36)", nullable: false),
                    Code = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_good_groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_good_groups_good_groups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "good_groups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "partners",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LastPricesUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Comment = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true, defaultValue: ""),
                    Address = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    IsSeller = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsBuyer = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TaxNumber = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false, defaultValue: ""),
                    CellPhone = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false, defaultValue: ""),
                    OfficePhone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    Viber = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false, defaultValue: ""),
                    WhatsApp = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false, defaultValue: ""),
                    Skype = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    TransportPrice = table.Column<decimal>(type: "decimal(15,2)", nullable: false, defaultValue: 0m),
                    UsePriceOffersByFactories = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    Name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "price_types",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IsTransit = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false, defaultValue: ""),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_price_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "settings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Value = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Order = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Domain = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EMail = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    FullName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "partner_contacts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ContactType = table.Column<int>(type: "int", nullable: false),
                    PartnerId = table.Column<long>(type: "bigint", nullable: false),
                    ContactData = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partner_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_partner_contacts_partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "partner_factory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PartnerId = table.Column<long>(type: "bigint", nullable: false),
                    FactoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partner_factory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_partner_factory_factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_partner_factory_partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "partner_shipment_addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PartnerId = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partner_shipment_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_partner_shipment_addresses_partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "partner_price_type",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PartnerId = table.Column<long>(type: "bigint", nullable: false),
                    PriceTypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partner_price_type", x => x.Id);
                    table.ForeignKey(
                        name: "FK_partner_price_type_partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_partner_price_type_price_types_PriceTypeId",
                        column: x => x.PriceTypeId,
                        principalTable: "price_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    IsImportant = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsPublished = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news", x => x.Id);
                    table.ForeignKey(
                        name: "FK_news_users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "password_restore_requests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Key = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    IsClosed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_password_restore_requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_password_restore_requests_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shipments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LastEditorId = table.Column<long>(type: "bigint", nullable: false),
                    LastEdit = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    ShipmentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    PartnerId = table.Column<long>(type: "bigint", nullable: false),
                    FactoryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shipments_factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shipments_partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shipments_users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shipments_users_LastEditorId",
                        column: x => x.LastEditorId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_sessions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    SessionKey = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_sessions_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_notifications",
                columns: table => new
                {
                    UserNotificationid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Subject = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    IsRead = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsImportant = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    NewsId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_notifications", x => x.UserNotificationid);
                    table.ForeignKey(
                        name: "FK_user_notifications_news_NewsId",
                        column: x => x.NewsId,
                        principalTable: "news",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_notifications_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pictures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<byte[]>(type: "varbinary(4000)", nullable: false),
                    ShipmentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pictures_shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "goods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    GoodGroupId = table.Column<long>(type: "bigint", nullable: false),
                    Comment = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true, defaultValue: ""),
                    InputPriceManual = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BaseGoodRuleId = table.Column<long>(type: "bigint", nullable: true),
                    Guid = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Code = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_goods_good_groups_GoodGroupId",
                        column: x => x.GoodGroupId,
                        principalTable: "good_groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "base_good_gules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BaseGoodId = table.Column<long>(type: "bigint", nullable: false),
                    Multiplier = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Add = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_base_good_gules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_base_good_gules_goods_BaseGoodId",
                        column: x => x.BaseGoodId,
                        principalTable: "goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "base_good_prices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    GoodId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(15,2)", nullable: false, defaultValue: 0m),
                    PartnerId = table.Column<long>(type: "bigint", nullable: true),
                    FactoryId = table.Column<long>(type: "bigint", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_base_good_prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_base_good_prices_currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_base_good_prices_factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_base_good_prices_goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_base_good_prices_partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "good_surcharge",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    GoodId = table.Column<long>(type: "bigint", nullable: false),
                    PriceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Surcharge = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_good_surcharge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_good_surcharge_goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_good_surcharge_price_types_PriceTypeId",
                        column: x => x.PriceTypeId,
                        principalTable: "price_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "partner_goods_to_sell",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PartnerId = table.Column<long>(type: "bigint", nullable: false),
                    FactoryId = table.Column<long>(type: "bigint", nullable: true),
                    GoodId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false, defaultValue: 0m),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    ValidThru = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partner_goods_to_sell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_partner_goods_to_sell_currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_partner_goods_to_sell_factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_partner_goods_to_sell_goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_partner_goods_to_sell_partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "price_good_order",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    GoodId = table.Column<long>(type: "bigint", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_price_good_order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_price_good_order_goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "price_goods_visibility",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    GoodId = table.Column<long>(type: "bigint", nullable: false),
                    IsVisible = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_price_goods_visibility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_price_goods_visibility_goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_base_good_gules_BaseGoodId",
                table: "base_good_gules",
                column: "BaseGoodId");

            migrationBuilder.CreateIndex(
                name: "IX_base_good_prices_CurrencyId",
                table: "base_good_prices",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_base_good_prices_FactoryId",
                table: "base_good_prices",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_base_good_prices_GoodId",
                table: "base_good_prices",
                column: "GoodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_base_good_prices_PartnerId",
                table: "base_good_prices",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_good_groups_ParentId",
                table: "good_groups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_good_surcharge_GoodId",
                table: "good_surcharge",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_good_surcharge_PriceTypeId",
                table: "good_surcharge",
                column: "PriceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_goods_BaseGoodRuleId",
                table: "goods",
                column: "BaseGoodRuleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_goods_GoodGroupId",
                table: "goods",
                column: "GoodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_news_AuthorId",
                table: "news",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_partner_contacts_PartnerId",
                table: "partner_contacts",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_partner_factory_FactoryId",
                table: "partner_factory",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_partner_factory_PartnerId",
                table: "partner_factory",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_partner_goods_to_sell_CurrencyId",
                table: "partner_goods_to_sell",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_partner_goods_to_sell_FactoryId",
                table: "partner_goods_to_sell",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_partner_goods_to_sell_GoodId",
                table: "partner_goods_to_sell",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_partner_goods_to_sell_GoodId_PartnerId_FactoryId",
                table: "partner_goods_to_sell",
                columns: new[] { "GoodId", "PartnerId", "FactoryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_partner_goods_to_sell_PartnerId",
                table: "partner_goods_to_sell",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_partner_price_type_PartnerId",
                table: "partner_price_type",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_partner_price_type_PriceTypeId",
                table: "partner_price_type",
                column: "PriceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_partner_shipment_addresses_PartnerId",
                table: "partner_shipment_addresses",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_password_restore_requests_UserId",
                table: "password_restore_requests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_pictures_ShipmentId",
                table: "pictures",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_price_good_order_GoodId",
                table: "price_good_order",
                column: "GoodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_price_goods_visibility_GoodId",
                table: "price_goods_visibility",
                column: "GoodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_settings_Name",
                table: "settings",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shipments_CreatorId",
                table: "shipments",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_shipments_FactoryId",
                table: "shipments",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_shipments_LastEditorId",
                table: "shipments",
                column: "LastEditorId");

            migrationBuilder.CreateIndex(
                name: "IX_shipments_PartnerId",
                table: "shipments",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_user_notifications_NewsId",
                table: "user_notifications",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_user_notifications_UserId",
                table: "user_notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_sessions_UserId",
                table: "user_sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_EMail",
                table: "users",
                column: "EMail",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_goods_base_good_gules_BaseGoodRuleId",
                table: "goods",
                column: "BaseGoodRuleId",
                principalTable: "base_good_gules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_base_good_gules_goods_BaseGoodId",
                table: "base_good_gules");

            migrationBuilder.DropTable(
                name: "base_good_prices");

            migrationBuilder.DropTable(
                name: "good_surcharge");

            migrationBuilder.DropTable(
                name: "partner_contacts");

            migrationBuilder.DropTable(
                name: "partner_factory");

            migrationBuilder.DropTable(
                name: "partner_goods_to_sell");

            migrationBuilder.DropTable(
                name: "partner_price_type");

            migrationBuilder.DropTable(
                name: "partner_shipment_addresses");

            migrationBuilder.DropTable(
                name: "password_restore_requests");

            migrationBuilder.DropTable(
                name: "pictures");

            migrationBuilder.DropTable(
                name: "price_good_order");

            migrationBuilder.DropTable(
                name: "price_goods_visibility");

            migrationBuilder.DropTable(
                name: "settings");

            migrationBuilder.DropTable(
                name: "user_notifications");

            migrationBuilder.DropTable(
                name: "user_sessions");

            migrationBuilder.DropTable(
                name: "currencies");

            migrationBuilder.DropTable(
                name: "price_types");

            migrationBuilder.DropTable(
                name: "shipments");

            migrationBuilder.DropTable(
                name: "news");

            migrationBuilder.DropTable(
                name: "factories");

            migrationBuilder.DropTable(
                name: "partners");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "goods");

            migrationBuilder.DropTable(
                name: "base_good_gules");

            migrationBuilder.DropTable(
                name: "good_groups");
        }
    }
}
