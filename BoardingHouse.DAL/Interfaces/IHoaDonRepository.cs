using System.Collections.Generic;
using System.Threading.Tasks;
using BoardingHouse.DAL.Entities;

namespace BoardingHouse.DAL.Interfaces
{
    public interface IHoaDonRepository : IBaseRepository<HoaDon>
    {
        // Lấy hóa đơn kèm chi tiết (để in ra giấy)
        // Bao gồm: Thông tin hóa đơn + List các dòng dịch vụ (Điện, nước...)
        Task<HoaDon> GetHoaDonWithDetailsAsync(int maHoaDon);

        // Lấy danh sách hóa đơn của một phòng cụ thể
        Task<List<HoaDon>> GetHistoryByPhongAsync(int maPhong);

        // Thống kê: Lấy danh sách hóa đơn chưa thanh toán
        Task<List<HoaDon>> GetUnpaidBillsAsync();

        // Thống kê doanh thu theo tháng/năm
        //Task<decimal> GetTotalRevenueAsync(int thang, int nam);
        Task<List<HoaDon>> SearchAsync(int? thang, int? nam, int? maPhong, string trangThai);
    }
}