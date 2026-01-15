using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardingHouse.DAL.Interfaces
{
    // <T> là Generic, đại diện cho bất kỳ bảng nào (Phong, HopDong,...)
    public interface IBaseRepository<T> where T : class
    {
        // 1. Lấy tất cả danh sách
        Task<List<T>> GetAllAsync();

        // 2. Lấy 1 dòng theo ID (int)
        //Task<T> GetByIdAsync(int id);

        //// 3. Lấy 1 dòng theo ID (string - dùng cho bảng NguoiDung)
        //Task<T> GetByIdAsync(string id);

        Task<T> GetByIdAsync(object id);

        // 4. Thêm mới
        Task AddAsync(T entity);

        // 5. Cập nhật
        Task UpdateAsync(T entity);

        // 6. Xóa
        Task DeleteAsync(T entity);

        // 7. Lưu thay đổi 
        Task SaveChangesAsync();
    }
}