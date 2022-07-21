using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BAI_1_4_EFCORE_CODEFIRT.Migrations
{
    public partial class CreateDB2107221730 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhimAnh",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenPhim = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaPhim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheLoaiPhim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhimAnh", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhimAnh");
        }
    }
}
