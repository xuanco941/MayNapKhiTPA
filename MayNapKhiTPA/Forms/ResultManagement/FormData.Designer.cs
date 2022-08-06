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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormData));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelSearchData = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxIDResult = new LW_PhanMemBaoGia.MyControls.TextBoxT();
            this.buttonViewDetsil = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelMaMe = new System.Windows.Forms.Label();
            this.labelFullNameUser = new System.Windows.Forms.Label();
            this.labelMachine = new System.Windows.Forms.Label();
            this.labelNgayKetThuc = new System.Windows.Forms.Label();
            this.labelNgayBatDau = new System.Windows.Forms.Label();
            this.dataGridViewSearchData = new System.Windows.Forms.DataGridView();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSearchData.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchData)).BeginInit();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(277, 564);
            this.tableLayoutPanel1.TabIndex = 55;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxIDResult);
            this.panel1.Controls.Add(this.buttonViewDetsil);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 366);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 194);
            this.panel1.TabIndex = 57;
            // 
            // textBoxIDResult
            // 
            this.textBoxIDResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIDResult.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxIDResult.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.textBoxIDResult.BorderFocusColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBoxIDResult.BorderRadius = 5;
            this.textBoxIDResult.BorderSize = 1;
            this.textBoxIDResult.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIDResult.Location = new System.Drawing.Point(37, 47);
            this.textBoxIDResult.Multiline = false;
            this.textBoxIDResult.Name = "textBoxIDResult";
            this.textBoxIDResult.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxIDResult.PasswordChar = false;
            this.textBoxIDResult.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxIDResult.PlaceholderText = "Nhập mã mẻ . . .";
            this.textBoxIDResult.Size = new System.Drawing.Size(202, 35);
            this.textBoxIDResult.TabIndex = 51;
            this.textBoxIDResult.Texts = "Nhập mã mẻ . . .";
            this.textBoxIDResult.UnderlinedStyle = false;
            this.textBoxIDResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxIDResult_KeyDown);
            this.textBoxIDResult.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIDResult_KeyPress);
            // 
            // buttonViewDetsil
            // 
            this.buttonViewDetsil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonViewDetsil.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonViewDetsil.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.buttonViewDetsil.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonViewDetsil.BorderRadius = 3;
            this.buttonViewDetsil.BorderSize = 0;
            this.buttonViewDetsil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonViewDetsil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonViewDetsil.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonViewDetsil.ForeColor = System.Drawing.Color.Black;
            this.buttonViewDetsil.Image = ((System.Drawing.Image)(resources.GetObject("buttonViewDetsil.Image")));
            this.buttonViewDetsil.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonViewDetsil.Location = new System.Drawing.Point(74, 103);
            this.buttonViewDetsil.Name = "buttonViewDetsil";
            this.buttonViewDetsil.Size = new System.Drawing.Size(132, 32);
            this.buttonViewDetsil.TabIndex = 52;
            this.buttonViewDetsil.Text = "Xem chi tiết";
            this.buttonViewDetsil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonViewDetsil.TextColor = System.Drawing.Color.Black;
            this.buttonViewDetsil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonViewDetsil.UseVisualStyleBackColor = false;
            this.buttonViewDetsil.Click += new System.EventHandler(this.buttonViewDetsil_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelStatus);
            this.groupBox1.Controls.Add(this.labelMaMe);
            this.groupBox1.Controls.Add(this.labelFullNameUser);
            this.groupBox1.Controls.Add(this.labelMachine);
            this.groupBox1.Controls.Add(this.labelNgayKetThuc);
            this.groupBox1.Controls.Add(this.labelNgayBatDau);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Green;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 355);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // labelMaMe
            // 
            this.labelMaMe.AutoSize = true;
            this.labelMaMe.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaMe.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelMaMe.Location = new System.Drawing.Point(3, 23);
            this.labelMaMe.Name = "labelMaMe";
            this.labelMaMe.Size = new System.Drawing.Size(70, 17);
            this.labelMaMe.TabIndex = 5;
            this.labelMaMe.Text = "- Mã mẻ : ";
            // 
            // labelFullNameUser
            // 
            this.labelFullNameUser.AutoSize = true;
            this.labelFullNameUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFullNameUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelFullNameUser.Location = new System.Drawing.Point(3, 79);
            this.labelFullNameUser.Name = "labelFullNameUser";
            this.labelFullNameUser.Size = new System.Drawing.Size(126, 17);
            this.labelFullNameUser.TabIndex = 4;
            this.labelFullNameUser.Text = "- Người thực hiện : ";
            // 
            // labelMachine
            // 
            this.labelMachine.AutoSize = true;
            this.labelMachine.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMachine.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelMachine.Location = new System.Drawing.Point(3, 50);
            this.labelMachine.Name = "labelMachine";
            this.labelMachine.Size = new System.Drawing.Size(115, 17);
            this.labelMachine.TabIndex = 3;
            this.labelMachine.Text = "- Máy thực hiện : ";
            // 
            // labelNgayKetThuc
            // 
            this.labelNgayKetThuc.AutoSize = true;
            this.labelNgayKetThuc.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNgayKetThuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelNgayKetThuc.Location = new System.Drawing.Point(3, 136);
            this.labelNgayKetThuc.Name = "labelNgayKetThuc";
            this.labelNgayKetThuc.Size = new System.Drawing.Size(138, 17);
            this.labelNgayKetThuc.TabIndex = 2;
            this.labelNgayKetThuc.Text = "- Thời gian kết thúc : ";
            // 
            // labelNgayBatDau
            // 
            this.labelNgayBatDau.AutoSize = true;
            this.labelNgayBatDau.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNgayBatDau.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelNgayBatDau.Location = new System.Drawing.Point(3, 109);
            this.labelNgayBatDau.Name = "labelNgayBatDau";
            this.labelNgayBatDau.Size = new System.Drawing.Size(135, 17);
            this.labelNgayBatDau.TabIndex = 0;
            this.labelNgayBatDau.Text = "- Thời gian bắt đầu : ";
            // 
            // dataGridViewSearchData
            // 
            this.dataGridViewSearchData.AllowUserToAddRows = false;
            this.dataGridViewSearchData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSearchData.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSearchData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewSearchData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearchData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSearchData.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSearchData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewSearchData.Name = "dataGridViewSearchData";
            this.dataGridViewSearchData.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSearchData.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewSearchData.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewSearchData.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewSearchData.RowTemplate.Height = 25;
            this.dataGridViewSearchData.Size = new System.Drawing.Size(729, 564);
            this.dataGridViewSearchData.TabIndex = 3;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelStatus.Location = new System.Drawing.Point(3, 162);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(89, 17);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "- Trạng thái : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 53;
            this.label1.Text = "Mã mẻ nạp :";
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelSearchData;
        private System.Windows.Forms.DataGridView dataGridViewSearchData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private LW_PhanMemBaoGia.MyControls.TextBoxT textBoxIDResult;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonViewDetsil;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelMachine;
        private System.Windows.Forms.Label labelNgayKetThuc;
        private System.Windows.Forms.Label labelNgayBatDau;
        private System.Windows.Forms.Label labelFullNameUser;
        private System.Windows.Forms.Label labelMaMe;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label1;
    }
}