﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VmsInform.DbMigration;

namespace VmsInform.DbMigration.Migrations
{
    [DbContext(typeof(DbMigrationContext))]
    [Migration("20200902214749_Add_PriceType_Description")]
    partial class Add_PriceType_Description
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VmsInform.DAL.Domain.BaseGoodPrice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CurrencyId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("GoodId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<long?>("PartnerId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(15,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("GoodId")
                        .IsUnique();

                    b.HasIndex("PartnerId");

                    b.ToTable("BaseGoodPrices");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.BaseGoodRule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Add")
                        .HasColumnType("decimal(10,2)");

                    b.Property<long>("BaseGoodId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Multiplier")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("BaseGoodId");

                    b.ToTable("BaseGoodRules");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.Currency", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<decimal>("ExchangeRate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(15,2)")
                        .HasDefaultValue(0m);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.Factory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Comment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<decimal>("Distance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(15,2)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("MaxGarbage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(15,2)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("MinGarbage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(15,2)")
                        .HasDefaultValue(0m);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Factories");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.GlobalSetting", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Domain")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Order")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.Good", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BaseGoodRuleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000)
                        .HasDefaultValue("");

                    b.Property<long>("GoodGroupId")
                        .HasColumnType("bigint");

                    b.Property<bool>("InputPriceManual")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("BaseGoodRuleId")
                        .IsUnique()
                        .HasFilter("[BaseGoodRuleId] IS NOT NULL");

                    b.HasIndex("GoodGroupId");

                    b.ToTable("Good");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.GoodGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("GoodGroups");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.GoodSurcharge", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("GoodId")
                        .HasColumnType("bigint");

                    b.Property<long>("PriceTypeId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Surcharge")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.HasIndex("GoodId");

                    b.HasIndex("PriceTypeId");

                    b.ToTable("GoodSurcharge");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.Partner", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13)
                        .HasDefaultValue("");

                    b.Property<string>("Comment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000)
                        .HasDefaultValue("");

                    b.Property<string>("Email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100)
                        .HasDefaultValue("");

                    b.Property<bool>("IsBuyer")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSeller")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastPricesUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("OfficePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skype")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100)
                        .HasDefaultValue("");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12)
                        .HasDefaultValue("");

                    b.Property<decimal>("TransportPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(15,2)")
                        .HasDefaultValue(0m);

                    b.Property<string>("Viber")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13)
                        .HasDefaultValue("");

                    b.Property<string>("WhatsApp")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13)
                        .HasDefaultValue("");

                    b.HasKey("Id");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.PartnerContact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContactType")
                        .HasColumnType("int");

                    b.Property<long>("PartnerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.ToTable("PartnerContacts");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.PartnerFactory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("FactoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("PartnerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FactoryId");

                    b.HasIndex("PartnerId");

                    b.ToTable("PartnerFactory");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.PartnerGoodsToSell", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CurrencyId")
                        .HasColumnType("bigint");

                    b.Property<long>("GoodId")
                        .HasColumnType("bigint");

                    b.Property<long>("PartnerId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(15,2)")
                        .HasDefaultValue(0m);

                    b.Property<DateTime>("ValidThru")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("GoodId");

                    b.HasIndex("PartnerId");

                    b.HasIndex("GoodId", "PartnerId")
                        .IsUnique();

                    b.ToTable("PartnerGoodsToSell");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.PartnerPriceType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("PartnerId")
                        .HasColumnType("bigint");

                    b.Property<long>("PriceTypeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.HasIndex("PriceTypeId");

                    b.ToTable("PartnerPriceType");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.PartnerShipmentAddress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<long>("PartnerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.ToTable("PartnerShipmentAddresses");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.PasswordRestoreRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PasswordRestoreRequests");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.Picture", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<long?>("ShipmentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ShipmentId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.PriceGoodOrder", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("GoodId")
                        .HasColumnType("bigint");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GoodId")
                        .IsUnique();

                    b.ToTable("PriceGoodOrder");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.PriceType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<bool>("IsTransit")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("PriceType");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.Shipment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LastEdit")
                        .HasColumnType("datetime2");

                    b.Property<long>("LastEditorId")
                        .HasColumnType("bigint");

                    b.Property<long>("PartnerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ShipmentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LastEditorId");

                    b.HasIndex("PartnerId");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAmin")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.HasKey("Id");

                    b.HasIndex("EMail")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.UserSession", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SessionKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("StartTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSessions");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.BaseGoodPrice", b =>
                {
                    b.HasOne("VmsInform.DAL.Domain.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.HasOne("VmsInform.DAL.Domain.Good", "Good")
                        .WithOne("BasePrice")
                        .HasForeignKey("VmsInform.DAL.Domain.BaseGoodPrice", "GoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VmsInform.DAL.Domain.Partner", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerId");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.BaseGoodRule", b =>
                {
                    b.HasOne("VmsInform.DAL.Domain.Good", "BaseGood")
                        .WithMany()
                        .HasForeignKey("BaseGoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.Good", b =>
                {
                    b.HasOne("VmsInform.DAL.Domain.BaseGoodRule", "BaseGoodRule")
                        .WithOne()
                        .HasForeignKey("VmsInform.DAL.Domain.Good", "BaseGoodRuleId");

                    b.HasOne("VmsInform.DAL.Domain.GoodGroup", "GoodGroup")
                        .WithMany("Goods")
                        .HasForeignKey("GoodGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.GoodGroup", b =>
                {
                    b.HasOne("VmsInform.DAL.Domain.GoodGroup", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.GoodSurcharge", b =>
                {
                    b.HasOne("VmsInform.DAL.Domain.Good", "Good")
                        .WithMany("GoodSurcharges")
                        .HasForeignKey("GoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VmsInform.DAL.Domain.PriceType", "PriceType")
                        .WithMany()
                        .HasForeignKey("PriceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.PartnerContact", b =>
                {
                    b.HasOne("VmsInform.DAL.Domain.Partner", "Partner")
                        .WithMany("Contacts")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.PartnerFactory", b =>
                {
                    b.HasOne("VmsInform.DAL.Domain.Factory", "Factory")
                        .WithMany("Partners")
                        .HasForeignKey("FactoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VmsInform.DAL.Domain.Partner", "Partner")
                        .WithMany("Factories")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.PartnerGoodsToSell", b =>
                {
                    b.HasOne("VmsInform.DAL.Domain.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VmsInform.DAL.Domain.Good", "Good")
                        .WithMany()
                        .HasForeignKey("GoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VmsInform.DAL.Domain.Partner", "Partner")
                        .WithMany("GoodsToSell")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.PartnerPriceType", b =>
                {
                    b.HasOne("VmsInform.DAL.Domain.Partner", "Partner")
                        .WithMany("PriceTypes")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VmsInform.DAL.Domain.PriceType", "PriceType")
                        .WithMany()
                        .HasForeignKey("PriceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.PartnerShipmentAddress", b =>
                {
                    b.HasOne("VmsInform.DAL.Domain.Partner", "Partner")
                        .WithMany("ShipmentAddresses")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.PasswordRestoreRequest", b =>
                {
                    b.HasOne("VmsInform.DAL.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.Picture", b =>
                {
                    b.HasOne("VmsInform.DAL.Domain.Shipment", null)
                        .WithMany("Pictures")
                        .HasForeignKey("ShipmentId");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.PriceGoodOrder", b =>
                {
                    b.HasOne("VmsInform.DAL.Domain.Good", "Good")
                        .WithOne()
                        .HasForeignKey("VmsInform.DAL.Domain.PriceGoodOrder", "GoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.Shipment", b =>
                {
                    b.HasOne("VmsInform.DAL.Domain.PartnerShipmentAddress", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VmsInform.DAL.Domain.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VmsInform.DAL.Domain.User", "LastEditor")
                        .WithMany()
                        .HasForeignKey("LastEditorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VmsInform.DAL.Domain.Partner", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.UserSession", b =>
                {
                    b.HasOne("VmsInform.DAL.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}