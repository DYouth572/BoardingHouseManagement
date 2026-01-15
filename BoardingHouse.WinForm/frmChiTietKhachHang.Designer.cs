namespace BoardingHouse.WinForm
{
    partial class frmChiTietKhachHang
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cboGioiTinh = new ComboBox();
            txtHoTen = new TextBox();
            txtCCCD = new TextBox();
            txtSDT = new TextBox();
            txtQueQuan = new TextBox();
            btnLuu = new Button();
            btnHuy = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(176, 69);
            label1.Name = "label1";
            label1.Size = new Size(66, 25);
            label1.TabIndex = 0;
            label1.Text = "Họ tên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(129, 127);
            label2.Name = "label2";
            label2.Size = new Size(118, 25);
            label2.TabIndex = 1;
            label2.Text = "CCCD/CMND";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(125, 176);
            label3.Name = "label3";
            label3.Size = new Size(117, 25);
            label3.TabIndex = 2;
            label3.Text = "Số điện thoại";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(152, 239);
            label4.Name = "label4";
            label4.Size = new Size(90, 25);
            label4.TabIndex = 3;
            label4.Text = "Quê quán";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(164, 289);
            label5.Name = "label5";
            label5.Size = new Size(78, 25);
            label5.TabIndex = 4;
            label5.Text = "Giới tính";
            // 
            // cboGioiTinh
            // 
            cboGioiTinh.FormattingEnabled = true;
            cboGioiTinh.Location = new Point(272, 286);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(182, 33);
            cboGioiTinh.TabIndex = 5;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(272, 63);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(182, 31);
            txtHoTen.TabIndex = 6;
            // 
            // txtCCCD
            // 
            txtCCCD.Location = new Point(272, 124);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(182, 31);
            txtCCCD.TabIndex = 7;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(270, 176);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(184, 31);
            txtSDT.TabIndex = 8;
            // 
            // txtQueQuan
            // 
            txtQueQuan.Location = new Point(272, 233);
            txtQueQuan.Name = "txtQueQuan";
            txtQueQuan.Size = new Size(182, 31);
            txtQueQuan.TabIndex = 9;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(185, 372);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(112, 34);
            btnLuu.TabIndex = 10;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(402, 372);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(112, 34);
            btnHuy.TabIndex = 11;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // frmChiTietKhachHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 524);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(txtQueQuan);
            Controls.Add(txtSDT);
            Controls.Add(txtCCCD);
            Controls.Add(txtHoTen);
            Controls.Add(cboGioiTinh);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmChiTietKhachHang";
            Text = "frmChiTietKhachHang";
            Load += frmChiTietKhachHang_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cboGioiTinh;
        private TextBox txtHoTen;
        private TextBox txtCCCD;
        private TextBox txtSDT;
        private TextBox txtQueQuan;
        private Button btnLuu;
        private Button btnHuy;
    }
}