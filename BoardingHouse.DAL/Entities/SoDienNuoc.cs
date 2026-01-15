using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardingHouse.DAL.Entities
{
    [Table("SoDienNuoc")]
    public class SoDienNuoc
    {
        [Key]
        public int ID { get; set; }

        public int MaPhong { get; set; }
        [ForeignKey("MaPhong")]
        public virtual Phong Phong { get; set; }

        public int Thang { get; set; }
        public int Nam { get; set; }

        // Chỉ số điện
        public int ChiSoDienCu { get; set; }
        public int ChiSoDienMoi { get; set; }

        // Chỉ số nước (có thể là khối m3)
        public int ChiSoNuocCu { get; set; }
        public int ChiSoNuocMoi { get; set; }
    }
}