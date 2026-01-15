using BoardingHouse.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardingHouse.DAL.Interfaces
{
    public interface IKhachHangRepository : IBaseRepository<KhachHang>
    {
        // Hàm lấy theo CCCD (giữ nguyên nếu cần)
        Task<KhachHang> GetByCCCDAsync(string cccd);

        // --- SỬA TÊN TẠI ĐÂY: SearchByNameAsync -> SearchAsync ---
        // Để khớp với Repository và Service
        Task<List<KhachHang>> SearchAsync(string keyword);

        // --- THÊM HÀM NÀY ---
        // Để khớp với hàm UpdateSafeAsync bạn vừa thêm vào Repository
        Task UpdateSafeAsync(KhachHang entity);
    }
}