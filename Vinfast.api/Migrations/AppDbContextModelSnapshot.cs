﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vinfast.api.Models;

namespace Vinfast.api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vinfast.models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<int?>("VersionId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("VersionId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "LUX A2.0",
                            PhotoPath = "image/a20.png",
                            Price = 800000000L
                        },
                        new
                        {
                            ProductId = 2,
                            Name = "LUX SA2.0",
                            PhotoPath = "image/sa20.png",
                            Price = 1200000000L
                        },
                        new
                        {
                            ProductId = 3,
                            Name = "Fadil",
                            PhotoPath = "image/fadil.png",
                            Price = 362000000L
                        },
                        new
                        {
                            ProductId = 4,
                            Name = "President",
                            PhotoPath = "image/president.png",
                            Price = 3800000000L
                        });
                });

            modelBuilder.Entity("Vinfast.models.version", b =>
                {
                    b.Property<int>("VersionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VersionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VersionId");

                    b.ToTable("versions");

                    b.HasData(
                        new
                        {
                            VersionId = 1,
                            VersionName = "Tiêu Chuẩn"
                        },
                        new
                        {
                            VersionId = 2,
                            VersionName = "Nâng Cao"
                        },
                        new
                        {
                            VersionId = 3,
                            VersionName = "Cao Cấp"
                        });
                });

            modelBuilder.Entity("Vinfast.models.Product", b =>
                {
                    b.HasOne("Vinfast.models.version", "version")
                        .WithMany()
                        .HasForeignKey("VersionId");

                    b.Navigation("version");
                });
#pragma warning restore 612, 618
        }
    }
}
