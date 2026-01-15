using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardingHouse.DAL.Entities
{
    [Table("ChiTietHoaDon")]
    public class ChiTietHoaDon
    {
        [Key]
        public int ID { get; set; }

        public int MaHoaDon { get; set; }
        [ForeignKey("MaHoaDon")]
        public virtual HoaDon HoaDon { get; set; }

        // --- QUAN TRỌNG: Thay thế MaDV bằng TenDichVu ---
        // Khi tạo hóa đơn, bạn sẽ lấy tên từ bảng ThamSo (hoặc code) điền vào đây.
        // Ví dụ: "Tiền Điện", "Tiền Nước", "Tiền Phòng Tháng 10", "Tiền Rác"
        [Required]
        [StringLength(100)]
        public string TenDichVu { get; set; }

        public decimal SoLuong { get; set; } // Ví dụ: 25 (số điện), 1 (tháng tiền phòng)

        public decimal DonGia { get; set; } // Giá chốt tại thời điểm lập hóa đơn

        public decimal ThanhTien { get; set; } // = SoLuong * DonGia
    }
}