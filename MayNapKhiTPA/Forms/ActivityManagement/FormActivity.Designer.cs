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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormActivity));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewActivity = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonGoPage = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonCustom6 = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonCustom5 = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonCustom4 = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonCustom3 = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.textBoxGoPage = new LW_PhanMemBaoGia.MyControls.TextBoxT();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonLoc = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1039, 494);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(819, 488);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewActivity);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(819, 438);
            this.panel3.TabIndex = 1;
            // 
            // dataGridViewActivity
            // 
            this.dataGridViewActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewActivity.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewActivity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewActivity.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewActivity.Name = "dataGridViewActivity";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewActivity.RowsDefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewActivity.RowTemplate.Height = 25;
            this.dataGridViewActivity.Size = new System.Drawing.Size(819, 438);
            this.dataGridViewActivity.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonGoPage);
            this.panel2.Controls.Add(this.buttonCustom6);
            this.panel2.Controls.Add(this.buttonCustom5);
            this.panel2.Controls.Add(this.buttonCustom4);
            this.panel2.Controls.Add(this.buttonCustom3);
            this.panel2.Controls.Add(this.textBoxGoPage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 438);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(819, 50);
            this.panel2.TabIndex = 0;
            // 
            // buttonGoPage
            // 
            this.buttonGoPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGoPage.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonGoPage.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.buttonGoPage.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonGoPage.BorderRadius = 3;
            this.buttonGoPage.BorderSize = 0;
            this.buttonGoPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGoPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoPage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGoPage.ForeColor = System.Drawing.Color.Black;
            this.buttonGoPage.Image = ((System.Drawing.Image)(resources.GetObject("buttonGoPage.Image")));
            this.buttonGoPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGoPage.Location = new System.Drawing.Point(736, 11);
            this.buttonGoPage.Name = "buttonGoPage";
            this.buttonGoPage.Size = new System.Drawing.Size(80, 30);
            this.buttonGoPage.TabIndex = 29;
            this.buttonGoPage.Text = "Đi";
            this.buttonGoPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGoPage.TextColor = System.Drawing.Color.Black;
            this.buttonGoPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonGoPage.UseVisualStyleBackColor = false;
            this.buttonGoPage.Click += new System.EventHandler(this.buttonGoPage_Click);
            // 
            // buttonCustom6
            // 
            this.buttonCustom6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCustom6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCustom6.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCustom6.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonCustom6.BorderRadius = 3;
            this.buttonCustom6.BorderSize = 0;
            this.buttonCustom6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCustom6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustom6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustom6.ForeColor = System.Drawing.Color.Black;
            this.buttonCustom6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCustom6.Location = new System.Drawing.Point(206, 10);
            this.buttonCustom6.Name = "buttonCustom6";
            this.buttonCustom6.Size = new System.Drawing.Size(63, 30);
            this.buttonCustom6.TabIndex = 28;
            this.buttonCustom6.Text = ">>";
            this.buttonCustom6.TextColor = System.Drawing.Color.Black;
            this.buttonCustom6.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonCustom6.UseVisualStyleBackColor = false;
            // 
            // buttonCustom5
            // 
            this.buttonCustom5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCustom5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCustom5.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCustom5.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonCustom5.BorderRadius = 3;
            this.buttonCustom5.BorderSize = 0;
            this.buttonCustom5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCustom5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustom5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustom5.ForeColor = System.Drawing.Color.Black;
            this.buttonCustom5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCustom5.Location = new System.Drawing.Point(137, 10);
            this.buttonCustom5.Name = "buttonCustom5";
            this.buttonCustom5.Size = new System.Drawing.Size(63, 30);
            this.buttonCustom5.TabIndex = 27;
            this.buttonCustom5.Text = "3";
            this.buttonCustom5.TextColor = System.Drawing.Color.Black;
            this.buttonCustom5.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonCustom5.UseVisualStyleBackColor = false;
            // 
            // buttonCustom4
            // 
            this.buttonCustom4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCustom4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCustom4.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCustom4.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonCustom4.BorderRadius = 3;
            this.buttonCustom4.BorderSize = 0;
            this.buttonCustom4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCustom4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustom4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustom4.ForeColor = System.Drawing.Color.Black;
            this.buttonCustom4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCustom4.Location = new System.Drawing.Point(0, 10);
            this.buttonCustom4.Name = "buttonCustom4";
            this.buttonCustom4.Size = new System.Drawing.Size(63, 30);
            this.buttonCustom4.TabIndex = 26;
            this.buttonCustom4.Text = "1";
            this.buttonCustom4.TextColor = System.Drawing.Color.Black;
            this.buttonCustom4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonCustom4.UseVisualStyleBackColor = false;
            // 
            // buttonCustom3
            // 
            this.buttonCustom3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCustom3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCustom3.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCustom3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonCustom3.BorderRadius = 3;
            this.buttonCustom3.BorderSize = 0;
            this.buttonCustom3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCustom3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustom3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustom3.ForeColor = System.Drawing.Color.Black;
            this.buttonCustom3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCustom3.Location = new System.Drawing.Point(68, 10);
            this.buttonCustom3.Name = "buttonCustom3";
            this.buttonCustom3.Size = new System.Drawing.Size(63, 30);
            this.buttonCustom3.TabIndex = 25;
            this.buttonCustom3.Text = "2";
            this.buttonCustom3.TextColor = System.Drawing.Color.Black;
            this.buttonCustom3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonCustom3.UseVisualStyleBackColor = false;
            // 
            // textBoxGoPage
            // 
            this.textBoxGoPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGoPage.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxGoPage.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.textBoxGoPage.BorderFocusColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBoxGoPage.BorderRadius = 5;
            this.textBoxGoPage.BorderSize = 1;
            this.textBoxGoPage.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGoPage.Location = new System.Drawing.Point(651, 11);
            this.textBoxGoPage.Multiline = false;
            this.textBoxGoPage.Name = "textBoxGoPage";
            this.textBoxGoPage.Padding = new System.Windows.Forms.Padding(7, 9, 7, 5);
            this.textBoxGoPage.PasswordChar = false;
            this.textBoxGoPage.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxGoPage.PlaceholderText = "Trang số . . .";
            this.textBoxGoPage.Size = new System.Drawing.Size(79, 35);
            this.textBoxGoPage.TabIndex = 23;
            this.textBoxGoPage.Texts = "Trang số . . .";
            this.textBoxGoPage.UnderlinedStyle = false;
            this.textBoxGoPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxGoPage_KeyPress);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.buttonCallFormEmployeeActivities);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(828, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(208, 488);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonLoc);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.dateTimePickerTuNgay);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.dateTimePickerToiNgay);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 48);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(208, 321);
            this.panel5.TabIndex = 11;
            // 
            // buttonLoc
            // 
            this.buttonLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoc.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonLoc.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.buttonLoc.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonLoc.BorderRadius = 3;
            this.buttonLoc.BorderSize = 0;
            this.buttonLoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoc.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoc.ForeColor = System.Drawing.Color.Black;
            this.buttonLoc.Image = ((System.Drawing.Image)(resources.GetObject("buttonLoc.Image")));
            this.buttonLoc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonLoc.Location = new System.Drawing.Point(63, 142);
            this.buttonLoc.Name = "buttonLoc";
            this.buttonLoc.Size = new System.Drawing.Size(83, 33);
            this.buttonLoc.TabIndex = 19;
            this.buttonLoc.Text = "Lọc";
            this.buttonLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLoc.TextColor = System.Drawing.Color.Black;
            this.buttonLoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLoc.UseVisualStyleBackColor = false;
            this.buttonLoc.Click += new System.EventHandler(this.buttonLoc_Click_1);
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
            this.buttonCallFormEmployeeActivities.Location = new System.Drawing.Point(0, 369);
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
            this.groupBox2.Location = new System.Drawing.Point(0, 400);
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
            this.ClientSize = new System.Drawing.Size(1039, 494);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hoạt động";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivity)).EndInit();
            this.panel2.ResumeLayout(false);
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
        private GroupBox groupBox1;
        private Label labelBanGhiMoiTrang;
        private Label labelTongSoTrang;
        private GroupBox groupBox2;
        private Label labelNotify;
        private Button buttonCallFormEmployeeActivities;
        private Panel panel5;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonLoc;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonCustom6;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonCustom5;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonCustom4;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonCustom3;
        private LW_PhanMemBaoGia.MyControls.TextBoxT textBoxGoPage;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonGoPage;
    }
}