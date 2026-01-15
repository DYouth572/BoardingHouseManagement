using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardingHouse.DAL.Context;
using BoardingHouse.DAL.Entities;
using BoardingHouse.DAL.Interfaces;

namespace BoardingHouse.DAL.Implements
{
    public class PhongRepository : BaseRepository<Phong>, IPhongRepository
    {
        private readonly BoardingHouseContext _myContext;

        public PhongRepository(BoardingHouseContext context) : base(context)
        {
            _myContext = context;
        }

        // --- CÁC HÀM LẤY DỮ LIỆU (GET) ---
        // Thêm .AsNoTracking() vào để luôn lấy dữ liệu mới nhất từ DB, bỏ qua Cache cũ

        public async Task<List<Phong>> GetAllWithLoaiPhongAsync()
        {
            return await _dbSet.AsNoTracking() // <--- QUAN TRỌNG: Thêm dòng này
                               .Include(p => p.LoaiPhong)
                               .ToListAsync();
        }

        public async Task<List<Phong>> GetPhongTrongAsync()
        {
            return await _dbSet.AsNoTracking() // <--- QUAN TRỌNG: Thêm dòng này
                               .Where(p => p.TrangThai == "Trống")
                               .Include(p => p.LoaiPhong)
                               .ToListAsync();
        }

        public async Task<List<Phong>> SearchByNameAsync(string name)
        {
            return await _dbSet.AsNoTracking() // <--- QUAN TRỌNG: Thêm dòng này
                               .Where(p => p.TenPhong.Contains(name))
                               .Include(p => p.LoaiPhong)
                               .ToListAsync();
        }

        // --- HÀM CẬP NHẬT (UPDATE) ---
        // Giữ nguyên logic "đá" (Detach) thằng cũ ra để tránh lỗi trùng ID
        public async Task UpdatePhongSafeAsync(Phong entity)
        {
            var local = _myContext.Set<Phong>()
                .Local
                .FirstOrDefault(entry => entry.MaPhong.Equals(entity.MaPhong));

            if (local != null)
            {
                _myContext.Entry(local).State = EntityState.Detached;
            }

            _myContext.Entry(entity).State = EntityState.Modified;
            await _myContext.SaveChangesAsync();
        }
    }
}