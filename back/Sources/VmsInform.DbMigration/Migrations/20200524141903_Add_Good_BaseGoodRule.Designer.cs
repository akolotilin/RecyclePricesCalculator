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
    [Migration("20200524141903_Add_Good_BaseGoodRule")]
    partial class Add_Good_BaseGoodRule
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

            modelBuilder.Entity("VmsInform.DAL.Domain.PartnerGoodsToSell", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("VmsInform.DAL.Domain.PriceType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("PriceType");
                });

            modelBuilder.Entity("VmsInform.DAL.Domain.BaseGoodPrice", b =>
                {
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

            modelBuilder.Entity("VmsInform.DAL.Domain.PartnerGoodsToSell", b =>
                {
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
#pragma warning restore 612, 618
        }
    }
}