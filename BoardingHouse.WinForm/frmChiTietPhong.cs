using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using BoardingHouse.BLL.Implements;
using BoardingHouse.BLL.Interfaces;
using BoardingHouse.DAL.Entities;

namespace BoardingHouse.WinForm
{
    public partial class frmChiTietPhong : Form
    {
        private readonly IPhongService _phongService;
        private readonly ILoaiPhongService _loaiPhongService;
        private int? _maPhong = null;

        public frmChiTietPhong(int? maPhong = null)
        {
            InitializeComponent();
            _phongService = new PhongService();
            _loaiPhongService = new LoaiPhongService();
            _maPhong = maPhong;

            this.Text = (_maPhong == null) ? "Thêm Phòng Mới" : "Cập Nhật Phòng";
        }

        private async void frmChiTietPhong_Load(object sender, EventArgs e)
        {
            // 1. Load danh sách Loại phòng
            // Cbo chứa nguyên object LoaiPhong, nhưng chỉ hiện TenLoai
            var listLoai = await _loaiPhongService.GetAllAsync();
            cboLoaiPhong.DataSource = listLoai;
            cboLoaiPhong.DisplayMember = "TenLoai";
            cboLoaiPhong.ValueMember = "MaLoai";

            // 2. Load trạng thái
            List<string> listTrangThai = new List<string>() { "Trống", "Đang thuê", "Sửa chữa" };
            cboTrangThai.DataSource = listTrangThai;

            // 3. Xử lý hiển thị dữ liệu (SỬA)
            if (_maPhong != null)
            {
                // Cách tối ưu: Lấy list PhongDTO để hiển thị nhanh, 
                // hoặc lấy Entity nếu cần full thông tin. Ở đây logic cũ của bạn ổn.
                var list = await _phongService.GetAllAsync();
                var phong = list.Find(p => p.MaPhong == _maPhong);
                if (phong != null)
                {
                    txtTenPhong.Text = phong.TenPhong;
                    cboLoaiPhong.SelectedValue = phong.MaLoai;
                    cboTrangThai.SelectedItem = phong.TrangThai;
                }
            }
            else // THÊM
            {
                cboTrangThai.SelectedItem = "Trống";
                // Mặc định chọn loại đầu tiên
                if (cboLoaiPhong.Items.Count > 0) cboLoaiPhong.SelectedIndex = 0;
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validate
                if (string.IsNullOrWhiteSpace(txtTenPhong.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên phòng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. LẤY GIÁ PHÒNG TỪ LOẠI PHÒNG (FIX BUG QUAN TRỌNG)
                // Vì cboLoaiPhong.DataSource là List<LoaiPhong>, nên SelectedItem chính là object LoaiPhong
                var loaiPhongDuocChon = cboLoaiPhong.SelectedItem as LoaiPhong;
                decimal giaMacDinh = loaiPhongDuocChon != null ? loaiPhongDuocChon.DonGia : 0;

                // 3. Tạo đối tượng
                var p = new Phong
                {
                    TenPhong = txtTenPhong.Text.Trim(),
                    MaLoai = (int)cboLoaiPhong.SelectedValue,
                    TrangThai = cboTrangThai.SelectedItem.ToString(),
                    GiaPhong = giaMacDinh // <--- Đã sửa: Gán giá vào đây
                };

                // 4. Lưu xuống DB
                if (_maPhong == null) // THÊM
                {
                    // Đã bỏ dòng p.TrangThai = "Trống" để tôn trọng lựa chọn ở ComboBox
                    await _phongService.AddPhongAsync(p);
                    MessageBox.Show($"Thêm phòng thành công!\nGiá áp dụng: {giaMacDinh:N0} đ", "Thông báo");
                }
                else // SỬA
                {
                    p.MaPhong = _maPhong.Value; // Gán ID cũ

                    // Logic mở rộng: Nếu sửa phòng mà đổi loại phòng -> Có cập nhật giá mới theo loại không?
                    // Code hiện tại: Có cập nhật (vì dòng code lấy giaMacDinh ở trên).

                    await _phongService.UpdatePhongAsync(p);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}