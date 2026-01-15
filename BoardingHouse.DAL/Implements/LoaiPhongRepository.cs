using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BoardingHouse.DAL.Context;
using BoardingHouse.DAL.Entities;
using BoardingHouse.DAL.Interfaces;

namespace BoardingHouse.DAL.Implements
{
    public class LoaiPhongRepository : BaseRepository<LoaiPhong>, ILoaiPhongRepository
    {
        public LoaiPhongRepository(BoardingHouseContext context) : base(context)
        {
        }

        public async Task<bool> IsUsedAsync(int maLoai)
        {
            // Kiểm tra trong bảng Phong có dòng nào dùng MaLoai này không
            return await _context.Phongs.AnyAsync(p => p.MaLoai == maLoai);
        }
    }
}