using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoardingHouse.DAL.Context;
using BoardingHouse.DAL.Interfaces;

namespace BoardingHouse.DAL.Implements
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly BoardingHouseContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(BoardingHouseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id) 
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);          
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            await Task.CompletedTask;
        }

        // --- NƠI LƯU DỮ LIỆU ---
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}