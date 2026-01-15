using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Một phòng có nhiều người, nhưng chỉ 1 người đứng tên hợp đồng.
// Bảng này lưu những người "ở ké" (bạn cùng phòng, vợ chồng...).
namespace BoardingHouse.DAL.Entities
{
    [Table("ChiTietKhachO")]
    public class ChiTietKhachO
    {
        [Key]
        public int ID { get; set; } // Khóa chính tự tăng

        // Thuộc về hợp đồng nào?
        public int MaHopDong { get; set; }
        [ForeignKey("MaHopDong")]
        public virtual HopDong HopDong { get; set; }

        // Là khách hàng nào?
        public int MaKhach { get; set; }
        [ForeignKey("MaKhach")]
        public virtual KhachHang KhachHang { get; set; }

        // Có thể thêm: Ngày đăng ký tạm trú, quan hệ với chủ hộ...
    }
}