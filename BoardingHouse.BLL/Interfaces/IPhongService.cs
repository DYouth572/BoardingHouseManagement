using System.Collections.Generic;
using System.Threading.Tasks;
using BoardingHouse.DAL.DTO; // Sử dụng DTO
using BoardingHouse.DAL.Entities;

namespace BoardingHouse.BLL.Interfaces
{
    public interface IPhongService
    {
        // Các hàm trả về Entity (Dùng cho logic xử lý)
        Task<List<Phong>> GetAllAsync();
        Task<List<Phong>> GetPhongTrongAsync();

        // [MỚI] Các hàm trả về DTO (Dùng cho hiển thị UI)
        Task<List<PhongDTO>> GetAllPhongDTOAsync();
        Task<List<PhongDTO>> SearchPhongDTOAsync(string keyword);

        // Các hàm tác nghiệp
        Task AddPhongAsync(Phong p);
        Task UpdatePhongAsync(Phong p);
        Task DeletePhongAsync(int maPhong);
    }
}