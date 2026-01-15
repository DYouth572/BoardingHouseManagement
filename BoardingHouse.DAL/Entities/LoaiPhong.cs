using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Lưu định nghĩa các loại phòng (VIP, Thường, Gác xép...) và đơn giá niêm yết
namespace BoardingHouse.DAL.Entities
{
    [Table("LoaiPhong")] // Định nghĩa tên bảng trong SQL Server
    public class LoaiPhong
    {
        public LoaiPhong()
        {
            // Khởi tạo danh sách để tránh lỗi NullReferenceException khi chưa có dữ liệu
            this.Phongs = new HashSet<Phong>();
        }

        [Key] // Khóa chính (Primary Key)
        public int MaLoai { get; set; }

        [Required] // Không được phép null (Not Null)
        [StringLength(50)] // Độ dài tối đa nvarchar(50)
        public string TenLoai { get; set; }

        public decimal DonGia { get; set; }

        // --- NAVIGATION PROPERTY (Quan hệ) ---
        // Một Loại phòng có nhiều Phòng (Quan hệ 1-n)        
        public virtual ICollection<Phong> Phongs { get; set; }
    }
}