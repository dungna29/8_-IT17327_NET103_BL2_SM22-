﻿// <auto-generated />
using System;
using BAI_1_4_EFCORE_CODEFIRST.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BAI_1_4_EFCORE_CODEFIRST.Migrations
{
    [DbContext(typeof(FpolyDBContext))]
    [Migration("20220723100842_230722_FPOLY4")]
    partial class _230722_FPOLY4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BAI_1_4_EFCORE_CODEFIRST.DomainClass.PhimAnh", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_TheLoaiPhim")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MaPhim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("TheLoaiPhimsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TheLoaiPhimsId");

                    b.ToTable("PhimAnh");
                });

            modelBuilder.Entity("BAI_1_4_EFCORE_CODEFIRST.DomainClass.TheLoaiPhim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TheLoaiPhim");
                });

            modelBuilder.Entity("BAI_1_4_EFCORE_CODEFIRST.DomainClass.PhimAnh", b =>
                {
                    b.HasOne("BAI_1_4_EFCORE_CODEFIRST.DomainClass.TheLoaiPhim", "TheLoaiPhims")
                        .WithMany()
                        .HasForeignKey("TheLoaiPhimsId");

                    b.Navigation("TheLoaiPhims");
                });
#pragma warning restore 612, 618
        }
    }
}
