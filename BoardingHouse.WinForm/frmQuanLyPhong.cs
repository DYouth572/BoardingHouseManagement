using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoardingHouse.BLL.Implements;
using BoardingHouse.BLL.Interfaces;

namespace BoardingHouse.WinForm
{
    public partial class frmQuanLyPhong : Form
    {
        // 1. BỎ TỪ KHÓA READONLY ĐỂ CÓ THỂ KHỞI TẠO LẠI SERVICE
        private IPhongService _phongService;

        public frmQuanLyPhong()
        {
            InitializeComponent();
            // Khởi tạo lần đầu
            _phongService = new PhongService();
        }

        private async void frmQuanLyPhong_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        // --- HÀM TẢI DỮ LIỆU (ĐÃ SỬA ĐỂ FIX LỖI KHÔNG CẬP NHẬT) ---
        private async Task LoadData()
        {
            try
            {
                // 2. KHỞI TẠO LẠI SERVICE ĐỂ XÓA CACHE CŨ, ÉP LẤY DỮ LIỆU MỚI TỪ DB
                _phongService = new PhongService();

                // Lấy dữ liệu mới nhất
                var listPhong = await _phongService.GetAllPhongDTOAsync();

                // Gán null trước để "làm sạch" lưới
                dgvPhong.DataSource = null;

                // Gán dữ liệu mới
                dgvPhong.DataSource = listPhong;

                // Định dạng lại cột
                CustomizeGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void CustomizeGrid()
        {
            if (dgvPhong.Columns.Count > 0)
            {
                // Ẩn các cột không cần thiết
                if (dgvPhong.Columns.Contains("MaLoai")) dgvPhong.Columns["MaLoai"].Visible = false;

                dgvPhong.Columns["MaPhong"].HeaderText = "Mã";
                dgvPhong.Columns["TenPhong"].HeaderText = "Tên Phòng";
                dgvPhong.Columns["TenLoaiPhong"].HeaderText = "Loại Phòng";

                dgvPhong.Columns["DonGia"].HeaderText = "Giá";
                dgvPhong.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dgvPhong.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvPhong.Columns["TrangThai"].HeaderText = "Trạng Thái";
            }
        }

        // --- CÁC NÚT CHỨC NĂNG ---

        private async void btnTim_Click(object sender, EventArgs e)
        {
            // Khi tìm kiếm cũng nên khởi tạo lại service để đảm bảo chính xác
            _phongService = new PhongService();
            var result = await _phongService.SearchPhongDTOAsync(txtTimKiem.Text);

            dgvPhong.DataSource = null;
            dgvPhong.DataSource = result;
            CustomizeGrid();
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            await LoadData();
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            frmChiTietPhong f = new frmChiTietPhong(null);
            // Kiểm tra kết quả trả về từ form con
            if (f.ShowDialog() == DialogResult.OK)
            {
                await LoadData(); // Tải lại lưới (lúc này sẽ gọi new PhongService nên chắc chắn có dữ liệu mới)
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null) return;

            int id = (int)dgvPhong.CurrentRow.Cells["MaPhong"].Value;

            frmChiTietPhong f = new frmChiTietPhong(id);
            if (f.ShowDialog() == DialogResult.OK)
            {
                await LoadData();
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null) return;
            int id = (int)dgvPhong.CurrentRow.Cells["MaPhong"].Value;

            if (MessageBox.Show("Xóa phòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // Trước khi xóa cũng nên làm mới service để tránh lỗi concurrency
                    _phongService = new PhongService();
                    await _phongService.DeletePhongAsync(id);

                    MessageBox.Show("Đã xóa thành công!");
                    await LoadData();
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null && ex.InnerException.Message.Contains("REFERENCE constraint"))
                    {
                        MessageBox.Show("Không thể xóa phòng này vì đã phát sinh Hóa đơn hoặc Hợp đồng trong quá khứ.\n\nHãy chuyển trạng thái sang 'Bảo trì' hoặc 'Ngừng hoạt động'.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }
    }
}