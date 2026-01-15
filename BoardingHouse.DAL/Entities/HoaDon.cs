using System;
using System.Collections.Generic; // Cần thiết cho ICollection
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardingHouse.DAL.Entities
{
    [Table("HoaDon")]
    public class HoaDon
    {
        public HoaDon()
        {
            // Khởi tạo list để tránh lỗi Null Reference
            this.ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [Key]
        public int MaHoaDon { get; set; }

        public int MaPhong { get; set; }
        [ForeignKey("MaPhong")]
        public virtual Phong Phong { get; set; }

        public int Thang { get; set; }
        public int Nam { get; set; }
        public DateTime NgayLap { get; set; }

        public decimal TienPhong { get; set; }
        public decimal TienDien { get; set; }
        public decimal TienNuoc { get; set; }
        public decimal TienDichVu { get; set; }
        public decimal TienMang { get; set; }

        // --- ĐÃ SỬA: CHỈ LƯU TỔNG TIỀN ---
        // Các mục con (Điện, Nước, Phòng, Mạng...) đã chuyển sang bảng ChiTiet
        public decimal TongTien { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; } // "Chưa thanh toán", "Đã thanh toán"

        [StringLength(200)]
        public string GhiChu { get; set; } // Ghi chú thêm nếu cần (VD: Nợ cũ)

        // Quan hệ 1-n với chi tiết
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}