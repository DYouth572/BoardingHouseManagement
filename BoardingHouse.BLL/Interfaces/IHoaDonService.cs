using System.Collections.Generic;
using System.Threading.Tasks;
using BoardingHouse.DAL.DTO;
using BoardingHouse.DAL.Entities;

namespace BoardingHouse.BLL.Interfaces
{
    public interface IHoaDonService
    {
        // --- 1. NHÓM HÀM LẬP HÓA ĐƠN (LOGIC MỚI) ---

        // Lấy danh sách ghi điện nước (Kèm giá mặc định từ ThamSo)
        Task<List<GhiDienNuocDTO>> GetDanhSachGhiDienNuoc(int thang, int nam);

        // Lưu và Tính tiền (Dựa trên giá chốt từ Grid gửi xuống)
        Task LuuVaTinhTienAsync(int thang, int nam, List<GhiDienNuocDTO> listData);


        // --- 2. NHÓM HÀM QUẢN LÝ / LỊCH SỬ (GIỮ LẠI) ---

        // Lấy lịch sử hóa đơn để hiển thị lên lưới
        Task<List<HoaDonDTO>> GetLichSuHoaDonDTOAsync(int maPhong);

        // Xác nhận thanh toán tiền
        Task ThanhToanHoaDonAsync(int maHoaDon);



        Task<List<HoaDonDTO>> GetDanhSachHoaDon(int thang, int nam, bool chiXemChuaThu);
        Task<HoaDonInDTO> GetThongTinInHoaDonAsync(int maHoaDon);
    }
}