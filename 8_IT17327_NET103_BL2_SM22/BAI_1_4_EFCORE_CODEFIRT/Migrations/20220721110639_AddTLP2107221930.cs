using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BAI_1_4_EFCORE_CODEFIRT.Migrations
{
    public partial class AddTLP2107221930 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdTheLoaiPhim",
                table: "PhimAnh",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhimAnh_IdTheLoaiPhim",
                table: "PhimAnh",
                column: "IdTheLoaiPhim");

            migrationBuilder.AddForeignKey(
                name: "FK_PhimAnh_TheLoaiPhim_IdTheLoaiPhim",
                table: "PhimAnh",
                column: "IdTheLoaiPhim",
                principalTable: "TheLoaiPhim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhimAnh_TheLoaiPhim_IdTheLoaiPhim",
                table: "PhimAnh");

            migrationBuilder.DropIndex(
                name: "IX_PhimAnh_IdTheLoaiPhim",
                table: "PhimAnh");

            migrationBuilder.DropColumn(
                name: "IdTheLoaiPhim",
                table: "PhimAnh");
        }
    }
}
