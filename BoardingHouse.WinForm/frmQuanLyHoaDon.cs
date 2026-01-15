using BoardingHouse.BLL.Implements;
using BoardingHouse.BLL.Interfaces;
using System;
using System.Drawing; // Dùng cho Font, Color
using System.Windows.Forms;
// QUAN TRỌNG: Thư viện Excel. Nếu báo lỗi đỏ, hãy Add Reference -> COM -> Microsoft Excel Object Library
using Excel = Microsoft.Office.Interop.Excel;

namespace BoardingHouse.WinForm
{
	public partial class frmQuanLyHoaDon : Form
	{
        private readonly IHoaDonService _service = new HoaDonService();

        public frmQuanLyHoaDon()
		{
			InitializeComponent();
			// Mặc định chọn tháng năm hiện tại
			cboThang.Text = DateTime.Now.Month.ToString();
			txtNam.Text = DateTime.Now.Year.ToString();
		}

		// --- NÚT 1: XEM DANH SÁCH ---
		private async void btnXem_Click(object sender, EventArgs e)
		{
			await LoadData();
		}

		// Hàm tải dữ liệu riêng để dùng lại nhiều lần
		private async System.Threading.Tasks.Task LoadData()
		{
			try
			{
				int thang = int.Parse(cboThang.Text);
				int nam = int.Parse(txtNam.Text);
				bool chiXemChuaThu = chkChuaThu.Checked;

				// Gọi hàm lấy danh sách trong Service
				var list = await _service.GetDanhSachHoaDon(thang, nam, chiXemChuaThu);

				dgvDanhSach.DataSource = list;
				DinhDangLuoi();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
			}
		}

		private void DinhDangLuoi()
		{
			if (dgvDanhSach.Columns.Count == 0) return;

			// Ẩn cột ID
			if (dgvDanhSach.Columns.Contains("MaHoaDon")) dgvDanhSach.Columns["MaHoaDon"].Visible = false;

			// Cấu hình cột
			dgvDanhSach.Columns["TenPhong"].HeaderText = "Phòng";
			dgvDanhSach.Columns["TenPhong"].Width = 70;

			dgvDanhSach.Columns["Thang"].HeaderText = "Tháng";
			dgvDanhSach.Columns["Thang"].Width = 50;

			dgvDanhSach.Columns["Nam"].HeaderText = "Năm";
			dgvDanhSach.Columns["Nam"].Width = 60;

			dgvDanhSach.Columns["NgayLap"].HeaderText = "Ngày Lập";
			dgvDanhSach.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy";

			// Hiển thị các khoản tiền chi tiết
			dgvDanhSach.Columns["TienPhong"].HeaderText = "Tiền Phòng";
			dgvDanhSach.Columns["TienPhong"].DefaultCellStyle.Format = "N0";

			dgvDanhSach.Columns["TienDien"].HeaderText = "Tiền Điện";
			dgvDanhSach.Columns["TienDien"].DefaultCellStyle.Format = "N0";

			dgvDanhSach.Columns["TienNuoc"].HeaderText = "Tiền Nước";
			dgvDanhSach.Columns["TienNuoc"].DefaultCellStyle.Format = "N0";

			dgvDanhSach.Columns["TienDichVu"].HeaderText = "Dịch Vụ";
			dgvDanhSach.Columns["TienDichVu"].DefaultCellStyle.Format = "N0";

			if (dgvDanhSach.Columns.Contains("TienMang"))
			{
				dgvDanhSach.Columns["TienMang"].HeaderText = "Tiền Mạng";
				dgvDanhSach.Columns["TienMang"].DefaultCellStyle.Format = "N0";
			}

			// Cột TỔNG TIỀN (Nổi bật)
			dgvDanhSach.Columns["TongTien"].HeaderText = "TỔNG CỘNG";
			dgvDanhSach.Columns["TongTien"].DefaultCellStyle.Format = "N0";
			dgvDanhSach.Columns["TongTien"].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
			dgvDanhSach.Columns["TongTien"].DefaultCellStyle.ForeColor = Color.Red;
			dgvDanhSach.Columns["TongTien"].Width = 110;

			dgvDanhSach.Columns["TrangThai"].HeaderText = "Trạng Thái";
			dgvDanhSach.Columns["TrangThai"].Width = 110;

			dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		}

