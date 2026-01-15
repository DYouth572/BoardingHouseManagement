using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardingHouse.DAL.Entities
{
    [Table("ThamSo")]
    public class ThamSo
    {
        [Key]
        [StringLength(50)]
        public string TenThamSo { get; set; } // Ví dụ: GIA_DIEN

        public decimal GiaTri { get; set; }   // Ví dụ: 3500

        [StringLength(200)]
        public string MoTa { get; set; }
    }
}