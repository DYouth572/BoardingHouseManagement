using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BoardingHouse.BLL.Interfaces; // Kết nối Interface
using BoardingHouse.DAL.Context;
using BoardingHouse.DAL.Entities;

namespace BoardingHouse.BLL.Implements
{
    // Kế thừa IThamSoService
    public class ThamSoService : IThamSoService
    {
        private readonly BoardingHouseContext _context = new BoardingHouseContext();

        // 1. Đổi tên thành GetGiaTriAsync
        public async Task<decimal> GetGiaTriAsync(string tenThamSo)
        {
            var item = await _context.ThamSos.FindAsync(tenThamSo);
            return item != null ? item.GiaTri : 0;
        }

        // 2. Đổi tên thành UpdateGiaTriAsync
        public async Task UpdateGiaTriAsync(string tenThamSo, decimal giaTriMoi)
        {
            var item = await _context.ThamSos.FindAsync(tenThamSo);
            if (item != null)
            {
                item.GiaTri = giaTriMoi;
            }
            else
            {
                _context.ThamSos.Add(new ThamSo { TenThamSo = tenThamSo, GiaTri = giaTriMoi });
            }
            await _context.SaveChangesAsync();
        }
    }
}