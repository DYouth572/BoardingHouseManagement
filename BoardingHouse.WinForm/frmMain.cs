using System;
using System.Windows.Forms;

namespace BoardingHouse.WinForm
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // --- HÀM TIỆN ÍCH: Mở form con an toàn ---
        private void OpenChildForm(Form childForm)
        {
            // Kiểm tra xem form này đã mở chưa
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == childForm.GetType())
                {
                    f.Activate(); // Nếu mở rồi thì focus vào nó
                    return;
                }
            }

            // Nếu chưa mở thì cấu hình và hiển thị
            childForm.MdiParent = this; // Gán cha
            childForm.Show();
        }

        // ============================================
        // 1. MENU HỆ THỐNG
        // ============================================

        // Sự kiện click menu Đăng xuất (Tạo sự kiện click cho mnuDangXuat)
        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            // Đóng form Main -> Quay về logic ở Program.cs (sẽ hiện lại Login hoặc thoát)
            this.Close();
        }

        // Sự kiện click menu Thoát (Tạo sự kiện click cho mnuThoat)
        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // ============================================
        // 2. MENU QUẢN LÝ
        // ============================================

        private void mnuPhong_Click(object sender, EventArgs e)
        {
            frmQuanLyPhong f = new frmQuanLyPhong();
            OpenChildForm(f);
            MessageBox.Show("Chức năng đang xây dựng: Quản lý Phòng");
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            // Khai báo form Danh sách(frmKhachHang)
            frmKhachHang formDanhSach = new frmKhachHang();
            // Hiển thị form lên
            formDanhSach.ShowDialog();
            MessageBox.Show("Chức năng đang xây dựng: Quản lý Khách hàng");
        }

       

        // ============================================
        // 3. MENU TÁC NGHIỆP
        // ============================================

        private void mnuThueTra_Click(object sender, EventArgs e)
        {
            frmHopDong f = new frmHopDong();
            f.ShowDialog();
            MessageBox.Show("Chức năng đang xây dựng: Thuê/Trả phòng");
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            frmLapHoaDon f = new frmLapHoaDon();
            f.ShowDialog();
            MessageBox.Show("Chức năng đang xây dựng: Hóa đơn & Tính tiền");
        }
        private void mnuCaiDatGia_Click(object sender, EventArgs e)
        {
            // Form chỉnh sửa giá điện, nước, mạng
            frmCaiDat f = new frmCaiDat();
            f.ShowDialog();
        }

        private void mnuQuanLyThuTien_Click(object sender, EventArgs e)
        {
            frmQuanLyHoaDon f = new frmQuanLyHoaDon();
            f.ShowDialog(); // Dùng ShowDialog để user phải đóng form này mới làm việc khác được
        }
    }
}