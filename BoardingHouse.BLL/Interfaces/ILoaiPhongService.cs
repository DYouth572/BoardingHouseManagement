using System.Collections.Generic;
using System.Threading.Tasks;
using BoardingHouse.DAL.Entities;

namespace BoardingHouse.BLL.Interfaces
{
    public interface ILoaiPhongService
    {
        Task<List<LoaiPhong>> GetAllAsync();
        Task AddLoaiPhongAsync(LoaiPhong lp);
        Task UpdateLoaiPhongAsync(LoaiPhong lp);
        Task DeleteLoaiPhongAsync(int maLoai); // Logic: Check ràng buộc
    }
}