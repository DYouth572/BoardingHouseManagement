using System.Collections.Generic;
using System.Threading.Tasks;
using BoardingHouse.DAL.DTO;
using BoardingHouse.DAL.Entities;

namespace BoardingHouse.BLL.Interfaces
{
    public interface IHopDongService
    {
        // Nghiệp vụ thuê trả phòng
        Task ThuePhongAsync(HopDong hopDong, List<ChiTietKhachO> listNguoiO);
        Task TraPhongAsync(int maHopDong);

        // Lấy thông tin hợp đồng hiện tại (để tính tiền điện nước sau này)
        Task<HopDong> GetHopDongHienTaiCuaPhongAsync(int maPhong);

        // Lấy danh sách hiển thị dạng phẳng (DTO)
        Task<List<HopDongDTO>> GetAllHopDongDTOAsync();

        // --- BỔ SUNG 2 HÀM NÀY (BẮT BUỘC ĐỂ FORM CHẠY) ---
        Task<List<Phong>> GetPhongTrongAsync();      // Lấy danh sách phòng trống
        Task<List<KhachHang>> GetKhachHangAsync();   // Lấy danh sách khách hàng
        // ------------------------------------------------
    }
}