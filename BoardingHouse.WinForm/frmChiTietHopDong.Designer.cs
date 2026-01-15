namespace BoardingHouse.WinForm
{
    partial class frmChiTietHopDong
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
            cboPhong = new ComboBox();
            txtGiaPhong = new TextBox();
            cboKhach = new ComboBox();
            btnThemKhach = new Button();
            dtpNgayBatDau = new DateTimePicker();
            txtTienCoc = new TextBox();
            btnHuy = new Button();
            btnLuu = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(109, 52);
            label1.Name = "label1";
            label1.Size = new Size(165, 25);
            label1.TabIndex = 0;
            label1.Text = "Chọn Phòng Trống:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(109, 113);
            label2.Name = "label2";
            label2.Size = new Size(164, 25);
            label2.TabIndex = 1;
            label2.Text = "Giá Phòng / Tháng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(120, 176);
            label3.Name = "label3";
            label3.Size = new Size(153, 25);
            label3.TabIndex = 2;
            label3.Text = "Chọn Khách Thuê:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(148, 243);
            label4.Name = "label4";
            label4.Size = new Size(125, 25);
            label4.TabIndex = 3;
            label4.Text = "Ngày Bắt Đầu:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(158, 314);
            label5.Name = "label5";
            label5.Size = new Size(116, 25);
            label5.TabIndex = 4;
            label5.Text = "Tiền Đặt Cọc:";
            // 
            // cboPhong
            // 
            cboPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhong.FormattingEnabled = true;
            cboPhong.Location = new Point(294, 49);
            cboPhong.Name = "cboPhong";
            cboPhong.Size = new Size(234, 33);
            cboPhong.TabIndex = 5;
            cboPhong.SelectedIndexChanged += cboPhong_SelectedIndexChanged;
            // 
            // txtGiaPhong
            // 
            txtGiaPhong.Location = new Point(294, 113);
            txtGiaPhong.Name = "txtGiaPhong";
            txtGiaPhong.Size = new Size(234, 31);
            txtGiaPhong.TabIndex = 6;
            // 
            // cboKhach
            // 
            cboKhach.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhach.FormattingEnabled = true;
            cboKhach.Location = new Point(294, 176);
            cboKhach.Name = "cboKhach";
            cboKhach.Size = new Size(234, 33);
            cboKhach.TabIndex = 7;
            // 
            // btnThemKhach
            // 
            btnThemKhach.Location = new Point(621, 193);
            btnThemKhach.Name = "btnThemKhach";
            btnThemKhach.Size = new Size(128, 55);
            btnThemKhach.TabIndex = 8;
            btnThemKhach.Text = "Thêm khách";
            btnThemKhach.UseVisualStyleBackColor = true;
            btnThemKhach.Click += btnThemKhach_Click;
            // 
            // dtpNgayBatDau
            // 
            dtpNgayBatDau.Format = DateTimePickerFormat.Short;
            dtpNgayBatDau.Location = new Point(294, 243);
            dtpNgayBatDau.Name = "dtpNgayBatDau";
            dtpNgayBatDau.Size = new Size(234, 31);
            dtpNgayBatDau.TabIndex = 9;
            // 
            // txtTienCoc
            // 
            txtTienCoc.Location = new Point(294, 311);
            txtTienCoc.Name = "txtTienCoc";
            txtTienCoc.Size = new Size(234, 31);
            txtTienCoc.TabIndex = 10;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(483, 403);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(120, 53);
            btnHuy.TabIndex = 12;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(194, 403);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(170, 53);
            btnLuu.TabIndex = 13;
            btnLuu.Text = "Lập Hợp Đồng";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // frmChiTietHopDong
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 494);
            Controls.Add(btnLuu);
            Controls.Add(btnHuy);
            Controls.Add(txtTienCoc);
            Controls.Add(dtpNgayBatDau);
            Controls.Add(btnThemKhach);
            Controls.Add(cboKhach);
            Controls.Add(txtGiaPhong);
            Controls.Add(cboPhong);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmChiTietHopDong";
            Text = "frmChiTietHopDong";
            Load += frmChiTietHopDong_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cboPhong;
        private TextBox txtGiaPhong;
        private ComboBox cboKhach;
        private Button btnThemKhach;
        private DateTimePicker dtpNgayBatDau;
        private TextBox txtTienCoc;
        private Button button1;
        private Button btnHuy;
        private Button btnLuu;
    }
}