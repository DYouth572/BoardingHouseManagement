namespace BoardingHouse.DAL.DTO
{
    public class GhiDienNuocDTO
    {
        public int MaPhong { get; set; }
        public string TenPhong { get; set; }
        public decimal GiaPhong { get; set; }

        // Điện
        public int ChiSoDienCu { get; set; }
        public int ChiSoDienMoi { get; set; }
        public decimal GiaDien { get; set; }

        // Nước
        public int ChiSoNuocCu { get; set; }
        public int ChiSoNuocMoi { get; set; }
        public decimal GiaNuoc { get; set; }

        // Dịch vụ khác
        public decimal TienDichVu { get; set; }

        public decimal TienMang { get; set; }
    }
}