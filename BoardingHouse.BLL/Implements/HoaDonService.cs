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
    public class HoaDonService : IHoaDonService
    {
        private readonly BoardingHouseContext _context;
        private readonly IHoaDonRepository _hdRepo;
        private readonly IPhongRepository _phongRepo;

        public HoaDonService()
        {
            _context = new BoardingHouseContext();
            _hdRepo = new HoaDonRepository(_context);
            _phongRepo = new PhongRepository(_context);
        }

        // --- HÀM HỖ TRỢ: LẤY GIÁ TỪ BẢNG THAM SỐ (CẤU HÌNH) ---
        private async Task<decimal> LayGiaThamSo(string key, decimal macDinh)
        {
            var item = await _context.ThamSos.FindAsync(key);
            // Nếu tìm thấy trong DB thì lấy, không thì lấy giá mặc định code cứng
            return item != null ? item.GiaTri : macDinh;
        }

        // --- 1. LẤY DANH SÁCH GHI ĐIỆN NƯỚC (LOAD LÊN GRID) ---
        public async Task<List<GhiDienNuocDTO>> GetDanhSachGhiDienNuoc(int thang, int nam)
        {
            // Lấy tất cả phòng đang thuê
            var listPhong = await _context.Phongs.AsNoTracking()
                .Where(p => p.TrangThai == "Đã thuê" || p.TrangThai == "Đang thuê")
                .ToListAsync();

            // Lấy giá cấu hình hiện tại từ bảng ThamSo
            decimal giaDienDB = await LayGiaThamSo("GIA_DIEN", 3500);
            decimal giaNuocDB = await LayGiaThamSo("GIA_NUOC", 15000);
            decimal giaDVDB = await LayGiaThamSo("GIA_DICH_VU", 100000);

            // --- LẤY GIÁ MẠNG TỪ THAM SỐ (MỚI THÊM) ---
            decimal giaMangDB = await LayGiaThamSo("GIA_MANG", 50000); // Mặc định 50k nếu chưa cấu hình

            var result = new List<GhiDienNuocDTO>();

            // Xác định tháng trước để lấy chỉ số cũ
            int thangTruoc = (thang == 1) ? 12 : thang - 1;
            int namTruoc = (thang == 1) ? nam - 1 : nam;

            foreach (var p in listPhong)
            {
                var dto = new GhiDienNuocDTO
                {
                    MaPhong = p.MaPhong,
                    TenPhong = p.TenPhong,
                    GiaPhong = p.GiaPhong, // Giá phòng gốc từ danh mục

                    // TỰ ĐỘNG ĐIỀN GIÁ MẶC ĐỊNH VÀO DTO
                    GiaDien = giaDienDB,
                    GiaNuoc = giaNuocDB,
                    TienDichVu = giaDVDB,

                    // --- ĐIỀN GIÁ MẠNG VÀO DTO (MỚI THÊM) ---
                    TienMang = giaMangDB
                };

                // Tìm chỉ số cũ trong DB (của tháng trước)
                var soCu = await _context.SoDienNuocs
                    .FirstOrDefaultAsync(s => s.MaPhong == p.MaPhong && s.Thang == thangTruoc && s.Nam == namTruoc);

                if (soCu != null)
                {
                    dto.ChiSoDienCu = soCu.ChiSoDienMoi;
                    dto.ChiSoNuocCu = soCu.ChiSoNuocMoi;
                }
                else
                {
                    // Phòng mới chưa có số cũ
                    dto.ChiSoDienCu = 0;
                    dto.ChiSoNuocCu = 0;
                }

                // Mặc định số mới = số cũ (để user đỡ phải gõ nếu không dùng)
                dto.ChiSoDienMoi = dto.ChiSoDienCu;
                dto.ChiSoNuocMoi = dto.ChiSoNuocCu;

                result.Add(dto);
            }
            return result;
        }

        // --- 2. TÍNH TIỀN & LƯU 
        public async Task LuuVaTinhTienAsync(int thang, int nam, List<GhiDienNuocDTO> listData)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in listData)
                    {
                        // A. Lưu bảng SoDienNuoc
                        var record = await _context.SoDienNuocs
                            .FirstOrDefaultAsync(s => s.MaPhong == item.MaPhong && s.Thang == thang && s.Nam == nam);

                        if (record == null)
                        {
                            record = new SoDienNuoc { MaPhong = item.MaPhong, Thang = thang, Nam = nam };
                            _context.SoDienNuocs.Add(record);
                        }

                        // Cập nhật chỉ số
                        record.ChiSoDienCu = item.ChiSoDienCu;
                        record.ChiSoDienMoi = item.ChiSoDienMoi;
                        record.ChiSoNuocCu = item.ChiSoNuocCu;
                        record.ChiSoNuocMoi = item.ChiSoNuocMoi;

                        // B. Tính Hóa Đơn 
                        // QUAN TRỌNG: Dùng item.Gia... (Giá lấy từ Grid xuống) chứ KHÔNG lấy từ DB nữa
                        decimal tienDien = (item.ChiSoDienMoi - item.ChiSoDienCu) * item.GiaDien;
                        decimal tienNuoc = (item.ChiSoNuocMoi - item.ChiSoNuocCu) * item.GiaNuoc;

                        var hoaDon = await _context.HoaDons
                            .FirstOrDefaultAsync(h => h.MaPhong == item.MaPhong && h.Thang == thang && h.Nam == nam);

                        if (hoaDon == null)
                        {
                            hoaDon = new HoaDon
                            {
                                MaPhong = item.MaPhong,
                                Thang = thang,
                                Nam = nam,
                                TrangThai = "Chưa thanh toán",
                                NgayLap = DateTime.Now,
                                GhiChu = ""
                            };
                            _context.HoaDons.Add(hoaDon);
                        }

                        // Lưu các con số ĐÃ CHỐT vào Hóa Đơn

                        hoaDon.TienDien = tienDien;
                        hoaDon.TienNuoc = tienNuoc;
                        hoaDon.TienPhong = item.GiaPhong;
                        hoaDon.TienDichVu = item.TienDichVu;


                        hoaDon.TienMang = item.TienMang;

                        // Tổng tiền (Cộng thêm cả tiền mạng)
                        hoaDon.TongTien = tienDien + tienNuoc + item.GiaPhong + item.TienDichVu + item.TienMang;
                    }

                    await _context.SaveChangesAsync();
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        // --- 3. CÁC HÀM HIỂN THỊ LỊCH SỬ ---
        public async Task<List<HoaDonDTO>> GetLichSuHoaDonDTOAsync(int maPhong)
        {
            var entities = await _hdRepo.GetHistoryByPhongAsync(maPhong);
            var phong = await _phongRepo.GetByIdAsync(maPhong);

            return entities.Select(hd => new HoaDonDTO
            {
                MaHoaDon = hd.MaHoaDon,
                TenPhong = phong?.TenPhong ?? "Không xác định",
                Thang = hd.Thang,
                Nam = hd.Nam,
                NgayLap = hd.NgayLap,

                TienPhong = hd.TienPhong,
                TienDien = hd.TienDien,
                TienNuoc = hd.TienNuoc,
                TienDichVu = hd.TienDichVu,
                TienMang = hd.TienMang,

                TongTien = hd.TongTien,
                TrangThai = hd.TrangThai
            }).ToList();
        }

        // HÀM THANH TOÁN
        public async Task ThanhToanHoaDonAsync(int maHoaDon)
        {
            var hd = await _hdRepo.GetByIdAsync(maHoaDon);
            if (hd != null)
            {
                hd.TrangThai = "Đã thanh toán";
                await _hdRepo.UpdateAsync(hd);
                await _hdRepo.SaveChangesAsync();
            }
        }


        // --- 4. HÀM MỚI: LẤY DANH SÁCH HÓA ĐƠN (Phục vụ form Quản Lý Thu Tiền) ---
        public async Task<List<HoaDonDTO>> GetDanhSachHoaDon(int thang, int nam, bool chiXemChuaThu)
        {
            // 1. Query kết hợp bảng Hóa Đơn và Phòng
            var query = _context.HoaDons
                .Include(h => h.Phong)
                .Where(h => h.Thang == thang && h.Nam == nam);

            // 2. Nếu user tick chọn "Chỉ xem chưa thu" thì lọc thêm
            if (chiXemChuaThu)
            {
                query = query.Where(h => h.TrangThai == "Chưa thanh toán");
            }

            // 3. Lấy dữ liệu và chuyển sang DTO
            var listData = await query.OrderBy(h => h.Phong.TenPhong).ToListAsync();

            return listData.Select(h => new HoaDonDTO
            {
                MaHoaDon = h.MaHoaDon,
                TenPhong = h.Phong.TenPhong,
                Thang = h.Thang,
                Nam = h.Nam,
                NgayLap = h.NgayLap,

                // Chi tiết tiền (DTO phải có các trường này)
                TienPhong = h.TienPhong,
                TienDien = h.TienDien,
                TienNuoc = h.TienNuoc,
                TienDichVu = h.TienDichVu,
                TienMang = h.TienMang,

                // Tổng & Trạng thái
                TongTien = h.TongTien,
                TrangThai = h.TrangThai
            }).ToList();
        }



        public async Task<HoaDonInDTO> GetThongTinInHoaDonAsync(int maHoaDon)
        {
            // 1. Lấy Hóa đơn
            var hd = await _context.HoaDons.Include(h => h.Phong).FirstOrDefaultAsync(h => h.MaHoaDon == maHoaDon);
            if (hd == null) return null;

            // 2. Lấy Chỉ số điện nước tương ứng
            var so = await _context.SoDienNuocs
                .FirstOrDefaultAsync(s => s.MaPhong == hd.MaPhong && s.Thang == hd.Thang && s.Nam == hd.Nam);

            // 3. Tính toán lại đơn giá (hoặc lấy từ cấu hình nếu muốn)
            // Lưu ý: Để chính xác tuyệt đối, lẽ ra ta nên lưu giá điện vào bảng HoaDon lúc tính tiền.
            // Ở đây ta tính ngược lại từ Tổng tiền / Tiêu thụ (hoặc lấy tham số hiện tại)

            var dto = new HoaDonInDTO
            {
                TenPhong = hd.Phong.TenPhong,
                Thang = hd.Thang,
                Nam = hd.Nam,
                TienPhong = hd.TienPhong,
                TienDichVu = hd.TienDichVu,
                TienMang = hd.TienMang,
                TongTien = hd.TongTien,
                ThanhTienDien = hd.TienDien,
                ThanhTienNuoc = hd.TienNuoc
            };

            if (so != null)
            {
                dto.DienCu = so.ChiSoDienCu;
                dto.DienMoi = so.ChiSoDienMoi;
                dto.NuocCu = so.ChiSoNuocCu;
                dto.NuocMoi = so.ChiSoNuocMoi;

                // Tính giá hiển thị (Tránh chia cho 0)
                if (dto.DienTieuThu > 0) dto.GiaDien = hd.TienDien / dto.DienTieuThu;
                if (dto.NuocTieuThu > 0) dto.GiaNuoc = hd.TienNuoc / dto.NuocTieuThu;
            }

            return dto;
        }
    }
}