using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardingHouse.DAL.Context;
using BoardingHouse.DAL.Entities;
using BoardingHouse.DAL.Interfaces;

namespace BoardingHouse.DAL.Implements
{
    public class HoaDonRepository : BaseRepository<HoaDon>, IHoaDonRepository
    {
        public HoaDonRepository(BoardingHouseContext context) : base(context)
        {
        }

        public async Task<List<HoaDon>> GetHistoryByPhongAsync(int maPhong)
        {
            return await _dbSet
                .Where(hd => hd.MaPhong == maPhong)
                .Include(hd => hd.ChiTietHoaDons) // Load luôn chi tiết để xem lịch sử
                .OrderByDescending(hd => hd.Nam).ThenByDescending(hd => hd.Thang)
                .ToListAsync();
        }

        public async Task<HoaDon> GetHoaDonWithDetailsAsync(int maHoaDon)
        {
            // BẮT BUỘC PHẢI INCLUDE CHI TIẾT
            // Vì tiền điện, nước nằm trong bảng ChiTietHoaDon
            return await _dbSet
                .Include(hd => hd.Phong)
                .Include(hd => hd.ChiTietHoaDons)
                .FirstOrDefaultAsync(hd => hd.MaHoaDon == maHoaDon);
        }

        public async Task<decimal> GetTotalRevenueAsync(int thang, int nam)
        {
            return await _dbSet
                .Where(hd => hd.Thang == thang && hd.Nam == nam && hd.TrangThai == "Đã thanh toán")
                .SumAsync(hd => hd.TongTien);
        }

        public async Task<List<HoaDon>> GetUnpaidBillsAsync()
        {
            return await _dbSet
                .Where(hd => hd.TrangThai == "Chưa thanh toán")
                .Include(hd => hd.Phong)
                .OrderByDescending(hd => hd.NgayLap)
                .ToListAsync();
        }

        // --- BỔ SUNG HÀM SEARCH (Khớp với Interface) ---
        public async Task<List<HoaDon>> SearchAsync(int? thang, int? nam, int? maPhong, string trangThai)
        {
            var query = _dbSet.AsQueryable();

            if (thang.HasValue) query = query.Where(x => x.Thang == thang);
            if (nam.HasValue) query = query.Where(x => x.Nam == nam);
            if (maPhong.HasValue) query = query.Where(x => x.MaPhong == maPhong);
            if (!string.IsNullOrEmpty(trangThai)) query = query.Where(x => x.TrangThai == trangThai);

            return await query
                .Include(x => x.Phong)
                .Include(x => x.ChiTietHoaDons)
                .OrderByDescending(x => x.Nam).ThenByDescending(x => x.Thang)
                .ToListAsync();
        }
    }
}