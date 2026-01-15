using System.Collections.Generic;
using System.Threading.Tasks;
using BoardingHouse.DAL.Entities;

namespace BoardingHouse.DAL.Interfaces
{
    public interface IHopDongRepository : IBaseRepository<HopDong>
    {
        // Lấy hợp đồng chi tiết (kèm thông tin Phòng, Khách, và Danh sách người ở ghép)
        Task<HopDong> GetHopDongWithDetailsAsync(int maHopDong);

        // Tìm hợp đồng ĐANG CÓ HIỆU LỰC của một phòng cụ thể
        // (Dùng khi tính tiền điện nước, phải biết phòng đó đang theo hợp đồng nào để lấy giá)
        Task<HopDong> GetActiveContractByPhongAsync(int maPhong);

        // Lấy danh sách các hợp đồng sắp hết hạn (ví dụ: còn < 7 ngày)
        Task<List<HopDong>> GetHopDongSapHetHanAsync(int soNgay);
    }
}