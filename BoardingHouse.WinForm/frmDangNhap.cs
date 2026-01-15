using System;
using System.Windows.Forms;
using BoardingHouse.BLL.Implements; // Kết nối BLL
using BoardingHouse.BLL.Interfaces;

namespace BoardingHouse.WinForm
{
    public partial class frmDangNhap : Form
    {
        private readonly INguoiDungService _service;

        public frmDangNhap()
        {
            InitializeComponent();
            _service = new NguoiDungService(); // Khởi tạo Service
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi hàm LoginAsync bên BLL
                var user = await _service.LoginAsync(txtUser.Text, txtPass.Text);

                // Nếu không văng lỗi -> Thành công
                MessageBox.Show($"Xin chào {user.UserName}!", "Thông báo");

                this.DialogResult = DialogResult.OK; // Báo hiệu cho Program.cs biết là OK
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}