using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardingHouse.DAL.Context;
using BoardingHouse.DAL.Entities;
using BoardingHouse.DAL.Interfaces;

namespace BoardingHouse.DAL.Implements
{
    public class KhachHangRepository : BaseRepository<KhachHang>, IKhachHangRepository
    {
        private readonly BoardingHouseContext _myContext;

        public KhachHangRepository(BoardingHouseContext context) : base(context)
        {
            _myContext = context;
        }

        // --- BỔ SUNG HÀM NÀY ĐỂ FIX LỖI KHÔNG CẬP NHẬT GRID ---
        // Ghi đè hàm GetAll của cha để thêm AsNoTracking (Bắt buộc lấy dữ liệu mới từ DB)
        public override async Task<List<KhachHang>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
        // -----------------------------------------------------

        public async Task<KhachHang> GetByCCCDAsync(string cccd)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(kh => kh.CCCD == cccd);
        }

        public async Task<List<KhachHang>> SearchAsync(string keyword)
        {
            return await _dbSet.AsNoTracking()
                               .Where(kh => kh.HoTen.Contains(keyword) ||
                                            kh.SDT.Contains(keyword) ||
                                            kh.CCCD.Contains(keyword))
                               .ToListAsync();
        }

        // Hàm UpdateSafeAsync giữ nguyên để sửa lỗi Tracking khi lưu
        public async Task UpdateSafeAsync(KhachHang entity)
        {
            var local = _dbSet.Local.FirstOrDefault(entry => entry.MaKhach.Equals(entity.MaKhach));
            if (local != null)
            {
                _myContext.Entry(local).State = EntityState.Detached;
            }
            _myContext.Entry(entity).State = EntityState.Modified;
            await _myContext.SaveChangesAsync();
        }
    }
}