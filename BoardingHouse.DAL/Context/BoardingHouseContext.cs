using BoardingHouse.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BoardingHouse.DAL.Context
{
    public class BoardingHouseContext : DbContext
    {
        public BoardingHouseContext()
        {
        }

        public BoardingHouseContext(DbContextOptions<BoardingHouseContext> options)
            : base(options)
        {
        }

        // --- KHAI BÁO CÁC BẢNG (DbSet) ---
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<HopDong> HopDongs { get; set; }
        public virtual DbSet<ChiTietKhachO> ChiTietKhachOs { get; set; }
        public virtual DbSet<SoDienNuoc> SoDienNuocs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<ThamSo> ThamSos { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Giữ nguyên server của bạn
                optionsBuilder.UseSqlServer("Data Source=HULI;Initial Catalog=QLNhaTro;Integrated Security=True;TrustServerCertificate=True");
            }
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- 1. CẤU HÌNH KIỂU DỮ LIỆU ---

            // Tiền tệ (VND) -> decimal(18,0) 
            modelBuilder.Entity<LoaiPhong>().Property(p => p.DonGia).HasColumnType("decimal(18,0)");
            modelBuilder.Entity<HopDong>().Property(p => p.TienCoc).HasColumnType("decimal(18,0)");
            modelBuilder.Entity<HoaDon>().Property(p => p.TongTien).HasColumnType("decimal(18,0)");

            // Chi tiết hóa đơn
            modelBuilder.Entity<ChiTietHoaDon>().Property(p => p.DonGia).HasColumnType("decimal(18,0)");
            modelBuilder.Entity<ChiTietHoaDon>().Property(p => p.ThanhTien).HasColumnType("decimal(18,0)");

            // [QUAN TRỌNG] Số lượng nên để có số lẻ (ví dụ 1.5 khối nước)
            modelBuilder.Entity<ChiTietHoaDon>().Property(p => p.SoLuong).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<ThamSo>().Property(p => p.GiaTri).HasColumnType("decimal(18,0)");

            // --- 2. CẤU HÌNH QUAN HỆ (Fluent API) ---

            // Quan hệ Phòng - Loại Phòng
            modelBuilder.Entity<Phong>()
                .HasOne(p => p.LoaiPhong)
                .WithMany(lp => lp.Phongs)
                .HasForeignKey(p => p.MaLoai)
                .OnDelete(DeleteBehavior.Restrict);

            // Quan hệ Hợp đồng - Phòng
            modelBuilder.Entity<HopDong>()
                .HasOne(h => h.Phong)
                .WithMany(p => p.HopDongs)
                .HasForeignKey(h => h.MaPhong)
                .OnDelete(DeleteBehavior.Restrict);

            // Quan hệ Hợp đồng - Khách hàng
            modelBuilder.Entity<HopDong>()
                .HasOne(h => h.KhachHang)
                .WithMany(kh => kh.HopDongs)
                .HasForeignKey(h => h.MaKhach)
                .OnDelete(DeleteBehavior.Restrict);

            // Quan hệ Hóa đơn - Phòng (Bổ sung để chặt chẽ)
            modelBuilder.Entity<HoaDon>()
                .HasOne(hd => hd.Phong)
                .WithMany(p => p.HoaDons)
                .HasForeignKey(hd => hd.MaPhong)
                .OnDelete(DeleteBehavior.Restrict);

            // --- 3. SEED DATA (Nạp dữ liệu cho ThamSo) --
            modelBuilder.Entity<ThamSo>().HasData(
                new ThamSo { TenThamSo = "GIA_DIEN", GiaTri = 3500, MoTa = "Giá điện (đ/kwh)" },
                new ThamSo { TenThamSo = "GIA_NUOC", GiaTri = 15000, MoTa = "Giá nước (đ/m3)" },
                new ThamSo { TenThamSo = "GIA_DICH_VU", GiaTri = 100000, MoTa = "Dịch vụ chung (Rác, vệ sinh)" },
                new ThamSo { TenThamSo = "GIA_MANG", GiaTri = 50000, MoTa = "Tiền Wifi/Internet" }
            );
        }
    }
}