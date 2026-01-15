using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Lưu thông tin từng phòng (Số phòng, Trạng thái, thuộc Loại nào).
namespace BoardingHouse.DAL.Entities
{
    [Table("Phong")]
    public class Phong
    {
        public Phong()
        {
            this.HopDongs = new HashSet<HopDong>();
            this.SoDienNuocs = new HashSet<SoDienNuoc>();
            this.HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public int MaPhong { get; set; }

        [Required]
        [StringLength(50)]
        public string TenPhong { get; set; } // Ví dụ: P.101, P.202

        public decimal GiaPhong { get; set; }

        [StringLength(20)]
        public string TrangThai { get; set; } // "Trống", "Đang thuê", "Đang sửa"

        // --- KHÓA NGOẠI (Foreign Key) ---
        // Liên kết với bảng LoaiPhong
        public int MaLoai { get; set; }

        [ForeignKey("MaLoai")]
        public virtual LoaiPhong LoaiPhong { get; set; }

        // --- QUAN HỆ VỚI CÁC BẢNG KHÁC ---
        // Một phòng có thể có nhiều hợp đồng (theo lịch sử thời gian)
        public virtual ICollection<HopDong> HopDongs { get; set; }

        // Một phòng có nhiều tháng ghi điện nước
        public virtual ICollection<SoDienNuoc> SoDienNuocs { get; set; }

        // Một phòng có nhiều hóa đơn
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}