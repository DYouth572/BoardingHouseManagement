namespace BoardingHouse.WinForm
{
    partial class frmQuanLyHoaDon
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
            cboThang = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            txtNam = new TextBox();
            chkChuaThu = new CheckBox();
            btnXem = new Button();
            dgvDanhSach = new DataGridView();
            btnThanhToan = new Button();
            btnInHoaDon = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSach).BeginInit();
            SuspendLayout();
            // 
            // cboThang
            // 
            cboThang.FormattingEnabled = true;
            cboThang.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            cboThang.Location = new Point(186, 55);
            cboThang.Name = "cboThang";
            cboThang.Size = new Size(162, 33);
            cboThang.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(84, 58);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 1;
            label1.Text = "Tháng:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(84, 114);
            label2.Name = "label2";
            label2.Size = new Size(54, 25);
            label2.TabIndex = 2;
            label2.Text = "Năm:";
            // 
            // txtNam
            // 
            txtNam.Location = new Point(186, 111);
            txtNam.Name = "txtNam";
            txtNam.Size = new Size(162, 31);
            txtNam.TabIndex = 3;
            txtNam.Text = "2026";
            // 
            // chkChuaThu
            // 
            chkChuaThu.AutoSize = true;
            chkChuaThu.Location = new Point(90, 169);
            chkChuaThu.Name = "chkChuaThu";
            chkChuaThu.Size = new Size(209, 29);
            chkChuaThu.TabIndex = 4;
            chkChuaThu.Text = "Chỉ hiện chưa thu tiền";
            chkChuaThu.UseVisualStyleBackColor = true;
            // 
            // btnXem
            // 
            btnXem.BackColor = SystemColors.ActiveCaption;
            btnXem.Location = new Point(481, 71);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(186, 68);
            btnXem.TabIndex = 5;
            btnXem.Text = "XEM DANH SÁCH";
            btnXem.UseVisualStyleBackColor = false;
            btnXem.Click += btnXem_Click;
            // 
            // dgvDanhSach
            // 
            dgvDanhSach.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDanhSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSach.Location = new Point(12, 224);
            dgvDanhSach.Name = "dgvDanhSach";
            dgvDanhSach.RowHeadersWidth = 62;
            dgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSach.Size = new Size(843, 309);
            dgvDanhSach.TabIndex = 6;
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = SystemColors.ActiveCaption;
            btnThanhToan.Location = new Point(119, 575);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(229, 60);
            btnThanhToan.TabIndex = 7;
            btnThanhToan.Text = "XÁC NHẬN THANH TOÁN";
            btnThanhToan.UseVisualStyleBackColor = false;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.BackColor = SystemColors.ActiveCaption;
            btnInHoaDon.Location = new Point(500, 575);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.Size = new Size(178, 60);
            btnInHoaDon.TabIndex = 8;
            btnInHoaDon.Text = "IN HÓA ĐƠN";
            btnInHoaDon.UseVisualStyleBackColor = false;
            btnInHoaDon.Click += btnInHoaDon_Click;
            // 
            // frmQuanLyHoaDon
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 673);
            Controls.Add(btnInHoaDon);
            Controls.Add(btnThanhToan);
            Controls.Add(dgvDanhSach);
            Controls.Add(btnXem);
            Controls.Add(chkChuaThu);
            Controls.Add(txtNam);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboThang);
            Name = "frmQuanLyHoaDon";
            Text = "frmQuanLyHoaDon";
            ((System.ComponentModel.ISupportInitialize)dgvDanhSach).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboThang;
        private Label label1;
        private Label label2;
        private TextBox txtNam;
        private CheckBox chkChuaThu;
        private Button btnXem;
        private DataGridView dgvDanhSach;
        private Button btnThanhToan;
        private Button btnInHoaDon;
    }
}