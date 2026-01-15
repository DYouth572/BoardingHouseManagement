using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoardingHouse.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKhach = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    QueQuan = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKhach);
                });

            migrationBuilder.CreateTable(
                name: "LoaiPhong",
                columns: table => new
                {
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiPhong", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "ThamSo",
                columns: table => new
                {
                    TenThamSo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GiaTri = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThamSo", x => x.TenThamSo);
                });

            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    MaPhong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GiaPhong = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.MaPhong);
                    table.ForeignKey(
                        name: "FK_Phong_LoaiPhong_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "LoaiPhong",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    MaHoaDon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhong = table.Column<int>(type: "int", nullable: false),
                    Thang = table.Column<int>(type: "int", nullable: false),
                    Nam = table.Column<int>(type: "int", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TienPhong = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TienDien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TienNuoc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TienDichVu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TienMang = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.MaHoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDon_Phong_MaPhong",
                        column: x => x.MaPhong,
                        principalTable: "Phong",
                        principalColumn: "MaPhong",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HopDong",
                columns: table => new
                {
                    MaHopDong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TienCoc = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    GiaPhong = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DaKetThuc = table.Column<bool>(type: "bit", nullable: false),
                    MaPhong = table.Column<int>(type: "int", nullable: false),
                    MaKhach = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong", x => x.MaHopDong);
                    table.ForeignKey(
                        name: "FK_HopDong_KhachHang_MaKhach",
                        column: x => x.MaKhach,
                        principalTable: "KhachHang",
                        principalColumn: "MaKhach",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HopDong_Phong_MaPhong",
                        column: x => x.MaPhong,
                        principalTable: "Phong",
                        principalColumn: "MaPhong",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SoDienNuoc",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhong = table.Column<int>(type: "int", nullable: false),
                    Thang = table.Column<int>(type: "int", nullable: false),
                    Nam = table.Column<int>(type: "int", nullable: false),
                    ChiSoDienCu = table.Column<int>(type: "int", nullable: false),
                    ChiSoDienMoi = table.Column<int>(type: "int", nullable: false),
                    ChiSoNuocCu = table.Column<int>(type: "int", nullable: false),
                    ChiSoNuocMoi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoDienNuoc", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SoDienNuoc_Phong_MaPhong",
                        column: x => x.MaPhong,
                        principalTable: "Phong",
                        principalColumn: "MaPhong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHoaDon = table.Column<int>(type: "int", nullable: false),
                    TenDichVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoLuong = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDon", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_HoaDon_MaHoaDon",
                        column: x => x.MaHoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "MaHoaDon",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietKhachO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHopDong = table.Column<int>(type: "int", nullable: false),
                    MaKhach = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietKhachO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChiTietKhachO_HopDong_MaHopDong",
                        column: x => x.MaHopDong,
                        principalTable: "HopDong",
                        principalColumn: "MaHopDong",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietKhachO_KhachHang_MaKhach",
                        column: x => x.MaKhach,
                        principalTable: "KhachHang",
                        principalColumn: "MaKhach",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ThamSo",
                columns: new[] { "TenThamSo", "GiaTri", "MoTa" },
                values: new object[,]
                {
                    { "GIA_DICH_VU", 100000m, "Dịch vụ chung (Rác, vệ sinh)" },
                    { "GIA_DIEN", 3500m, "Giá điện (đ/kwh)" },
                    { "GIA_MANG", 50000m, "Tiền Wifi/Internet" },
                    { "GIA_NUOC", 15000m, "Giá nước (đ/m3)" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_MaHoaDon",
                table: "ChiTietHoaDon",
                column: "MaHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKhachO_MaHopDong",
                table: "ChiTietKhachO",
                column: "MaHopDong");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKhachO_MaKhach",
                table: "ChiTietKhachO",
                column: "MaKhach");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaPhong",
                table: "HoaDon",
                column: "MaPhong");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_MaKhach",
                table: "HopDong",
                column: "MaKhach");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_MaPhong",
                table: "HopDong",
                column: "MaPhong");

            migrationBuilder.CreateIndex(
                name: "IX_Phong_MaLoai",
                table: "Phong",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_SoDienNuoc_MaPhong",
                table: "SoDienNuoc",
                column: "MaPhong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "ChiTietKhachO");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "SoDienNuoc");

            migrationBuilder.DropTable(
                name: "ThamSo");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "HopDong");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "Phong");

            migrationBuilder.DropTable(
                name: "LoaiPhong");
        }
    }
}
