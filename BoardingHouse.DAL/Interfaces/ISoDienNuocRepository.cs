using System.Threading.Tasks;
using BoardingHouse.DAL.Entities;

namespace BoardingHouse.DAL.Interfaces
{
    public interface ISoDienNuocRepository : IBaseRepository<SoDienNuoc>
    {
        // Lấy chỉ số điện nước của tháng trước của phòng này
        // (Để tự động điền vào ô "Chỉ số cũ" khi ghi tháng mới)
        Task<SoDienNuoc> GetLastMonthUsageAsync(int maPhong);

        // Kiểm tra xem tháng này phòng đó đã ghi điện nước chưa (Tránh ghi 2 lần)
        Task<bool> CheckExistsAsync(int maPhong, int thang, int nam);
    }
}