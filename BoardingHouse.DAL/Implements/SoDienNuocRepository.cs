using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using BoardingHouse.DAL.Context;
using BoardingHouse.DAL.Entities;
using BoardingHouse.DAL.Interfaces;

namespace BoardingHouse.DAL.Implements
{
    public class SoDienNuocRepository : BaseRepository<SoDienNuoc>, ISoDienNuocRepository
    {
        public SoDienNuocRepository(BoardingHouseContext context) : base(context)
        {
        }

        public async Task<bool> CheckExistsAsync(int maPhong, int thang, int nam)
        {
            return await _dbSet.AnyAsync(s => s.MaPhong == maPhong && s.Thang == thang && s.Nam == nam);
        }

        public async Task<SoDienNuoc> GetLastMonthUsageAsync(int maPhong)
        {
            // Sắp xếp giảm dần theo năm và tháng, lấy dòng đầu tiên -> Chính là tháng gần nhất
            return await _dbSet
                .Where(s => s.MaPhong == maPhong)
                .OrderByDescending(s => s.Nam)
                .ThenByDescending(s => s.Thang)
                .FirstOrDefaultAsync();
        }
    }
}