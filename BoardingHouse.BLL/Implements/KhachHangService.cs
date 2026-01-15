using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoardingHouse.BLL.Interfaces;
using BoardingHouse.DAL.Context;
using BoardingHouse.DAL.Entities;
using BoardingHouse.DAL.Implements;
using BoardingHouse.DAL.Interfaces;

namespace BoardingHouse.BLL.Implements
{
    public class KhachHangService : IKhachHangService
    {
        private readonly IKhachHangRepository _repo;

        public KhachHangService()
        {
            _repo = new KhachHangRepository(new BoardingHouseContext());
        }

        public async Task<List<KhachHang>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        // --- SỬA HÀM THÊM ---
        public async Task AddAsync(KhachHang kh)
        {
            await _repo.AddAsync(kh);
            await _repo.SaveChangesAsync();
        }

        // --- SỬA HÀM XÓA ---
        public async Task DeleteAsync(int id)
        {
            var kh = await _repo.GetByIdAsync(id);
            if (kh != null) 
            {
                await _repo.DeleteAsync(kh);                 
                await _repo.SaveChangesAsync();
            }
        }

        public async Task<List<KhachHang>> SearchAsync(string keyword)
        {
            return await _repo.SearchAsync(keyword);
        }

        public async Task UpdateAsync(KhachHang kh)
        {
            // Hàm UpdateSafeAsync trong Repo đã có sẵn SaveChanges rồi nên không cần thêm
            await _repo.UpdateSafeAsync(kh);
        }
    }
}