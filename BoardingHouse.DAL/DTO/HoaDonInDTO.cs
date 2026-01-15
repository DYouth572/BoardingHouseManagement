namespace BoardingHouse.DAL.DTO
{
    public class HoaDonInDTO
    {
        public string TenPhong { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }

        // Phần Điện
        public int DienCu { get; set; }
        public int DienMoi { get; set; }
        public int DienTieuThu => DienMoi - DienCu;
        public decimal GiaDien { get; set; }
        public decimal ThanhTienDien { get; set; }

        // Phần Nước
        public int NuocCu { get; set; }
        public int NuocMoi { get; set; }
        public int NuocTieuThu => NuocMoi - NuocCu;
        public decimal GiaNuoc { get; set; }
        public decimal ThanhTienNuoc { get; set; }

        // Dịch vụ khác
        public decimal TienPhong { get; set; }
        public decimal TienDichVu { get; set; }
        public decimal TienMang { get; set; }

        public decimal TongTien { get; set; }
    }
}