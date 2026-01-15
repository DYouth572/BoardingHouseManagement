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
    public class LoaiPhongService : ILoaiPhongService
    {
        private readonly ILoaiPhongRepository _repo;

        public LoaiPhongService()
        {
            _repo = new LoaiPhongRepository(new BoardingHouseContext());
        }

        public async Task<List<LoaiPhong>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task AddLoaiPhongAsync(LoaiPhong lp)
        {
            if (lp.DonGia <= 0) throw new Exception("Đơn giá phải lớn hơn 0");
            await _repo.AddAsync(lp);
            await _repo.SaveChangesAsync();
        }

        public async Task UpdateLoaiPhongAsync(LoaiPhong lp)
        {
            if (lp.DonGia <= 0) throw new Exception("Đơn giá phải lớn hơn 0");
            await _repo.UpdateAsync(lp);
            await _repo.SaveChangesAsync();
        }

        public async Task DeleteLoaiPhongAsync(int maLoai)
        {
            bool isUsed = await _repo.IsUsedAsync(maLoai);
            if (isUsed) throw new Exception("Loại phòng này đang có phòng sử dụng, không thể xóa!");

            var lp = await _repo.GetByIdAsync(maLoai);
            if (lp != null)
            {
                await _repo.DeleteAsync(lp);
                await _repo.SaveChangesAsync();
            }
        }
    }
}