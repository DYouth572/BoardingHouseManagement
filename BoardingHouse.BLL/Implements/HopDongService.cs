using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BoardingHouse.BLL.Interfaces;
using BoardingHouse.DAL.Context;
using BoardingHouse.DAL.DTO;
using BoardingHouse.DAL.Entities;
using BoardingHouse.DAL.Implements;
using BoardingHouse.DAL.Interfaces;

namespace BoardingHouse.BLL.Implements
{
    public class HopDongService : IHopDongService
    {
        private readonly BoardingHouseContext _context;
        private readonly IHopDongRepository _hdRepo;
        private readonly IPhongRepository _phongRepo;

        // 1. BỔ SUNG KHAI BÁO REPO KHÁCH HÀNG
        private readonly IKhachHangRepository _khachRepo;

        public HopDongService()
        {
            _context = new BoardingHouseContext();
            _hdRepo = new HopDongRepository(_context);
            _phongRepo = new PhongRepository(_context);

            // 2. KHỞI TẠO REPO KHÁCH HÀNG
            _khachRepo = new KhachHangRepository(_context);
        }

        // --- 3. BỔ SUNG 2 HÀM LẤY DỮ LIỆU COMBOBOX (QUAN TRỌNG) ---

        public async Task<List<Phong>> GetPhongTrongAsync()
        {
            // Lấy các phòng có trạng thái 'Trống'
            return await _context.Phongs.Where(p => p.TrangThai == "Trống").ToListAsync();
        }

        public async Task<List<KhachHang>> GetKhachHangAsync()
        {
            return await _khachRepo.GetAllAsync();
        }


        public async Task<List<HopDongDTO>> GetAllHopDongDTOAsync()
        {
            var query = from hd in _context.HopDongs
                        join p in _context.Phongs on hd.MaPhong equals p.MaPhong
                        join k in _context.KhachHangs on hd.MaKhach equals k.MaKhach
                        orderby hd.NgayBatDau descending
                        select new HopDongDTO
                        {
                            MaHopDong = hd.MaHopDong,
                            TenPhong = p.TenPhong,
                            TenKhachHang = k.HoTen,
                            SDT = k.SDT,
                            GiaPhong = hd.GiaPhong,
                            NgayBatDau = hd.NgayBatDau,
                            NgayKetThuc = hd.NgayKetThuc,
                            TienCoc = hd.TienCoc,
                            DaKetThuc = hd.DaKetThuc
                        };

            return await query.ToListAsync();
        }

        public async Task<HopDong> GetHopDongHienTaiCuaPhongAsync(int maPhong)
        {
            return await _hdRepo.GetActiveContractByPhongAsync(maPhong);
        }

        public async Task ThuePhongAsync(HopDong hopDong, List<ChiTietKhachO> listNguoiO)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Kiểm tra phòng
                    var phong = await _phongRepo.GetByIdAsync(hopDong.MaPhong);
                    if (phong.TrangThai != "Trống")
                        throw new Exception("Phòng này hiện không còn trống!");

                    // 2. Lưu hợp đồng
                    hopDong.DaKetThuc = false;
                    await _hdRepo.AddAsync(hopDong);

                    // Phải lưu ngay tại đây để Hợp đồng được ghi vào DB và sinh ra MaHopDong
                    await _context.SaveChangesAsync();

                    // 3. Lưu người ở ghép (Nếu có)
                    if (listNguoiO != null && listNguoiO.Count > 0)
                    {
                        foreach (var item in listNguoiO)
                        {
                            item.MaHopDong = hopDong.MaHopDong; // Lấy ID vừa sinh ra ở trên
                            _context.ChiTietKhachOs.Add(item);
                        }
                    }

                    // 4. Cập nhật trạng thái phòng
                    phong.TrangThai = "Đang thuê"; // Hoặc "Đã thuê"
                    await _phongRepo.UpdateAsync(phong);
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task TraPhongAsync(int maHopDong)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var hd = await _hdRepo.GetByIdAsync(maHopDong);
                    if (hd == null) throw new Exception("Không tìm thấy hợp đồng!");

                    // 1. Kết thúc hợp đồng
                    hd.NgayKetThuc = DateTime.Now;
                    hd.DaKetThuc = true;
                    await _hdRepo.UpdateAsync(hd);

                    // 2. Trả phòng về trống
                    var phong = await _phongRepo.GetByIdAsync(hd.MaPhong);
                    phong.TrangThai = "Trống";
                    await _phongRepo.UpdateAsync(phong);
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}