namespace BoardingHouse.WinForm
{
    partial class frmLapHoaDon
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
            cboThang = new ComboBox();
            btnLayDuLieu = new Button();
            label2 = new Label();
            txtNam = new TextBox();
            dgvHoaDon = new DataGridView();
            btnLuu = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 49);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 0;
            label1.Text = "Tháng:";
            // 
            // cboThang
            // 
            cboThang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThang.FormattingEnabled = true;
            cboThang.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            cboThang.Location = new Point(195, 46);
            cboThang.Name = "cboThang";
            cboThang.Size = new Size(174, 33);
            cboThang.TabIndex = 1;
            // 
            // btnLayDuLieu
            // 
            btnLayDuLieu.BackColor = SystemColors.Info;
            btnLayDuLieu.Location = new Point(560, 29);
            btnLayDuLieu.Name = "btnLayDuLieu";
            btnLayDuLieu.Size = new Size(179, 50);
            btnLayDuLieu.TabIndex = 2;
            btnLayDuLieu.Text = "LẤY DỮ LIỆU";
            btnLayDuLieu.UseVisualStyleBackColor = false;
            btnLayDuLieu.Click += btnLayDuLieu_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(111, 107);
            label2.Name = "label2";
            label2.Size = new Size(54, 25);
            label2.TabIndex = 3;
            label2.Text = "Năm:";
            // 
            // txtNam
            // 
            txtNam.Location = new Point(195, 104);
            txtNam.Name = "txtNam";
            txtNam.Size = new Size(174, 31);
            txtNam.TabIndex = 4;
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new Point(20, 196);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.RowHeadersWidth = 62;
            dgvHoaDon.Size = new Size(855, 307);
            dgvHoaDon.TabIndex = 5;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = SystemColors.ActiveCaption;
            btnLuu.Location = new Point(560, 107);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(179, 54);
            btnLuu.TabIndex = 6;
            btnLuu.Text = "LƯU VÀ TÍNH TIỀN";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // frmLapHoaDon
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(887, 515);
            Controls.Add(btnLuu);
            Controls.Add(dgvHoaDon);
            Controls.Add(txtNam);
            Controls.Add(label2);
            Controls.Add(btnLayDuLieu);
            Controls.Add(cboThang);
            Controls.Add(label1);
            Name = "frmLapHoaDon";
            Text = "frmLapHoaDon";
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cboThang;
        private Button btnLayDuLieu;
        private Label label2;
        private TextBox txtNam;
        private DataGridView dgvHoaDon;
        private Button btnLuu;
    }
}