namespace MayNapKhiTPA
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTaiKhoan = new LW_PhanMemBaoGia.MyControls.TextBoxT();
            this.textBoxMatKhau = new LW_PhanMemBaoGia.MyControls.TextBoxT();
            this.buttonExit = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonDangNhap = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(123, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mật khẩu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(120, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tài khoản:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(165, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 34);
            this.label3.TabIndex = 10;
            this.label3.Text = "Máy Nạp Khí TPA";
            // 
            // textBoxTaiKhoan
            // 
            this.textBoxTaiKhoan.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxTaiKhoan.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.textBoxTaiKhoan.BorderFocusColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBoxTaiKhoan.BorderRadius = 5;
            this.textBoxTaiKhoan.BorderSize = 1;
            this.textBoxTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTaiKhoan.Location = new System.Drawing.Point(203, 111);
            this.textBoxTaiKhoan.Multiline = false;
            this.textBoxTaiKhoan.Name = "textBoxTaiKhoan";
            this.textBoxTaiKhoan.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxTaiKhoan.PasswordChar = false;
            this.textBoxTaiKhoan.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxTaiKhoan.PlaceholderText = "";
            this.textBoxTaiKhoan.Size = new System.Drawing.Size(207, 33);
            this.textBoxTaiKhoan.TabIndex = 14;
            this.textBoxTaiKhoan.Texts = "";
            this.textBoxTaiKhoan.UnderlinedStyle = false;
            this.textBoxTaiKhoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTaiKhoan_KeyDown);
            // 
            // textBoxMatKhau
            // 
            this.textBoxMatKhau.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxMatKhau.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.textBoxMatKhau.BorderFocusColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBoxMatKhau.BorderRadius = 5;
            this.textBoxMatKhau.BorderSize = 1;
            this.textBoxMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMatKhau.Location = new System.Drawing.Point(203, 158);
            this.textBoxMatKhau.Multiline = false;
            this.textBoxMatKhau.Name = "textBoxMatKhau";
            this.textBoxMatKhau.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxMatKhau.PasswordChar = true;
            this.textBoxMatKhau.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxMatKhau.PlaceholderText = "";
            this.textBoxMatKhau.Size = new System.Drawing.Size(207, 33);
            this.textBoxMatKhau.TabIndex = 15;
            this.textBoxMatKhau.Texts = "";
            this.textBoxMatKhau.UnderlinedStyle = false;
            this.textBoxMatKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTaiKhoan_KeyDown);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Firebrick;
            this.buttonExit.BackgroundColor = System.Drawing.Color.Firebrick;
            this.buttonExit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonExit.BorderRadius = 15;
            this.buttonExit.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExit.Location = new System.Drawing.Point(326, 208);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(84, 36);
            this.buttonExit.TabIndex = 13;
            this.buttonExit.Text = "Thoát";
            this.buttonExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonExit.TextColor = System.Drawing.Color.White;
            this.buttonExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonDangNhap
            // 
            this.buttonDangNhap.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonDangNhap.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.buttonDangNhap.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonDangNhap.BorderRadius = 15;
            this.buttonDangNhap.BorderSize = 0;
            this.buttonDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDangNhap.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDangNhap.ForeColor = System.Drawing.Color.White;
            this.buttonDangNhap.Image = ((System.Drawing.Image)(resources.GetObject("buttonDangNhap.Image")));
            this.buttonDangNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDangNhap.Location = new System.Drawing.Point(203, 208);
            this.buttonDangNhap.Name = "buttonDangNhap";
            this.buttonDangNhap.Size = new System.Drawing.Size(96, 36);
            this.buttonDangNhap.TabIndex = 12;
            this.buttonDangNhap.Text = "Đăng nhập";
            this.buttonDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDangNhap.TextColor = System.Drawing.Color.White;
            this.buttonDangNhap.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonDangNhap.UseVisualStyleBackColor = false;
            this.buttonDangNhap.Click += new System.EventHandler(this.buttonDangNhap_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(560, 312);
            this.Controls.Add(this.textBoxMatKhau);
            this.Controls.Add(this.textBoxTaiKhoan);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDangNhap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonDangNhap;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonExit;
        private LW_PhanMemBaoGia.MyControls.TextBoxT textBoxTaiKhoan;
        private LW_PhanMemBaoGia.MyControls.TextBoxT textBoxMatKhau;
    }
}