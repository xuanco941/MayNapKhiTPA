namespace MayNapKhiTPA.Forms
{
    partial class FormData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormData));
            this.panelSearchData = new System.Windows.Forms.Panel();
            this.dataGridViewSearchData = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxApSuatNap = new LW_PhanMemBaoGia.MyControls.TextBoxT();
            this.buttonCustom2 = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelSearchData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchData)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSearchData
            // 
            this.panelSearchData.AutoScroll = true;
            this.panelSearchData.Controls.Add(this.tableLayoutPanel1);
            this.panelSearchData.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSearchData.Location = new System.Drawing.Point(729, 0);
            this.panelSearchData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSearchData.Name = "panelSearchData";
            this.panelSearchData.Size = new System.Drawing.Size(277, 564);
            this.panelSearchData.TabIndex = 2;
            // 
            // dataGridViewSearchData
            // 
            this.dataGridViewSearchData.AllowUserToAddRows = false;
            this.dataGridViewSearchData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSearchData.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSearchData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSearchData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearchData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSearchData.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSearchData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewSearchData.Name = "dataGridViewSearchData";
            this.dataGridViewSearchData.ReadOnly = true;
            this.dataGridViewSearchData.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewSearchData.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewSearchData.RowTemplate.Height = 25;
            this.dataGridViewSearchData.Size = new System.Drawing.Size(729, 564);
            this.dataGridViewSearchData.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(277, 564);
            this.tableLayoutPanel1.TabIndex = 55;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Green;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 385);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxApSuatNap);
            this.panel1.Controls.Add(this.buttonCustom2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 396);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 164);
            this.panel1.TabIndex = 57;
            // 
            // textBoxApSuatNap
            // 
            this.textBoxApSuatNap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxApSuatNap.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxApSuatNap.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.textBoxApSuatNap.BorderFocusColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBoxApSuatNap.BorderRadius = 5;
            this.textBoxApSuatNap.BorderSize = 1;
            this.textBoxApSuatNap.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxApSuatNap.Location = new System.Drawing.Point(38, 35);
            this.textBoxApSuatNap.Multiline = false;
            this.textBoxApSuatNap.Name = "textBoxApSuatNap";
            this.textBoxApSuatNap.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxApSuatNap.PasswordChar = false;
            this.textBoxApSuatNap.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxApSuatNap.PlaceholderText = "Nhập mã mẻ . . .";
            this.textBoxApSuatNap.Size = new System.Drawing.Size(202, 35);
            this.textBoxApSuatNap.TabIndex = 51;
            this.textBoxApSuatNap.Texts = "Nhập mã mẻ . . .";
            this.textBoxApSuatNap.UnderlinedStyle = false;
            this.textBoxApSuatNap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxApSuatNap_KeyPress);
            // 
            // buttonCustom2
            // 
            this.buttonCustom2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCustom2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonCustom2.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.buttonCustom2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonCustom2.BorderRadius = 3;
            this.buttonCustom2.BorderSize = 0;
            this.buttonCustom2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCustom2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustom2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonCustom2.ForeColor = System.Drawing.Color.Black;
            this.buttonCustom2.Image = ((System.Drawing.Image)(resources.GetObject("buttonCustom2.Image")));
            this.buttonCustom2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCustom2.Location = new System.Drawing.Point(75, 91);
            this.buttonCustom2.Name = "buttonCustom2";
            this.buttonCustom2.Size = new System.Drawing.Size(132, 32);
            this.buttonCustom2.TabIndex = 52;
            this.buttonCustom2.Text = "Xem chi tiết";
            this.buttonCustom2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCustom2.TextColor = System.Drawing.Color.Black;
            this.buttonCustom2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCustom2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(22, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "- Thời gian bắt đầu :  chưa có";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(22, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "- Ngày khởi tạo :  chưa có";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(22, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "- Thời gian kết thúc :  chưa có";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(22, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "- Người thực hiện :  chưa có";
            // 
            // FormData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 564);
            this.Controls.Add(this.dataGridViewSearchData);
            this.Controls.Add(this.panelSearchData);
            this.Name = "FormData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dữ liệu mẻ nạp chi tiết";
            this.panelSearchData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchData)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelSearchData;
        private System.Windows.Forms.DataGridView dataGridViewSearchData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private LW_PhanMemBaoGia.MyControls.TextBoxT textBoxApSuatNap;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonCustom2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}