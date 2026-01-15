using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BoardingHouse.DAL.Context;
using BoardingHouse.DAL.Entities;
using BoardingHouse.DAL.Interfaces;

namespace BoardingHouse.DAL.Implements
{
    public class NguoiDungRepository : BaseRepository<NguoiDung>, INguoiDungRepository
    {
        public NguoiDungRepository(BoardingHouseContext context) : base(context)
        {
        }

        public async Task<bool> ExistsAsync(string username)
        {
            return await _dbSet.AnyAsync(u => u.UserName == username);
        }

        public async Task<NguoiDung> GetByUsernameAsync(string username)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.UserName == username);
        }
    }
}