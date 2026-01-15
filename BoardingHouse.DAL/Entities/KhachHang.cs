using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Hồ sơ khách thuê (Họ tên, CCCD, Quê quán, SĐT).
namespace BoardingHouse.DAL.Entities
{
    [Table("KhachHang")]
    public class KhachHang
    {
        public KhachHang()
        {
            this.HopDongs = new HashSet<HopDong>();
            this.ChiTietKhachOs = new HashSet<ChiTietKhachO>();
        }

        [Key]
        public int MaKhach { get; set; }

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(12)] // CCCD thường 12 số
        public string CCCD { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(200)]
        public string QueQuan { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        // Khách hàng có thể đứng tên nhiều hợp đồng (thuê nhiều phòng hoặc lịch sử thuê cũ)
        public virtual ICollection<HopDong> HopDongs { get; set; }

        // Khách hàng có thể nằm trong danh sách ở ghép của nhiều phòng
        public virtual ICollection<ChiTietKhachO> ChiTietKhachOs { get; set; }
    }
}