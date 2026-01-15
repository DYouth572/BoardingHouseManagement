using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BoardingHouse.BLL.Implements;
using BoardingHouse.DAL.DTO;

namespace BoardingHouse.WinForm
{
    public partial class frmLapHoaDon : Form
    {
        // Khởi tạo Service để giao tiếp với Database
        private readonly HoaDonService _service = new HoaDonService();

        // Biến này để lưu danh sách đang hiển thị trên lưới
        private List<GhiDienNuocDTO> _listDTO;

        public frmLapHoaDon()
        {
            InitializeComponent();

            // Tự động điền tháng năm hiện tại khi mở form
            cboThang.Text = DateTime.Now.Month.ToString();
            txtNam.Text = DateTime.Now.Year.ToString();
        }

        // --- NÚT 1: LẤY DỮ LIỆU TỪ DB LÊN LƯỚI ---
        private async void btnLayDuLieu_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate nhập liệu cơ bản
                if (string.IsNullOrWhiteSpace(cboThang.Text) || string.IsNullOrWhiteSpace(txtNam.Text))
                {
                    MessageBox.Show("Vui lòng chọn Tháng và Năm!", "Thông báo");
                    return;
                }

                int thang = int.Parse(cboThang.Text);
                int nam = int.Parse(txtNam.Text);

                // Gọi Service: 
                // 1. Tìm phòng đang thuê.
                // 2. Lấy chỉ số cũ tháng trước.
                // 3. Lấy giá điện/nước mặc định từ bảng ThamSo.
                _listDTO = await _service.GetDanhSachGhiDienNuoc(thang, nam);

                // Đổ dữ liệu vào lưới
                dgvHoaDon.DataSource = null; // Reset lưới
                dgvHoaDon.DataSource = _listDTO;

