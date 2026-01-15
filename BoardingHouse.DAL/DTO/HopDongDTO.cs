using System;

namespace BoardingHouse.DAL.DTO
{
    public class HopDongDTO
    {
        public int MaHopDong { get; set; }

        public string TenPhong { get; set; }
        public string TenKhachHang { get; set; }
        public string SDT { get; set; }

        // --- BỔ SUNG TRƯỜNG NÀY ---
        public decimal GiaPhong { get; set; }
        // --------------------------

        public decimal TienCoc { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public bool DaKetThuc { get; set; }

        // Logic hiển thị trạng thái (Giữ nguyên logic thông minh của bạn)
        public string TrangThaiHienThi => (NgayKetThuc.HasValue && NgayKetThuc.Value <= DateTime.Now) || DaKetThuc
                                          ? "Đã kết thúc"
                                          : "Đang hiệu lực";
    }
}