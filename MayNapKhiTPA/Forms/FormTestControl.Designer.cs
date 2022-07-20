namespace MayNapKhiTPA.Forms
{
    partial class FormTestControl
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
            this.buttonDangNhap = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.textBoxT = new LW_PhanMemBaoGia.MyControls.TextBoxT();
            this.toggleButton = new LW_PhanMemBaoGia.MyControls.ToggleButton();
            this.buttonCustom1 = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.SuspendLayout();
            // 
            // buttonDangNhap
            // 
            this.buttonDangNhap.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonDangNhap.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.buttonDangNhap.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonDangNhap.BorderRadius = 20;
            this.buttonDangNhap.BorderSize = 0;
            this.buttonDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDangNhap.ForeColor = System.Drawing.Color.White;
            this.buttonDangNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDangNhap.Location = new System.Drawing.Point(368, 136);
            this.buttonDangNhap.Name = "buttonDangNhap";
            this.buttonDangNhap.Size = new System.Drawing.Size(96, 36);
            this.buttonDangNhap.TabIndex = 12;
            this.buttonDangNhap.Text = "Đăng nhập";
            this.buttonDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDangNhap.TextColor = System.Drawing.Color.White;
            this.buttonDangNhap.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonDangNhap.UseVisualStyleBackColor = false;
            // 
            // textBoxT
            // 
            this.textBoxT.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxT.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.textBoxT.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textBoxT.BorderRadius = 20;
            this.textBoxT.BorderSize = 2;
            this.textBoxT.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxT.Location = new System.Drawing.Point(168, 241);
            this.textBoxT.Multiline = false;
            this.textBoxT.Name = "textBoxT";
            this.textBoxT.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxT.PasswordChar = false;
            this.textBoxT.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxT.PlaceholderText = "";
            this.textBoxT.Size = new System.Drawing.Size(121, 30);
            this.textBoxT.TabIndex = 13;
            this.textBoxT.Texts = "";
            this.textBoxT.UnderlinedStyle = false;
            // 
            // toggleButton
            // 
            this.toggleButton.Location = new System.Drawing.Point(119, 99);
            this.toggleButton.MinimumSize = new System.Drawing.Size(45, 22);
            this.toggleButton.Name = "toggleButton";
            this.toggleButton.OffBackColor = System.Drawing.Color.Gray;
            this.toggleButton.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleButton.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.toggleButton.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toggleButton.Size = new System.Drawing.Size(104, 24);
            this.toggleButton.TabIndex = 14;
            // 
            // buttonCustom1
            // 
            this.buttonCustom1.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonCustom1.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.buttonCustom1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonCustom1.BorderRadius = 20;
            this.buttonCustom1.BorderSize = 0;
            this.buttonCustom1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustom1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustom1.ForeColor = System.Drawing.Color.White;
            this.buttonCustom1.Location = new System.Drawing.Point(352, 207);
            this.buttonCustom1.Name = "buttonCustom1";
            this.buttonCustom1.Size = new System.Drawing.Size(96, 36);
            this.buttonCustom1.TabIndex = 15;
            this.buttonCustom1.Text = "btn no img";
            this.buttonCustom1.TextColor = System.Drawing.Color.White;
            this.buttonCustom1.UseVisualStyleBackColor = false;
            // 
            // FormTestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCustom1);
            this.Controls.Add(this.buttonDangNhap);
            this.Controls.Add(this.textBoxT);
            this.Controls.Add(this.toggleButton);
            this.Name = "FormTestControl";
            this.Text = "FormTestControl";
            this.ResumeLayout(false);

        }

        #endregion
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonDangNhap;
        private LW_PhanMemBaoGia.MyControls.TextBoxT textBoxT;
        private LW_PhanMemBaoGia.MyControls.ToggleButton toggleButton;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonCustom1;
    }
}