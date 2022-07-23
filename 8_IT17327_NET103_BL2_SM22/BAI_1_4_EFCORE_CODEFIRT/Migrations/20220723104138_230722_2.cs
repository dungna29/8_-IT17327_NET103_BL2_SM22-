﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BAI_1_4_EFCORE_CODEFIRT.Migrations
{
    public partial class _230722_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TheLoaiPhim",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoaiPhim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhimAnh",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenPhim = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaPhim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    TheLoaiPhimId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhimAnh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhimAnh_TheLoaiPhim_TheLoaiPhimId",
                        column: x => x.TheLoaiPhimId,
                        principalTable: "TheLoaiPhim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhimAnh_TheLoaiPhimId",
                table: "PhimAnh",
                column: "TheLoaiPhimId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhimAnh");

            migrationBuilder.DropTable(
                name: "TheLoaiPhim");
        }
    }
}