		// --- NÚT 2: THANH TOÁN ---
		private async void btnThanhToan_Click(object sender, EventArgs e)
		{
			if (dgvDanhSach.CurrentRow == null)
			{
				MessageBox.Show("Vui lòng chọn hóa đơn cần thanh toán!");
				return;
			}

			// Lấy dòng đang chọn
			var row = dgvDanhSach.CurrentRow;
			string trangThai = row.Cells["TrangThai"].Value.ToString();

			if (trangThai == "Đã thanh toán")
			{
				MessageBox.Show("Phòng này đã đóng tiền rồi!");
				return;
			}

			string tenPhong = row.Cells["TenPhong"].Value.ToString();

			if (MessageBox.Show($"Xác nhận thu tiền phòng {tenPhong}?", "Thu tiền", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				try
				{
					int maHoaDon = int.Parse(row.Cells["MaHoaDon"].Value.ToString());

					// Gọi hàm thanh toán trong Service
					await _service.ThanhToanHoaDonAsync(maHoaDon);

					MessageBox.Show("Đã cập nhật trạng thái: ĐÃ THANH TOÁN");

					// Tải lại danh sách để cập nhật trạng thái mới
					await LoadData();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi: " + ex.Message);
				}
			}
		}

		// --- NÚT 3: IN HÓA ĐƠN RA EXCEL ---
		private async void btnInHoaDon_Click(object sender, EventArgs e)
		{
			if (dgvDanhSach.CurrentRow == null)
			{
				MessageBox.Show("Vui lòng chọn hóa đơn cần in!");
				return;
			}

			// Lấy ID hóa đơn
			int maHD = (int)dgvDanhSach.CurrentRow.Cells["MaHoaDon"].Value;

			try
			{
				// 1. LẤY DỮ LIỆU CHI TIẾT ĐỂ IN
				// (Đảm bảo bạn đã thêm hàm GetThongTinInHoaDonAsync vào Service như hướng dẫn trước)
				var data = await _service.GetThongTinInHoaDonAsync(maHD);

				if (data == null)
				{
					MessageBox.Show("Lỗi: Không tìm thấy dữ liệu chi tiết hóa đơn này!");
					return;
				}

				// 2. KHỞI TẠO EXCEL
				Excel.Application xlApp = new Excel.Application();
				if (xlApp == null)
				{
					MessageBox.Show("Máy tính chưa cài đặt Excel!");
					return;
				}

				Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
				Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets[1];

				// --- BẮT ĐẦU VIẾT DỮ LIỆU ---

				// Tiêu đề
				xlWorksheet.Cells[1, 1] = "PHIẾU THU TIỀN NHÀ";
				Excel.Range title = xlWorksheet.Range["A1", "E1"];
				title.Merge();
				title.Font.Bold = true;
				title.Font.Size = 16;
				title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

				xlWorksheet.Cells[2, 1] = $"Phòng: {data.TenPhong} - Tháng {data.Thang}/{data.Nam}";
				xlWorksheet.Range["A2", "E2"].Merge();
				xlWorksheet.Range["A2", "E2"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

				// Header bảng
				int row = 4;
				xlWorksheet.Cells[row, 1] = "Dịch vụ";
				xlWorksheet.Cells[row, 2] = "Số cũ";
				xlWorksheet.Cells[row, 3] = "Số mới";
				xlWorksheet.Cells[row, 4] = "Tiêu thụ/Đơn giá";
				xlWorksheet.Cells[row, 5] = "Thành tiền";

				// Tô đậm header
				xlWorksheet.Range[$"A{row}", $"E{row}"].Font.Bold = true;
				xlWorksheet.Range[$"A{row}", $"E{row}"].Interior.Color = ColorTranslator.ToOle(Color.LightGray);

				// Nội dung chi tiết
				row++; // Tiền phòng
				xlWorksheet.Cells[row, 1] = "Tiền Phòng";
				xlWorksheet.Cells[row, 5] = data.TienPhong;

				row++; // Điện
				xlWorksheet.Cells[row, 1] = "Điện";
				xlWorksheet.Cells[row, 2] = data.DienCu;
				xlWorksheet.Cells[row, 3] = data.DienMoi;
				xlWorksheet.Cells[row, 4] = $"{data.DienTieuThu} x {data.GiaDien:N0}";
				xlWorksheet.Cells[row, 5] = data.ThanhTienDien;

				row++; // Nước
				xlWorksheet.Cells[row, 1] = "Nước";
				xlWorksheet.Cells[row, 2] = data.NuocCu;
				xlWorksheet.Cells[row, 3] = data.NuocMoi;
				xlWorksheet.Cells[row, 4] = $"{data.NuocTieuThu} x {data.GiaNuoc:N0}";
				xlWorksheet.Cells[row, 5] = data.ThanhTienNuoc;

				row++; // Dịch vụ
				xlWorksheet.Cells[row, 1] = "Dịch vụ chung";
				xlWorksheet.Cells[row, 5] = data.TienDichVu;

				row++; // Mạng
				xlWorksheet.Cells[row, 1] = "Internet/Wifi";
				xlWorksheet.Cells[row, 5] = data.TienMang;

				// Tổng cộng
				row++;
				xlWorksheet.Cells[row, 4] = "TỔNG CỘNG:";
				xlWorksheet.Cells[row, 5] = data.TongTien;
				xlWorksheet.Cells[row, 5].Font.Bold = true;
				xlWorksheet.Cells[row, 5].Font.Color = ColorTranslator.ToOle(Color.Red); // Màu đỏ cho Excel

				// Kẻ khung bảng
				Excel.Range content = xlWorksheet.Range["A4", $"E{row}"];
				content.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
				content.Columns.AutoFit(); // Tự động giãn cột

				// Lưu File
				SaveFileDialog save = new SaveFileDialog();
				save.Filter = "Excel Files|*.xlsx";
				save.FileName = $"HoaDon_{data.TenPhong}_{data.Thang}_{data.Nam}.xlsx";

				if (save.ShowDialog() == DialogResult.OK)
				{
					xlWorkbook.SaveAs(save.FileName);
					MessageBox.Show("Xuất file Excel thành công!\n" + save.FileName);
				}

				// Dọn dẹp bộ nhớ Excel (Quan trọng)
				xlWorkbook.Close(false);
				xlApp.Quit();
				System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
			}
		}
	}
}