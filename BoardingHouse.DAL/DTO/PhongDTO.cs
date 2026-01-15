using System;

namespace BoardingHouse.DAL.DTO
{
    public class PhongDTO
    {
        public int MaPhong { get; set; }
        public string TenPhong { get; set; }

        // Thay vì chứa object LoaiPhong, ta chỉ lấy cái tên để hiện lên Grid
        public string TenLoaiPhong { get; set; }

        public decimal DonGia { get; set; }
        public string TrangThai { get; set; } // Trống, Đang thuê
    }
}