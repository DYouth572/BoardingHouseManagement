using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardingHouse.DAL.Context;
using BoardingHouse.DAL.Entities;
using BoardingHouse.DAL.Interfaces;

namespace BoardingHouse.DAL.Implements
{
    public class HopDongRepository : BaseRepository<HopDong>, IHopDongRepository
    {
        public HopDongRepository(BoardingHouseContext context) : base(context)
        {
        }

        public async Task<HopDong> GetActiveContractByPhongAsync(int maPhong)
        {
            return await _dbSet
                .Include(h => h.KhachHang) // Lấy chủ hợp đồng
                .FirstOrDefaultAsync(h => h.MaPhong == maPhong && !h.DaKetThuc);
        }

        public async Task<HopDong> GetHopDongWithDetailsAsync(int maHopDong)
        {
            return await _dbSet
                .Include(h => h.Phong)
                .Include(h => h.KhachHang) // Chủ phòng
                .Include(h => h.ChiTietKhachOs) // Danh sách ở ghép
                    .ThenInclude(ct => ct.KhachHang) // Lấy thông tin chi tiết của người ở ghép
                .FirstOrDefaultAsync(h => h.MaHopDong == maHopDong);
        }

        public async Task<List<HopDong>> GetHopDongSapHetHanAsync(int soNgay)
        {
            DateTime limitDate = DateTime.Now.AddDays(soNgay);

            return await _dbSet
                .Where(h => !h.DaKetThuc && h.NgayKetThuc != null && h.NgayKetThuc <= limitDate)
                .Include(h => h.Phong)
                .Include(h => h.KhachHang)
                .ToListAsync();
        }
    }
}