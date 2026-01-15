using System.Collections.Generic;
using System.Threading.Tasks;
using BoardingHouse.DAL.Entities;

namespace BoardingHouse.DAL.Interfaces
{
    public interface IPhongRepository : IBaseRepository<Phong>
    {
        // Lấy danh sách phòng kèm theo Tên loại phòng (Join bảng)
        Task<List<Phong>> GetAllWithLoaiPhongAsync();

        // Lấy danh sách các phòng đang TRỐNG (để khách thuê)
        Task<List<Phong>> GetPhongTrongAsync();

        // Tìm kiếm phòng theo tên (Ví dụ: tìm "101")
        Task<List<Phong>> SearchByNameAsync(string name);

        Task UpdatePhongSafeAsync(Phong entity);
    }
}