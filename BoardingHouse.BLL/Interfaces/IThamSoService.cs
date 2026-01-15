using System.Threading.Tasks;

namespace BoardingHouse.BLL.Interfaces
{
    public interface IThamSoService
    {
        // Lấy giá trị cấu hình (VD: lấy giá điện hiện tại để hiển thị lên form)
        Task<decimal> GetGiaTriAsync(string tenThamSo);

        // Cập nhật giá mới (VD: Giá điện tăng lên 4000đ)
        Task UpdateGiaTriAsync(string tenThamSo, decimal giaTriMoi);
    }
}