                // Gọi hàm trang trí cho đẹp
                DinhDangLuoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message);
            }
        }

        // --- HÀM TRANG TRÍ LƯỚI (UX: Giúp người dùng biết ô nào cần nhập) ---
        private void DinhDangLuoi()
        {
            if (dgvHoaDon.Columns.Count == 0) return;

            // 1. Ẩn các cột kỹ thuật (ID...)
            if (dgvHoaDon.Columns.Contains("MaPhong")) dgvHoaDon.Columns["MaPhong"].Visible = false;

            // 2. Cột Tên Phòng (Cố định, in đậm)
            if (dgvHoaDon.Columns.Contains("TenPhong"))
            {
                dgvHoaDon.Columns["TenPhong"].HeaderText = "Phòng";
                dgvHoaDon.Columns["TenPhong"].ReadOnly = true;
                dgvHoaDon.Columns["TenPhong"].Width = 70;
                dgvHoaDon.Columns["TenPhong"].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                dgvHoaDon.Columns["TenPhong"].DisplayIndex = 0; // Luôn hiện đầu tiên
            }

            // --- SỬA LẠI: ĐẶT VỊ TRÍ CỘT GIÁ PHÒNG ---
            if (dgvHoaDon.Columns.Contains("GiaPhong"))
            {
                dgvHoaDon.Columns["GiaPhong"].Visible = true;
                dgvHoaDon.Columns["GiaPhong"].HeaderText = "Giá Phòng";
                dgvHoaDon.Columns["GiaPhong"].DefaultCellStyle.Format = "N0";
                dgvHoaDon.Columns["GiaPhong"].ReadOnly = true;
                // [QUAN TRỌNG] Đặt ngay sau tên phòng để dễ nhìn
                dgvHoaDon.Columns["GiaPhong"].DisplayIndex = 1;
            }

            // --- PHẦN ĐIỆN ---
            // Chỉ số cũ (Chỉ đọc - Đã sửa lại ReadOnly = true cho đúng logic)
            if (dgvHoaDon.Columns.Contains("ChiSoDienCu"))
            {
                dgvHoaDon.Columns["ChiSoDienCu"].HeaderText = "Điện Cũ";
                dgvHoaDon.Columns["ChiSoDienCu"].ReadOnly = true; // Sửa thành true (người dùng không được sửa số cũ)
                dgvHoaDon.Columns["ChiSoDienCu"].Width = 60;
            }

            // Chỉ số mới (Cho nhập - Màu vàng)
            if (dgvHoaDon.Columns.Contains("ChiSoDienMoi"))
            {
                dgvHoaDon.Columns["ChiSoDienMoi"].ReadOnly = false;
                dgvHoaDon.Columns["ChiSoDienMoi"].HeaderText = "Điện Mới";
                dgvHoaDon.Columns["ChiSoDienMoi"].DefaultCellStyle.BackColor = Color.LightYellow;
                dgvHoaDon.Columns["ChiSoDienMoi"].Width = 60;
            }

            // Giá Điện (Cho sửa - Màu xanh nhạt)
            if (dgvHoaDon.Columns.Contains("GiaDien"))
            {
                dgvHoaDon.Columns["GiaDien"].HeaderText = "Giá Điện";
                dgvHoaDon.Columns["GiaDien"].DefaultCellStyle.Format = "N0";
                dgvHoaDon.Columns["GiaDien"].DefaultCellStyle.BackColor = Color.LightCyan;
                dgvHoaDon.Columns["GiaDien"].Width = 80;
            }

            // --- PHẦN NƯỚC ---
            if (dgvHoaDon.Columns.Contains("ChiSoNuocCu"))
            {
                dgvHoaDon.Columns["ChiSoNuocCu"].HeaderText = "Nước Cũ";
                dgvHoaDon.Columns["ChiSoNuocCu"].ReadOnly = true; // Sửa thành true
                dgvHoaDon.Columns["ChiSoNuocCu"].Width = 60;
            }

            if (dgvHoaDon.Columns.Contains("ChiSoNuocMoi"))
            {
                dgvHoaDon.Columns["ChiSoNuocMoi"].ReadOnly = false;
                dgvHoaDon.Columns["ChiSoNuocMoi"].HeaderText = "Nước Mới";
                dgvHoaDon.Columns["ChiSoNuocMoi"].DefaultCellStyle.BackColor = Color.LightYellow;
                dgvHoaDon.Columns["ChiSoNuocMoi"].Width = 60;
            }

            if (dgvHoaDon.Columns.Contains("GiaNuoc"))
            {
                dgvHoaDon.Columns["GiaNuoc"].HeaderText = "Giá Nước";
                dgvHoaDon.Columns["GiaNuoc"].DefaultCellStyle.Format = "N0";
                dgvHoaDon.Columns["GiaNuoc"].DefaultCellStyle.BackColor = Color.LightCyan;
                dgvHoaDon.Columns["GiaNuoc"].Width = 80;
            }

            // --- CÁC CỘT KHÁC ---
            if (dgvHoaDon.Columns.Contains("TienMang"))
            {
                dgvHoaDon.Columns["TienMang"].HeaderText = "Tiền Mạng";
                dgvHoaDon.Columns["TienMang"].DefaultCellStyle.Format = "N0";
                dgvHoaDon.Columns["TienMang"].DefaultCellStyle.BackColor = Color.LightYellow;
                dgvHoaDon.Columns["TienMang"].Width = 90;
            }

            if (dgvHoaDon.Columns.Contains("TienDichVu"))
            {
                dgvHoaDon.Columns["TienDichVu"].HeaderText = "Dịch Vụ";
                dgvHoaDon.Columns["TienDichVu"].DefaultCellStyle.Format = "N0";
                dgvHoaDon.Columns["TienDichVu"].DefaultCellStyle.BackColor = Color.LightYellow;
            }
        }

        // --- NÚT 2: LƯU & TÍNH TIỀN ---
        private async void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dữ liệu không
            if (_listDTO == null || _listDTO.Count == 0) return;

            // VALIDATION: Kiểm tra lỗi nhập liệu trước khi lưu
            foreach (var item in _listDTO)
            {
                if (item.ChiSoDienMoi < item.ChiSoDienCu)
                {
                    MessageBox.Show($"Lỗi tại phòng {item.TenPhong}: Chỉ số Điện Mới ({item.ChiSoDienMoi}) nhỏ hơn Cũ ({item.ChiSoDienCu})!\nVui lòng kiểm tra lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng lại, không lưu
                }
                if (item.ChiSoNuocMoi < item.ChiSoNuocCu)
                {
                    MessageBox.Show($"Lỗi tại phòng {item.TenPhong}: Chỉ số Nước Mới ({item.ChiSoNuocMoi}) nhỏ hơn Cũ ({item.ChiSoNuocCu})!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Gửi xuống Service để lưu
            try
            {
                btnLuu.Enabled = false;
                btnLuu.Text = "Đang xử lý...";

                int thang = int.Parse(cboThang.Text);
                int nam = int.Parse(txtNam.Text);

                // Service sẽ lấy GIÁ TỪ LƯỚI (item.GiaDien...) để tính toán
                await _service.LuuVaTinhTienAsync(thang, nam, _listDTO);

                MessageBox.Show("Thành công!\nĐã lưu chỉ số và Tính hóa đơn xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Lấy lỗi gốc nằm sâu bên trong
                var loiChiTiet = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                MessageBox.Show("Lỗi chi tiết: " + loiChiTiet, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLuu.Enabled = true;
                btnLuu.Text = "LƯU VÀ TÍNH TIỀN";
            }
        }
    }
}