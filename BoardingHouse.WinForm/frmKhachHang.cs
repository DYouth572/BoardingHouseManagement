using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoardingHouse.BLL.Implements;
using BoardingHouse.BLL.Interfaces;

namespace BoardingHouse.WinForm
{
    public partial class frmKhachHang : Form
    {
        // Khai báo Service
        private readonly IKhachHangService _service;

        public frmKhachHang()
        {
            InitializeComponent();
            _service = new KhachHangService(); // Khởi tạo Service
        }

        // --- 1. SỰ KIỆN LOAD FORM (Tải dữ liệu lên lưới) ---
        private async void frmKhachHang_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        // Hàm dùng chung để tải lại dữ liệu
        private async Task LoadData()
        {
            // Lấy danh sách từ Database
            var list = await _service.GetAllAsync();

            // Đổ vào lưới
            dgvKhachHang.DataSource = null; // Reset lưới
            dgvKhachHang.DataSource = list;

            // Đặt tên cột tiếng Việt cho đẹp
            SetHeader();
        }

        private void SetHeader()
        {
            if (dgvKhachHang.Columns.Count > 0)
            {
                dgvKhachHang.Columns["MaKhach"].HeaderText = "Mã KH";
                dgvKhachHang.Columns["HoTen"].HeaderText = "Họ và Tên";
                dgvKhachHang.Columns["CCCD"].HeaderText = "CCCD/CMND";
                dgvKhachHang.Columns["SDT"].HeaderText = "Số Điện Thoại";
                dgvKhachHang.Columns["QueQuan"].HeaderText = "Quê Quán";
                dgvKhachHang.Columns["GioiTinh"].HeaderText = "Giới Tính";

                // Ẩn cột không cần thiết (nếu có cột điều hướng thừa)
                // dgvKhachHang.Columns["HopDongs"].Visible = false; 
                // 2. ẨN CÁC CỘT THỪA (Không cần thiết)
                // Đây là bước quan trọng để giấu 2 cột lạ kia đi
                if (dgvKhachHang.Columns.Contains("HopDongs"))
                    dgvKhachHang.Columns["HopDongs"].Visible = false;

                if (dgvKhachHang.Columns.Contains("ChiTietKhachOs"))
                    dgvKhachHang.Columns["ChiTietKhachOs"].Visible = false;
            }
        }

        // --- 2. SỰ KIỆN NÚT THÊM ---
        private async void btnThem_Click(object sender, EventArgs e)
        {
            // Mở form Chi tiết (Form nhập liệu ta làm lúc nãy)
            // Truyền null vì là Thêm mới
            frmChiTietKhachHang f = new frmChiTietKhachHang(null);

            // Nếu form con đóng lại và trả về OK (tức là đã Lưu thành công)
            if (f.ShowDialog() == DialogResult.OK)
            {
                await LoadData(); // Tải lại lưới để hiện người mới thêm
            }
        }

        // --- 3. SỰ KIỆN NÚT SỬA ---
        private async void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào đang được chọn không
            if (dgvKhachHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!");
                return;
            }

            // Lấy Mã khách hàng từ dòng đang chọn
            int id = (int)dgvKhachHang.CurrentRow.Cells["MaKhach"].Value;

            // Mở form Chi tiết nhưng truyền ID vào (Chế độ Sửa)
            frmChiTietKhachHang f = new frmChiTietKhachHang(id);

            if (f.ShowDialog() == DialogResult.OK)
            {
                await LoadData(); // Tải lại lưới sau khi sửa
            }
        }

        // --- 4. SỰ KIỆN NÚT XÓA ---
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null) return;

            int id = (int)dgvKhachHang.CurrentRow.Cells["MaKhach"].Value;
            string ten = dgvKhachHang.CurrentRow.Cells["HoTen"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa khách hàng: {ten}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await _service.DeleteAsync(id);
                MessageBox.Show("Đã xóa thành công!");
                await LoadData();
            }
        }

        // --- 5. TÌM KIẾM ---
        private async void btnTim_Click(object sender, EventArgs e)
        {
            var ketQua = await _service.SearchAsync(txtTimKiem.Text);
            dgvKhachHang.DataSource = null;
            dgvKhachHang.DataSource = ketQua;
            SetHeader();
        }

        // --- 6. LÀM MỚI ---
        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            await LoadData();
        }
    }
}