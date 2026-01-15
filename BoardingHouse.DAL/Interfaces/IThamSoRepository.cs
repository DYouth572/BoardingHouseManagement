using System.Threading.Tasks;
using BoardingHouse.DAL.Entities;

namespace BoardingHouse.DAL.Interfaces
{
    public interface IThamSoRepository : IBaseRepository<ThamSo>
    {
        // Hàm lấy giá trị theo tên (VD: GetGiaTri("GIA_DIEN"))
        Task<decimal> GetGiaTriAsync(string tenThamSo);

        // Hàm cập nhật giá trị (VD: Sửa giá điện từ 3.500 lên 4.000)
        Task UpdateGiaTriAsync(string tenThamSo, decimal giaTriMoi);
    }
}