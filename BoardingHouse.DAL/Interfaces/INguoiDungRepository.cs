using System.Threading.Tasks;
using BoardingHouse.DAL.Entities;

namespace BoardingHouse.DAL.Interfaces
{
    public interface INguoiDungRepository : IBaseRepository<NguoiDung>
    {
        // Kiểm tra xem username đã tồn tại chưa (khi tạo user mới)
        Task<bool> ExistsAsync(string username);

        // Lấy thông tin user kèm mật khẩu để check đăng nhập
        Task<NguoiDung> GetByUsernameAsync(string username);
    }
}