using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BoardingHouse.DAL.Context;
using BoardingHouse.DAL.Entities;
using BoardingHouse.DAL.Interfaces;

namespace BoardingHouse.DAL.Implements
{
    public class ThamSoRepository : BaseRepository<ThamSo>, IThamSoRepository
    {
        public ThamSoRepository(BoardingHouseContext context) : base(context)
        {
        }

        public async Task<decimal> GetGiaTriAsync(string tenThamSo)
        {
            var item = await _dbSet.FindAsync(tenThamSo);
            return item != null ? item.GiaTri : 0;
        }

        public async Task UpdateGiaTriAsync(string tenThamSo, decimal giaTriMoi)
        {
            var item = await _dbSet.FindAsync(tenThamSo);
            if (item != null)
            {
                item.GiaTri = giaTriMoi;
                // Lưu ý: Không SaveChanges ở đây, để BLL gọi
            }
        }
    }
}