namespace BoardingHouse.WinForm
{
    partial class frmCaiDat
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
            txtGiaDien = new TextBox();
            label2 = new Label();
            txtGiaNuoc = new TextBox();
            label3 = new Label();
            txtDichVu = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtMang = new TextBox();
            btnLuu = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(104, 77);
            label1.Name = "label1";
            label1.Size = new Size(151, 25);
            label1.TabIndex = 0;
            label1.Text = "Giá Điện (đ/kWh):";
            // 
            // txtGiaDien
            // 
            txtGiaDien.Location = new Point(279, 74);
            txtGiaDien.Name = "txtGiaDien";
            txtGiaDien.Size = new Size(150, 31);
            txtGiaDien.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(107, 140);
            label2.Name = "label2";
            label2.Size = new Size(148, 25);
            label2.TabIndex = 2;
            label2.Text = "Giá Nước (đ/m3):";
            // 
            // txtGiaNuoc
            // 
            txtGiaNuoc.Location = new Point(279, 137);
            txtGiaNuoc.Name = "txtGiaNuoc";
            txtGiaNuoc.Size = new Size(150, 31);
            txtGiaNuoc.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 202);
            label3.Name = "label3";
            label3.Size = new Size(215, 25);
            label3.TabIndex = 4;
            label3.Text = "Dịch vụ chung (đ/phòng):";
            // 
            // txtDichVu
            // 
            txtDichVu.Location = new Point(279, 202);
            txtDichVu.Name = "txtDichVu";
            txtDichVu.Size = new Size(150, 31);
            txtDichVu.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(70, 264);
            label4.Name = "label4";
            label4.Size = new Size(185, 25);
            label4.TabIndex = 6;
            label4.Text = "Tiền Mạng (đ/phòng):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(86, 300);
            label5.Name = "label5";
            label5.Size = new Size(0, 25);
            label5.TabIndex = 7;
            // 
            // txtMang
            // 
            txtMang.Location = new Point(279, 264);
            txtMang.Name = "txtMang";
            txtMang.Size = new Size(150, 31);
            txtMang.TabIndex = 8;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = SystemColors.Highlight;
            btnLuu.Location = new Point(194, 341);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(161, 54);
            btnLuu.TabIndex = 9;
            btnLuu.Text = "LƯU ";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // frmCaiDat
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 456);
            Controls.Add(btnLuu);
            Controls.Add(txtMang);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtDichVu);
            Controls.Add(label3);
            Controls.Add(txtGiaNuoc);
            Controls.Add(label2);
            Controls.Add(txtGiaDien);
            Controls.Add(label1);
            Name = "frmCaiDat";
            Text = "frmCaiDat";
            Load += frmCaiDat_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtGiaDien;
        private Label label2;
        private TextBox txtGiaNuoc;
        private Label label3;
        private TextBox txtDichVu;
        private Label label4;
        private Label label5;
        private TextBox txtMang;
        private Button btnLuu;
    }
}