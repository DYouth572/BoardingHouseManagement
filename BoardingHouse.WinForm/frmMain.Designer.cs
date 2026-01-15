namespace BoardingHouse.WinForm
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();
            danhMụcToolStripMenuItem = new ToolStripMenuItem();
            mnuPhong = new ToolStripMenuItem();
            mnuKhachHang = new ToolStripMenuItem();
            tácNghiệpToolStripMenuItem = new ToolStripMenuItem();
            mnuThueTra = new ToolStripMenuItem();
            mnuHoaDon = new ToolStripMenuItem();
            mnuQuanLyThuTien = new ToolStripMenuItem();
            càiĐặtToolStripMenuItem = new ToolStripMenuItem();
            mnuCaiDatGia = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, danhMụcToolStripMenuItem, tácNghiệpToolStripMenuItem, càiĐặtToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuDangXuat, mnuThoat });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(103, 29);
            hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // mnuDangXuat
            // 
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(270, 34);
            mnuDangXuat.Text = "Đăng xuất";
            mnuDangXuat.Click += mnuDangXuat_Click;
            // 
            // mnuThoat
            // 
            mnuThoat.Name = "mnuThoat";
            mnuThoat.Size = new Size(270, 34);
            mnuThoat.Text = "Thoát";
            mnuThoat.Click += mnuThoat_Click;
            // 
            // danhMụcToolStripMenuItem
            // 
            danhMụcToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuPhong, mnuKhachHang });
            danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            danhMụcToolStripMenuItem.Size = new Size(89, 29);
            danhMụcToolStripMenuItem.Text = "Quản lý";
            // 
            // mnuPhong
            // 
            mnuPhong.Name = "mnuPhong";
            mnuPhong.Size = new Size(270, 34);
            mnuPhong.Text = "Phòng trọ";
            mnuPhong.Click += mnuPhong_Click;
            // 
            // mnuKhachHang
            // 
            mnuKhachHang.Name = "mnuKhachHang";
            mnuKhachHang.Size = new Size(270, 34);
            mnuKhachHang.Text = "Khách hàng";
            mnuKhachHang.Click += mnuKhachHang_Click;
            // 
            // tácNghiệpToolStripMenuItem
            // 
            tácNghiệpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuThueTra, mnuHoaDon, mnuQuanLyThuTien });
            tácNghiệpToolStripMenuItem.Name = "tácNghiệpToolStripMenuItem";
            tácNghiệpToolStripMenuItem.Size = new Size(112, 29);
            tácNghiệpToolStripMenuItem.Text = "Tác nghiệp";
            // 
            // mnuThueTra
            // 
            mnuThueTra.Name = "mnuThueTra";
            mnuThueTra.Size = new Size(261, 34);
            mnuThueTra.Text = "Thuê / Trả phòng";
            mnuThueTra.Click += mnuThueTra_Click;
            // 
            // mnuHoaDon
            // 
            mnuHoaDon.Name = "mnuHoaDon";
            mnuHoaDon.Size = new Size(261, 34);
            mnuHoaDon.Text = "Hóa đơn & Tính tiền";
            mnuHoaDon.Click += mnuHoaDon_Click;
            // 
            // mnuQuanLyThuTien
            // 
            mnuQuanLyThuTien.Name = "mnuQuanLyThuTien";
            mnuQuanLyThuTien.Size = new Size(261, 34);
            mnuQuanLyThuTien.Text = "Quản Lý Thu Tiền";
            mnuQuanLyThuTien.Click += mnuQuanLyThuTien_Click;
            // 
            // càiĐặtToolStripMenuItem
            // 
            càiĐặtToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuCaiDatGia });
            càiĐặtToolStripMenuItem.Name = "càiĐặtToolStripMenuItem";
            càiĐặtToolStripMenuItem.Size = new Size(83, 29);
            càiĐặtToolStripMenuItem.Text = "Cài đặt";
            // 
            // mnuCaiDatGia
            // 
            mnuCaiDatGia.Name = "mnuCaiDatGia";
            mnuCaiDatGia.Size = new Size(238, 34);
            mnuCaiDatGia.Text = "Quy định giá cả";
            mnuCaiDatGia.Click += mnuCaiDatGia_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(16, 29);
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            Text = "Phần mềm Quản lý Nhà trọ";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem danhMụcToolStripMenuItem;
        private ToolStripMenuItem mnuPhong;
        private ToolStripMenuItem mnuKhachHang;
        private ToolStripMenuItem tácNghiệpToolStripMenuItem;
        private ToolStripMenuItem mnuThueTra;
        private ToolStripMenuItem mnuHoaDon;
        private ToolStripMenuItem càiĐặtToolStripMenuItem;
        private ToolStripMenuItem mnuCaiDatGia;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem mnuQuanLyThuTien;
    }
}