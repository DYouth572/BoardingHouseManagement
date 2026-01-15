using System;
using System.Drawing;
using System.Windows.Forms;
using BoardingHouse.BLL.Implements;
using BoardingHouse.DAL.Entities;

namespace BoardingHouse.WinForm
{
    public partial class frmChiTietHopDong : Form
    {
        private readonly HopDongService _service = new HopDongService();

        public frmChiTietHopDong()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Lập Hợp Đồng Thuê Phòng (Check-In)";
        }

        private async void frmChiTietHopDong_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Load danh sách Phòng đang TRỐNG
                var listPhong = await _service.GetPhongTrongAsync();
                cboPhong.DataSource = listPhong;
                cboPhong.DisplayMember = "TenPhong"; // Hiện tên P.101
                cboPhong.ValueMember = "MaPhong";    // Giá trị là ID
                cboPhong.SelectedIndex = -1;         // Chưa chọn gì cả

                // 2. Load danh sách Khách Hàng
                await LoadKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // Hàm riêng để load khách (để dùng lại khi thêm khách mới)
        private async System.Threading.Tasks.Task LoadKhachHang()
        {
            var listKhach = await _service.GetKhachHangAsync();
            cboKhach.DataSource = listKhach;
            cboKhach.DisplayMember = "HoTen";
            cboKhach.ValueMember = "MaKhach";
            cboKhach.SelectedIndex = -1;
        }

        // SỰ KIỆN: Khi chọn phòng -> Tự động điền giá tiền vào ô TextBox
        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhong.SelectedIndex != -1)
            {
                // Ép kiểu an toàn từ SelectedItem
                var phongChon = cboPhong.SelectedItem as Phong;
                if (phongChon != null)
                {
                    // Format tiền tệ cho đẹp (ví dụ: 3,000,000)
                    txtGiaPhong.Text = phongChon.GiaPhong.ToString("N0");
                }
            }
            else
            {
                txtGiaPhong.Text = "0";
            }
        }

        // SỰ KIỆN: Thêm nhanh khách hàng mới
        private async void btnThemKhach_Click(object sender, EventArgs e)
        {
            frmChiTietKhachHang f = new frmChiTietKhachHang(null); // Mở form thêm khách
            if (f.ShowDialog() == DialogResult.OK)
            {
                await LoadKhachHang(); // Tải lại danh sách khách
                // Chọn ngay ông khách vừa thêm (người cuối cùng)
                if (cboKhach.Items.Count > 0)
                {
                    cboKhach.SelectedIndex = cboKhach.Items.Count - 1;
                }
            }
        }

        // --- HÀM TIỆN ÍCH: Xử lý chuỗi tiền tệ (Xóa dấu phẩy, dấu chấm) ---
        private decimal ParseTienTe(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0;
            // Xóa tất cả dấu phẩy và chấm để lấy số thô (Ví dụ: "3,000,000" -> "3000000")
            string cleanStr = input.Replace(",", "").Replace(".", "").Trim();
            if (decimal.TryParse(cleanStr, out decimal result))
            {
                return result;
            }
            return 0; // Trả về 0 nếu nhập ký tự lạ
        }

        // --- SỰ KIỆN LƯU (ĐÃ ĐƯỢC SỬA LỖI LOGIC) ---
        private async void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra nhập liệu và lấy ID an toàn
            // Convert.ToInt32 trả về 0 nếu null, tránh lỗi crash như ép kiểu (int)
            int maPhong = Convert.ToInt32(cboPhong.SelectedValue);
            int maKhach = Convert.ToInt32(cboKhach.SelectedValue);

            if (maPhong <= 0 || maKhach <= 0)
            {
                MessageBox.Show("Vui lòng chọn Phòng và Khách thuê hợp lệ!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Xử lý tiền tệ an toàn bằng hàm tiện ích
            decimal tienCoc = ParseTienTe(txtTienCoc.Text);
            decimal giaThue = ParseTienTe(txtGiaPhong.Text);

            // Validate giá (Tùy chọn)
            if (giaThue <= 0)
            {
                MessageBox.Show("Giá phòng không hợp lệ (phải lớn hơn 0)!", "Cảnh báo");
                return;
            }

            // 3. Tạo đối tượng Hợp Đồng
            var hd = new HopDong
            {
                MaPhong = maPhong,
                MaKhach = maKhach,
                NgayBatDau = dtpNgayBatDau.Value,

                TienCoc = tienCoc,       // Giá trị đã xử lý sạch sẽ
                GiaPhong = giaThue,      // Giá trị đã xử lý sạch sẽ

                DaKetThuc = false
            };

            // 4. Gọi Service
            try
            {
                // Khóa nút để tránh user bấm liên tục
                btnLuu.Enabled = false;
                btnLuu.Text = "Đang xử lý...";

                await _service.ThuePhongAsync(hd, null); // null ở đây là danh sách người ở ghép (chưa làm form nhập nên để null)

                MessageBox.Show("Lập hợp đồng thành công!\nPhòng đã chuyển sang trạng thái Đang Thuê.", "Thông báo");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Mở lại nút nếu có lỗi xảy ra để user sửa và bấm lại
                btnLuu.Enabled = true;
                btnLuu.Text = "Lập Hợp Đồng";
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}