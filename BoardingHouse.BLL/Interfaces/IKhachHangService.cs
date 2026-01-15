using System.Collections.Generic;
using System.Threading.Tasks;
using BoardingHouse.DAL.Entities;

namespace BoardingHouse.BLL.Interfaces
{
    public interface IKhachHangService
    {
        Task<List<KhachHang>> GetAllAsync();
        Task<List<KhachHang>> SearchAsync(string keyword);

        // Đổi tên các hàm này cho khớp với Form:
        Task AddAsync(KhachHang kh);      // Cũ: AddKhachHangAsync -> Mới: AddAsync
        Task UpdateAsync(KhachHang kh);   // Cũ: UpdateKhachHangAsync -> Mới: UpdateAsync
        Task DeleteAsync(int id);         // Cũ: DeleteKhachHangAsync -> Mới: DeleteAsync
    }
}