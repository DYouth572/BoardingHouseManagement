using BoardingHouse.BLL.Interfaces;
using BoardingHouse.DAL.Context;
using BoardingHouse.DAL.DTO;
using BoardingHouse.DAL.Entities;
using BoardingHouse.DAL.Implements;
using BoardingHouse.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardingHouse.BLL.Implements
{
    public class PhongService : IPhongService
    {
        private readonly IPhongRepository _repo;

        public PhongService()
        {
            _repo = new PhongRepository(new BoardingHouseContext());
        }

        // ... Các hàm Get (Giữ nguyên) ...

        public async Task<List<PhongDTO>> GetAllPhongDTOAsync()
        {
            var entities = await _repo.GetAllWithLoaiPhongAsync();
            return entities.Select(p => new PhongDTO
            {
                MaPhong = p.MaPhong,
                TenPhong = p.TenPhong,
                TenLoaiPhong = p.LoaiPhong?.TenLoai ?? "Chưa phân loại",
                DonGia = p.LoaiPhong?.DonGia ?? 0,
                TrangThai = p.TrangThai
            }).ToList();
        }

        public async Task<List<PhongDTO>> SearchPhongDTOAsync(string keyword)
        {
            // ... Giữ nguyên ...
            var entities = await _repo.SearchByNameAsync(keyword);
            // ... convert to DTO ...
            return entities.Select(p => new PhongDTO
            {
                MaPhong = p.MaPhong,
                TenPhong = p.TenPhong,
                TenLoaiPhong = p.LoaiPhong?.TenLoai ?? "Chưa phân loại",
                DonGia = p.LoaiPhong?.DonGia ?? 0,
                TrangThai = p.TrangThai
            }).ToList();
        }

        // --- CÁC HÀM GET KHÁC GIỮ NGUYÊN ---
        public async Task<List<Phong>> GetAllAsync() => await _repo.GetAllWithLoaiPhongAsync();
        public async Task<List<Phong>> GetPhongTrongAsync() => await _repo.GetPhongTrongAsync();


        public async Task AddPhongAsync(Phong p)
        {
            // 1. Logic
            p.TrangThai = "Trống";

            // 2. Thêm vào bộ nhớ
            await _repo.AddAsync(p);

            // 3. [QUAN TRỌNG] LƯU XUỐNG DATABASE
            // Nếu thiếu dòng này, dữ liệu sẽ mất khi tắt form
            await _repo.SaveChangesAsync();
        }

        public async Task UpdatePhongAsync(Phong p)
        {
            await _repo.UpdatePhongSafeAsync(p);
        }

        public async Task DeletePhongAsync(int maPhong)
        {
            var p = await _repo.GetByIdAsync(maPhong);
            if (p == null) throw new Exception("Phòng không tồn tại!");

            if (p.TrangThai == "Đang thuê")
                throw new Exception("Phòng đang có người ở, không thể xóa!");

            // Xóa khỏi bộ nhớ
            await _repo.DeleteAsync(p);


            await _repo.SaveChangesAsync();
        }
    }
}