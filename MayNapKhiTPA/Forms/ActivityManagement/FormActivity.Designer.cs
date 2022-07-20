using System.Windows.Forms;

namespace MayNapKhiTPA.Forms
{
    partial class FormActivity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormActivity));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewActivity = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonTrangCuoi = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonCustom2 = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerToiNgay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCallFormEmployeeActivities = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelNotify = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelBanGhiMoiTrang = new System.Windows.Forms.Label();
            this.labelTongSoTrang = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivity)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 214F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(914, 493);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 487);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewActivity);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(694, 437);
            this.panel3.TabIndex = 1;
            // 
            // dataGridViewActivity
            // 
            this.dataGridViewActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewActivity.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridViewActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewActivity.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewActivity.Name = "dataGridViewActivity";
            this.dataGridViewActivity.RowTemplate.Height = 25;
            this.dataGridViewActivity.Size = new System.Drawing.Size(694, 437);
            this.dataGridViewActivity.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.buttonTrangCuoi);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 437);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(694, 50);
            this.panel2.TabIndex = 0;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(634, 11);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(57, 23);
            this.button7.TabIndex = 7;
            this.button7.Text = "Đi";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(557, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 20);
            this.textBox1.TabIndex = 5;
            // 
            // buttonTrangCuoi
            // 
            this.buttonTrangCuoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTrangCuoi.Location = new System.Drawing.Point(182, 13);
            this.buttonTrangCuoi.Name = "buttonTrangCuoi";
            this.buttonTrangCuoi.Size = new System.Drawing.Size(51, 20);
            this.buttonTrangCuoi.TabIndex = 3;
            this.buttonTrangCuoi.Text = ">>";
            this.buttonTrangCuoi.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(117, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(51, 20);
            this.button4.TabIndex = 2;
            this.button4.Text = "3";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(58, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(53, 20);
            this.button3.TabIndex = 1;
            this.button3.Text = "2";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button2_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(0, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 20);
            this.button2.TabIndex = 0;
            this.button2.Text = "1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.buttonCallFormEmployeeActivities);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(703, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(208, 487);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonCustom2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.dateTimePickerTuNgay);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.dateTimePickerToiNgay);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 48);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(208, 320);
            this.panel5.TabIndex = 11;
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
            this.buttonCustom2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustom2.ForeColor = System.Drawing.Color.Black;
            this.buttonCustom2.Image = ((System.Drawing.Image)(resources.GetObject("buttonCustom2.Image")));
            this.buttonCustom2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCustom2.Location = new System.Drawing.Point(63, 142);
            this.buttonCustom2.Name = "buttonCustom2";
            this.buttonCustom2.Size = new System.Drawing.Size(83, 33);
            this.buttonCustom2.TabIndex = 19;
            this.buttonCustom2.Text = "Lọc";
            this.buttonCustom2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCustom2.TextColor = System.Drawing.Color.Black;
            this.buttonCustom2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCustom2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(59, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lọc dữ liệu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePickerTuNgay
            // 
            this.dateTimePickerTuNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTuNgay.Location = new System.Drawing.Point(68, 65);
            this.dateTimePickerTuNgay.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerTuNgay.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerTuNgay.Name = "dateTimePickerTuNgay";
            this.dateTimePickerTuNgay.Size = new System.Drawing.Size(125, 20);
            this.dateTimePickerTuNgay.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Từ ngày :";
            // 
            // dateTimePickerToiNgay
            // 
            this.dateTimePickerToiNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerToiNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerToiNgay.Location = new System.Drawing.Point(68, 94);
            this.dateTimePickerToiNgay.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerToiNgay.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerToiNgay.Name = "dateTimePickerToiNgay";
            this.dateTimePickerToiNgay.Size = new System.Drawing.Size(125, 20);
            this.dateTimePickerToiNgay.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tới ngày :";
            // 
            // buttonCallFormEmployeeActivities
            // 
            this.buttonCallFormEmployeeActivities.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCallFormEmployeeActivities.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonCallFormEmployeeActivities.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonCallFormEmployeeActivities.ForeColor = System.Drawing.SystemColors.Highlight;
            this.buttonCallFormEmployeeActivities.Image = global::MayNapKhiTPA.Properties.Resources.button2_Image;
            this.buttonCallFormEmployeeActivities.Location = new System.Drawing.Point(0, 368);
            this.buttonCallFormEmployeeActivities.Name = "buttonCallFormEmployeeActivities";
            this.buttonCallFormEmployeeActivities.Size = new System.Drawing.Size(208, 31);
            this.buttonCallFormEmployeeActivities.TabIndex = 10;
            this.buttonCallFormEmployeeActivities.Text = "Nhân Viên Vận Hành";
            this.buttonCallFormEmployeeActivities.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCallFormEmployeeActivities.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCallFormEmployeeActivities.UseVisualStyleBackColor = true;
            this.buttonCallFormEmployeeActivities.Click += new System.EventHandler(this.buttonCallFormEmployeeActivities_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelNotify);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.ForeColor = System.Drawing.Color.Green;
            this.groupBox2.Location = new System.Drawing.Point(0, 399);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 88);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông báo";
            // 
            // labelNotify
            // 
            this.labelNotify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNotify.ForeColor = System.Drawing.Color.Black;
            this.labelNotify.Location = new System.Drawing.Point(3, 16);
            this.labelNotify.Name = "labelNotify";
            this.labelNotify.Size = new System.Drawing.Size(202, 69);
            this.labelNotify.TabIndex = 4;
            this.labelNotify.Text = "- Đỗ Văn Xuân vừa bắt đầu lần  nạp gần nhất";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelBanGhiMoiTrang);
            this.groupBox1.Controls.Add(this.labelTongSoTrang);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.Green;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 48);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin trang hoạt động";
            // 
            // labelBanGhiMoiTrang
            // 
            this.labelBanGhiMoiTrang.AutoSize = true;
            this.labelBanGhiMoiTrang.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.labelBanGhiMoiTrang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelBanGhiMoiTrang.Location = new System.Drawing.Point(7, 27);
            this.labelBanGhiMoiTrang.Name = "labelBanGhiMoiTrang";
            this.labelBanGhiMoiTrang.Size = new System.Drawing.Size(38, 13);
            this.labelBanGhiMoiTrang.TabIndex = 3;
            this.labelBanGhiMoiTrang.Text = "label5";
            // 
            // labelTongSoTrang
            // 
            this.labelTongSoTrang.AutoSize = true;
            this.labelTongSoTrang.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.labelTongSoTrang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTongSoTrang.Location = new System.Drawing.Point(7, 16);
            this.labelTongSoTrang.Name = "labelTongSoTrang";
            this.labelTongSoTrang.Size = new System.Drawing.Size(38, 13);
            this.labelTongSoTrang.TabIndex = 1;
            this.labelTongSoTrang.Text = "label5";
            // 
            // FormActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 493);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hoạt động";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivity)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel3;
        private DataGridView dataGridViewActivity;
        private Panel panel2;
        private Panel panel4;
        private DateTimePicker dateTimePickerTuNgay;
        private Label label3;
        private DateTimePicker dateTimePickerToiNgay;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
        private Button buttonTrangCuoi;
        private Button button4;
        private Button button3;
        private Button button2;
        private GroupBox groupBox1;
        private Label labelBanGhiMoiTrang;
        private Label labelTongSoTrang;
        private GroupBox groupBox2;
        private Label labelNotify;
        private Button buttonCallFormEmployeeActivities;
        private Panel panel5;
        private Button button7;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonCustom2;
    }
}