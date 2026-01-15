namespace BoardingHouse.WinForm
{
    partial class frmChiTietPhong
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
            txtTenPhong = new TextBox();
            cboLoaiPhong = new ComboBox();
            btnLuu = new Button();
            btnHuy = new Button();
            label3 = new Label();
            cboTrangThai = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(128, 90);
            label1.Name = "label1";
            label1.Size = new Size(96, 25);
            label1.TabIndex = 0;
            label1.Text = "Tên phòng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(122, 148);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 1;
            label2.Text = "Loại phòng";
            // 
            // txtTenPhong
            // 
            txtTenPhong.Location = new Point(247, 90);
            txtTenPhong.Name = "txtTenPhong";
            txtTenPhong.Size = new Size(197, 31);
            txtTenPhong.TabIndex = 2;
            // 
            // cboLoaiPhong
            // 
            cboLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiPhong.FormattingEnabled = true;
            cboLoaiPhong.Location = new Point(247, 148);
            cboLoaiPhong.Name = "cboLoaiPhong";
            cboLoaiPhong.Size = new Size(197, 33);
            cboLoaiPhong.TabIndex = 3;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(166, 281);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(112, 34);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(376, 281);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(112, 34);
            btnHuy.TabIndex = 5;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(128, 203);
            label3.Name = "label3";
            label3.Size = new Size(89, 25);
            label3.TabIndex = 6;
            label3.Text = "Trạng thái";
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(247, 203);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(197, 33);
            cboTrangThai.TabIndex = 7;
            // 
            // frmChiTietPhong
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(648, 450);
            Controls.Add(cboTrangThai);
            Controls.Add(label3);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(cboLoaiPhong);
            Controls.Add(txtTenPhong);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmChiTietPhong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin phòng";
            Load += frmChiTietPhong_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtTenPhong;
        private ComboBox cboLoaiPhong;
        private Button btnLuu;
        private Button btnHuy;
        private Label label3;
        private ComboBox cboTrangThai;
    }
}