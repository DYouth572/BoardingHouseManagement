using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardingHouse.DAL.Entities
{
    [Table("HopDong")]
    public class HopDong
    {
        public HopDong()
        {
            // Một hợp đồng có thể có danh sách người ở ghép
            this.ChiTietKhachOs = new HashSet<ChiTietKhachO>();
        }

        [Key]
        public int MaHopDong { get; set; }

        public DateTime NgayBatDau { get; set; }

        // Cho phép Null (DateTime?) vì hợp đồng đang chạy có thể chưa chốt ngày đi thực tế
        public DateTime? NgayKetThuc { get; set; }

        public decimal TienCoc { get; set; }
   
        // Mục đích: Lưu giá phòng chốt tại thời điểm thuê
        public decimal GiaPhong { get; set; }
        // -------------------------------------

        public bool DaKetThuc { get; set; } // true: Đã thanh lý, false: Đang ở

        // --- KHÓA NGOẠI ---

        // 1. Liên kết với Phòng
        public int MaPhong { get; set; }
        [ForeignKey("MaPhong")]
        public virtual Phong Phong { get; set; }

        // 2. Liên kết với Khách hàng (Người đại diện ký hợp đồng)
        public int MaKhach { get; set; }
        [ForeignKey("MaKhach")]
        public virtual KhachHang KhachHang { get; set; }

        // --- QUAN HỆ ---
        public virtual ICollection<ChiTietKhachO> ChiTietKhachOs { get; set; }
    }
}