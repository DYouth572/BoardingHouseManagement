using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoardingHouse.BLL.Implements;

namespace BoardingHouse.WinForm
{
    public partial class frmHopDong : Form
    {
        // Gọi Service để xử lý dữ liệu
        private readonly HopDongService _service = new HopDongService();

        public frmHopDong()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Hợp Đồng Thuê Phòng";
        }

        private async void frmHopDong_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        // HÀM TẢI DỮ LIỆU
        private async Task LoadData()
        {
            try
            {
                // Lấy danh sách DTO (đã có tên phòng, tên khách, giá tiền...)
                var list = await _service.GetAllHopDongDTOAsync();

                dgvHopDong.DataSource = null;
                dgvHopDong.DataSource = list;

                SetHeader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // HÀM ĐỊNH DẠNG CỘT
        private void SetHeader()
        {
            if (dgvHopDong.Columns.Count > 0)
            {
                dgvHopDong.Columns["MaHopDong"].HeaderText = "Mã HĐ";
                dgvHopDong.Columns["TenPhong"].HeaderText = "Phòng";
                dgvHopDong.Columns["TenKhachHang"].HeaderText = "Khách Hàng";
                dgvHopDong.Columns["SDT"].HeaderText = "Liên Hệ";

                // Cột Giá tiền (Quan trọng: Đã lấy từ Entity HopDong)
                dgvHopDong.Columns["GiaPhong"].HeaderText = "Giá Thuê";
                dgvHopDong.Columns["GiaPhong"].DefaultCellStyle.Format = "N0"; // 3,000,000
                dgvHopDong.Columns["GiaPhong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvHopDong.Columns["TienCoc"].HeaderText = "Tiền Cọc";
                dgvHopDong.Columns["TienCoc"].DefaultCellStyle.Format = "N0";

                dgvHopDong.Columns["NgayBatDau"].HeaderText = "Ngày Check-in";
                dgvHopDong.Columns["TrangThaiHienThi"].HeaderText = "Trạng Thái"; // Cột tính toán trong DTO

                // Ẩn các cột kỹ thuật không cần thiết
                if (dgvHopDong.Columns.Contains("DaKetThuc")) dgvHopDong.Columns["DaKetThuc"].Visible = false;
                if (dgvHopDong.Columns.Contains("NgayKetThuc")) dgvHopDong.Columns["NgayKetThuc"].Visible = false;
            }
        }

        // NÚT THUÊ PHÒNG MỚI (CHECK-IN)
        private async void btnThem_Click(object sender, EventArgs e)
        {
            // Mở form Chi Tiết
            frmChiTietHopDong f = new frmChiTietHopDong();

            // Nếu form con trả về OK (tức là đã Lưu thành công)
            if (f.ShowDialog() == DialogResult.OK)
            {
                await LoadData(); // Tải lại danh sách
            }
        }

        // NÚT TRẢ PHÒNG (CHECK-OUT)
        private async void btnTraPhong_Click(object sender, EventArgs e)
        {
            if (dgvHopDong.CurrentRow == null) return;

            // Lấy thông tin dòng đang chọn
            int id = (int)dgvHopDong.CurrentRow.Cells["MaHopDong"].Value;
            bool daKetThuc = (bool)dgvHopDong.CurrentRow.Cells["DaKetThuc"].Value; // Cần cột ẩn này để check logic
            string tenPhong = dgvHopDong.CurrentRow.Cells["TenPhong"].Value.ToString();

            // 1. Kiểm tra logic
            if (daKetThuc)
            {
                MessageBox.Show("Hợp đồng này ĐÃ KẾT THÚC rồi, không thể trả phòng nữa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Hỏi xác nhận
            if (MessageBox.Show($"Bạn có chắc muốn làm thủ tục TRẢ PHÒNG cho {tenPhong}?\n\nPhòng sẽ được chuyển về trạng thái TRỐNG.",
                "Xác nhận Thanh Lý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // 3. Gọi Service để xử lý (Update HĐ + Update Phòng)
                    await _service.TraPhongAsync(id);

                    MessageBox.Show("Trả phòng thành công!");
                    await LoadData(); // Refresh lại lưới
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            await LoadData();
        }
    }
}