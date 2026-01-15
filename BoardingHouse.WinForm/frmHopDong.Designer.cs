namespace BoardingHouse.WinForm
{
    partial class frmHopDong
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
            btnThem = new Button();
            btnTraPhong = new Button();
            dgvHopDong = new DataGridView();
            btnLamMoi = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHopDong).BeginInit();
            SuspendLayout();
            // 
            // btnThem
            // 
            btnThem.Location = new Point(64, 357);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(164, 57);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thuê Phòng Mới";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnTraPhong
            // 
            btnTraPhong.Location = new Point(308, 357);
            btnTraPhong.Name = "btnTraPhong";
            btnTraPhong.Size = new Size(196, 57);
            btnTraPhong.TabIndex = 1;
            btnTraPhong.Text = "Trả Phòng / Thanh Lý";
            btnTraPhong.UseVisualStyleBackColor = true;
            btnTraPhong.Click += btnTraPhong_Click;
            // 
            // dgvHopDong
            // 
            dgvHopDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHopDong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHopDong.Location = new Point(12, 33);
            dgvHopDong.MultiSelect = false;
            dgvHopDong.Name = "dgvHopDong";
            dgvHopDong.RowHeadersWidth = 62;
            dgvHopDong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHopDong.Size = new Size(902, 285);
            dgvHopDong.TabIndex = 3;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(590, 357);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(123, 57);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.Text = "Tải lại dữ liệu";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // frmHopDong
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 472);
            Controls.Add(btnLamMoi);
            Controls.Add(dgvHopDong);
            Controls.Add(btnTraPhong);
            Controls.Add(btnThem);
            Name = "frmHopDong";
            Text = "frmHopDong";
            Load += frmHopDong_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHopDong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnThem;
        private Button btnTraPhong;
        private Button button3;
        private DataGridView dgvHopDong;
        private Button btnLamMoi;
    }
}