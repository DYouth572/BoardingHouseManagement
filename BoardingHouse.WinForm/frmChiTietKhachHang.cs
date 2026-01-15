using System;
using System.Windows.Forms;
using BoardingHouse.BLL.Implements;
using BoardingHouse.BLL.Interfaces;
using BoardingHouse.DAL.Entities;

namespace BoardingHouse.WinForm
{
    public partial class frmChiTietKhachHang : Form
    {
        private readonly IKhachHangService _service;
        private int? _maKhach = null;

        public frmChiTietKhachHang(int? id = null)
        {
            InitializeComponent();
            _service = new KhachHangService();
            _maKhach = id;
            this.Text = (_maKhach == null) ? "Thêm Khách Hàng" : "Cập Nhật Khách Hàng";
        }

        private async void frmChiTietKhachHang_Load(object sender, EventArgs e)
        {
            cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });
            cboGioiTinh.SelectedIndex = 0;

            if (_maKhach != null) // Trường hợp SỬA
            {
                var list = await _service.GetAllAsync();
                var kh = list.Find(x => x.MaKhach == _maKhach);
                if (kh != null)
                {
                    txtHoTen.Text = kh.HoTen;
                    txtCCCD.Text = kh.CCCD;
                    txtSDT.Text = kh.SDT;
                    txtQueQuan.Text = kh.QueQuan;
                    cboGioiTinh.SelectedItem = kh.GioiTinh;
                }
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập tên và số điện thoại!");
                return;
            }

            var kh = new KhachHang
            {
                HoTen = txtHoTen.Text,
                CCCD = txtCCCD.Text,
                SDT = txtSDT.Text,
                QueQuan = txtQueQuan.Text,
                GioiTinh = cboGioiTinh.SelectedItem.ToString()
            };

            try
            {
                if (_maKhach == null)
                {
                    await _service.AddAsync(kh);
                    MessageBox.Show("Thêm thành công!");
                }
                else
                {
                    kh.MaKhach = _maKhach.Value;
                    await _service.UpdateAsync(kh);
                    MessageBox.Show("Cập nhật thành công!");
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            // Tìm đến đoạn catch ở cuối hàm btnLuu_Click và thay bằng đoạn này:
            catch (Exception ex)
            {
                // Lấy lỗi chi tiết bên trong (Inner Exception)
                var loiChiTiet = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                // Kiểm tra nếu lỗi do chuỗi quá dài (Lỗi CCCD 13 số)
                if (loiChiTiet.Contains("truncated"))
                {
                    MessageBox.Show($"Lỗi: Dữ liệu nhập vào quá dài so với quy định của Database!\n(Ví dụ: CCCD chỉ cho phép 12 số nhưng bạn nhập 13).");
                }
                else
                {
                    MessageBox.Show("Lỗi chi tiết: " + loiChiTiet);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form khi bấm Hủy
        }
    }
}