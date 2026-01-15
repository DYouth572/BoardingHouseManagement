using System;

namespace BoardingHouse.DAL.DTO
{
    public class HoaDonDTO
    {
        public int MaHoaDon { get; set; }
        public string TenPhong { get; set; }

        // Thay vì dùng string "Tháng 10/2023", ta tách ra số để dễ xử lý sau này
        public int Thang { get; set; }
        public int Nam { get; set; }

        public DateTime NgayLap { get; set; }

        // --- CÁC CỘT CHI TIẾT (Mới bổ sung) ---
        public decimal TienPhong { get; set; }
        public decimal TienDien { get; set; }
        public decimal TienNuoc { get; set; }
        public decimal TienDichVu { get; set; }
        public decimal TienMang { get; set; }

        // --- TỔNG KẾT ---
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; } // "Đã thanh toán" / "Chưa thanh toán"

        // Property phụ để hiển thị đẹp trên lưới (tùy chọn)
        public string ThoiGian => $"{Thang}/{Nam}";
    }
}