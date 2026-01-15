using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// quản trị viên - Dùng để đăng nhập phần mềm. 
namespace BoardingHouse.DAL.Entities
{
    [Table("NguoiDung")]
    public class NguoiDung
    {
        [Key]
        [StringLength(50)]
        public string UserName { get; set; } // Dùng Username làm khóa chính luôn

        [Required]
        [StringLength(100)]
        public string Password { get; set; } // Lưu mã hóa (MD5/BCrypt), không lưu text thường

        public bool IsAdmin { get; set; } // True: Admin, False: Nhân viên
    }
}