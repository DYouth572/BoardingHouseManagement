using System;
using System.Windows.Forms;
using BoardingHouse.BLL.Implements;
using BoardingHouse.BLL.Interfaces;

namespace BoardingHouse.WinForm
{
    public partial class frmCaiDat : Form
    {
        // Khai báo Interface chuẩn
        private readonly IThamSoService _service = new ThamSoService();

        public frmCaiDat()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private decimal ParseTienTe(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0;
            string cleanStr = input.Replace(",", "").Replace(".", "").Trim();
            if (decimal.TryParse(cleanStr, out decimal result)) return result;
            return 0;
        }

        private async void frmCaiDat_Load(object sender, EventArgs e)
        {
            try
            {
                // SỬA TẠI ĐÂY: Thêm Async vào tên hàm
                txtGiaDien.Text = (await _service.GetGiaTriAsync("GIA_DIEN")).ToString("N0");
                txtGiaNuoc.Text = (await _service.GetGiaTriAsync("GIA_NUOC")).ToString("N0");
                txtDichVu.Text = (await _service.GetGiaTriAsync("GIA_DICH_VU")).ToString("N0");
                txtMang.Text = (await _service.GetGiaTriAsync("GIA_MANG")).ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                decimal dien = ParseTienTe(txtGiaDien.Text);
                decimal nuoc = ParseTienTe(txtGiaNuoc.Text);
                decimal dv = ParseTienTe(txtDichVu.Text);
                decimal mang = ParseTienTe(txtMang.Text);

                if (dien < 0 || nuoc < 0 || dv < 0 || mang < 0)
                {
                    MessageBox.Show("Vui lòng nhập giá trị không âm!", "Cảnh báo");
                    return;
                }

                btnLuu.Enabled = false;
                btnLuu.Text = "Đang lưu...";

                // SỬA TẠI ĐÂY: Thêm Async vào tên hàm
                await _service.UpdateGiaTriAsync("GIA_DIEN", dien);
                await _service.UpdateGiaTriAsync("GIA_NUOC", nuoc);
                await _service.UpdateGiaTriAsync("GIA_DICH_VU", dv);
                await _service.UpdateGiaTriAsync("GIA_MANG", mang);

                MessageBox.Show("Cập nhật thành công!\nGiá mới sẽ áp dụng cho hóa đơn tháng sau.", "Thông báo");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
            finally
            {
                btnLuu.Enabled = true;
                btnLuu.Text = "LƯU";
            }
        }
    }
}