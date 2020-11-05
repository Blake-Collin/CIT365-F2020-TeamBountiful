﻿// <auto-generated />
using System;
using MegaDeskWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MegaDeskWeb.Migrations
{
    [DbContext(typeof(MegaDeskWebContext))]
    [Migration("20201105033018_7")]
    partial class _7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MegaDeskWeb.Models.Desk", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("deskDepth")
                        .HasColumnType("int");

                    b.Property<int>("deskWidth")
                        .HasColumnType("int");

                    b.Property<int>("materialID")
                        .HasColumnType("int");

                    b.Property<int>("numOfDrawers")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("materialID");

                    b.ToTable("Desk");
                });

            modelBuilder.Entity("MegaDeskWeb.Models.DeskMaterial", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeskMaterialName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DeskMaterialPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("DeskMaterial");
                });

            modelBuilder.Entity("MegaDeskWeb.Models.DeskQuote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RushShippingID")
                        .HasColumnType("int");

                    b.Property<DateTime>("completionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("customerName")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<int>("deskID")
                        .HasColumnType("int");

                    b.Property<int>("productionDays")
                        .HasColumnType("int");

                    b.Property<decimal>("quoteAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("RushShippingID");

                    b.HasIndex("deskID");

                    b.ToTable("DeskQuote");
                });

            modelBuilder.Entity("MegaDeskWeb.Models.RushShipping", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RushName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RushPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("RushShipping");
                });

            modelBuilder.Entity("MegaDeskWeb.Models.Desk", b =>
                {
                    b.HasOne("MegaDeskWeb.Models.DeskMaterial", "material")
                        .WithMany()
                        .HasForeignKey("materialID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MegaDeskWeb.Models.DeskQuote", b =>
                {
                    b.HasOne("MegaDeskWeb.Models.RushShipping", "RushShipping")
                        .WithMany()
                        .HasForeignKey("RushShippingID");

                    b.HasOne("MegaDeskWeb.Models.Desk", "desk")
                        .WithMany()
                        .HasForeignKey("deskID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
