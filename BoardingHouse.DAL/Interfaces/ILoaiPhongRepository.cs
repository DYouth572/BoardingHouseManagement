using System.Threading.Tasks;
using BoardingHouse.DAL.Entities;

namespace BoardingHouse.DAL.Interfaces
{
    public interface ILoaiPhongRepository : IBaseRepository<LoaiPhong>
    {
        // Kiểm tra loại phòng này có đang được sử dụng bởi phòng nào không?
        // (Để chặn không cho xóa nếu đang dùng)
        Task<bool> IsUsedAsync(int maLoai);
    }
}