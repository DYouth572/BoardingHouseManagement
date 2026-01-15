using System;
using System.Windows.Forms;

namespace BoardingHouse.WinForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Các thiết lập giao diện chuẩn của Windows (Giữ nguyên)
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Khởi tạo form đăng nhập
            frmDangNhap fLogin = new frmDangNhap();

            // 2. Hiển thị form đăng nhập dưới dạng hộp thoại (Dialog)
            // Nó sẽ dừng code tại đây cho đến khi user bấm Đăng nhập hoặc Tắt form
            if (fLogin.ShowDialog() == DialogResult.OK)
            {
                // 3. Nếu Login trả về OK (Thành công) -> Chạy Form Main
                Application.Run(new frmMain());
            }
            else
            {
                // 4. Nếu user tắt form Login hoặc bấm Thoát -> Dừng chương trình luôn
                Application.Exit();
            }
        }
    }
}