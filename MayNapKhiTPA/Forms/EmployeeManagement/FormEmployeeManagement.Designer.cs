﻿using System.Windows.Forms;

namespace MayNapKhiTPA.Forms
{
    partial class FormEmployeeManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmployeeManagement));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageUser = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonChangeUser = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonAddUser = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonSearchUser = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.textBoxSearchUser = new System.Windows.Forms.TextBox();
            this.buttonThemNhanVien = new System.Windows.Forms.Button();
            this.buttonSuaNhanVien = new System.Windows.Forms.Button();
            this.tabPageGroup = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewGroup = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonChangeGroup = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonAddGroup = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonSearchGroup = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxSearchGroup = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageUser.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabPageGroup.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroup)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageUser);
            this.tabControl1.Controls.Add(this.tabPageGroup);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(997, 516);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageUser
            // 
            this.tabPageUser.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabPageUser.Controls.Add(this.panel2);
            this.tabPageUser.Controls.Add(this.panel3);
            this.tabPageUser.Location = new System.Drawing.Point(4, 29);
            this.tabPageUser.Name = "tabPageUser";
            this.tabPageUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUser.Size = new System.Drawing.Size(989, 483);
            this.tabPageUser.TabIndex = 0;
            this.tabPageUser.Text = "Tài khoản thành viên";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewUser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(983, 426);
            this.panel2.TabIndex = 8;
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUser.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUser.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewUser.Name = "dataGridViewUser";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewUser.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewUser.Size = new System.Drawing.Size(983, 426);
            this.dataGridViewUser.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.buttonChangeUser);
            this.panel3.Controls.Add(this.buttonAddUser);
            this.panel3.Controls.Add(this.buttonSearchUser);
            this.panel3.Controls.Add(this.textBoxSearchUser);
            this.panel3.Controls.Add(this.buttonThemNhanVien);
            this.panel3.Controls.Add(this.buttonSuaNhanVien);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.panel3.Location = new System.Drawing.Point(3, 429);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(983, 51);
            this.panel3.TabIndex = 9;
            // 
            // buttonChangeUser
            // 
            this.buttonChangeUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChangeUser.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonChangeUser.BackgroundColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonChangeUser.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonChangeUser.BorderRadius = 0;
            this.buttonChangeUser.BorderSize = 0;
            this.buttonChangeUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangeUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChangeUser.ForeColor = System.Drawing.Color.White;
            this.buttonChangeUser.Image = global::MayNapKhiTPA.Properties.Resources.iconfinder_Synchronize_278832;
            this.buttonChangeUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonChangeUser.Location = new System.Drawing.Point(872, 12);
            this.buttonChangeUser.Name = "buttonChangeUser";
            this.buttonChangeUser.Size = new System.Drawing.Size(106, 29);
            this.buttonChangeUser.TabIndex = 22;
            this.buttonChangeUser.Text = "Thay đổi";
            this.buttonChangeUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonChangeUser.TextColor = System.Drawing.Color.White;
            this.buttonChangeUser.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonChangeUser.UseVisualStyleBackColor = false;
            this.buttonChangeUser.Click += new System.EventHandler(this.buttonChangeUser_Click_1);
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddUser.BackColor = System.Drawing.Color.Green;
            this.buttonAddUser.BackgroundColor = System.Drawing.Color.Green;
            this.buttonAddUser.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonAddUser.BorderRadius = 0;
            this.buttonAddUser.BorderSize = 0;
            this.buttonAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddUser.ForeColor = System.Drawing.Color.White;
            this.buttonAddUser.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddUser.Image")));
            this.buttonAddUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddUser.Location = new System.Drawing.Point(763, 12);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(106, 29);
            this.buttonAddUser.TabIndex = 21;
            this.buttonAddUser.Text = "Thêm mới";
            this.buttonAddUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAddUser.TextColor = System.Drawing.Color.White;
            this.buttonAddUser.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonAddUser.UseVisualStyleBackColor = false;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click_1);
            // 
            // buttonSearchUser
            // 
            this.buttonSearchUser.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonSearchUser.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.buttonSearchUser.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonSearchUser.BorderRadius = 0;
            this.buttonSearchUser.BorderSize = 0;
            this.buttonSearchUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchUser.ForeColor = System.Drawing.Color.Black;
            this.buttonSearchUser.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearchUser.Image")));
            this.buttonSearchUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearchUser.Location = new System.Drawing.Point(190, 12);
            this.buttonSearchUser.Name = "buttonSearchUser";
            this.buttonSearchUser.Size = new System.Drawing.Size(72, 29);
            this.buttonSearchUser.TabIndex = 20;
            this.buttonSearchUser.Text = "Tìm";
            this.buttonSearchUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSearchUser.TextColor = System.Drawing.Color.Black;
            this.buttonSearchUser.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonSearchUser.UseVisualStyleBackColor = false;
            // 
            // textBoxSearchUser
            // 
            this.textBoxSearchUser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxSearchUser.Location = new System.Drawing.Point(4, 12);
            this.textBoxSearchUser.Name = "textBoxSearchUser";
            this.textBoxSearchUser.Size = new System.Drawing.Size(180, 29);
            this.textBoxSearchUser.TabIndex = 5;
            // 
            // buttonThemNhanVien
            // 
            this.buttonThemNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonThemNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.buttonThemNhanVien.Image = global::MayNapKhiTPA.Properties.Resources.iconfinder_Stock_Index_Up_278812;
            this.buttonThemNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonThemNhanVien.Location = new System.Drawing.Point(1537, -27);
            this.buttonThemNhanVien.Name = "buttonThemNhanVien";
            this.buttonThemNhanVien.Size = new System.Drawing.Size(81, 24);
            this.buttonThemNhanVien.TabIndex = 2;
            this.buttonThemNhanVien.Text = "Thêm mới";
            this.buttonThemNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonThemNhanVien.UseVisualStyleBackColor = true;
            // 
            // buttonSuaNhanVien
            // 
            this.buttonSuaNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSuaNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.buttonSuaNhanVien.Image = global::MayNapKhiTPA.Properties.Resources.iconfinder_Synchronize_278832;
            this.buttonSuaNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSuaNhanVien.Location = new System.Drawing.Point(1624, -27);
            this.buttonSuaNhanVien.Name = "buttonSuaNhanVien";
            this.buttonSuaNhanVien.Size = new System.Drawing.Size(81, 24);
            this.buttonSuaNhanVien.TabIndex = 3;
            this.buttonSuaNhanVien.Text = "Thay đổi";
            this.buttonSuaNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSuaNhanVien.UseVisualStyleBackColor = true;
            // 
            // tabPageGroup
            // 
            this.tabPageGroup.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabPageGroup.Controls.Add(this.panel1);
            this.tabPageGroup.Controls.Add(this.panel4);
            this.tabPageGroup.Location = new System.Drawing.Point(4, 29);
            this.tabPageGroup.Name = "tabPageGroup";
            this.tabPageGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGroup.Size = new System.Drawing.Size(989, 483);
            this.tabPageGroup.TabIndex = 1;
            this.tabPageGroup.Text = "Phân quyền";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewGroup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(983, 426);
            this.panel1.TabIndex = 10;
            // 
            // dataGridViewGroup
            // 
            this.dataGridViewGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGroup.BackgroundColor = System.Drawing.Color.OliveDrab;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGroup.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewGroup.Name = "dataGridViewGroup";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewGroup.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewGroup.Size = new System.Drawing.Size(983, 426);
            this.dataGridViewGroup.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.buttonChangeGroup);
            this.panel4.Controls.Add(this.buttonAddGroup);
            this.panel4.Controls.Add(this.buttonSearchGroup);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.textBoxSearchGroup);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.button5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.panel4.Location = new System.Drawing.Point(3, 429);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(983, 51);
            this.panel4.TabIndex = 11;
            // 
            // buttonChangeGroup
            // 
            this.buttonChangeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChangeGroup.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonChangeGroup.BackgroundColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonChangeGroup.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonChangeGroup.BorderRadius = 0;
            this.buttonChangeGroup.BorderSize = 0;
            this.buttonChangeGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangeGroup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChangeGroup.ForeColor = System.Drawing.Color.White;
            this.buttonChangeGroup.Image = global::MayNapKhiTPA.Properties.Resources.iconfinder_Synchronize_278832;
            this.buttonChangeGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonChangeGroup.Location = new System.Drawing.Point(874, 12);
            this.buttonChangeGroup.Name = "buttonChangeGroup";
            this.buttonChangeGroup.Size = new System.Drawing.Size(106, 29);
            this.buttonChangeGroup.TabIndex = 24;
            this.buttonChangeGroup.Text = "Thay đổi";
            this.buttonChangeGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonChangeGroup.TextColor = System.Drawing.Color.White;
            this.buttonChangeGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonChangeGroup.UseVisualStyleBackColor = false;
            this.buttonChangeGroup.Click += new System.EventHandler(this.buttonChangeGroup_Click);
            // 
            // buttonAddGroup
            // 
            this.buttonAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddGroup.BackColor = System.Drawing.Color.Green;
            this.buttonAddGroup.BackgroundColor = System.Drawing.Color.Green;
            this.buttonAddGroup.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonAddGroup.BorderRadius = 0;
            this.buttonAddGroup.BorderSize = 0;
            this.buttonAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddGroup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddGroup.ForeColor = System.Drawing.Color.White;
            this.buttonAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddGroup.Image")));
            this.buttonAddGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddGroup.Location = new System.Drawing.Point(765, 12);
            this.buttonAddGroup.Name = "buttonAddGroup";
            this.buttonAddGroup.Size = new System.Drawing.Size(106, 29);
            this.buttonAddGroup.TabIndex = 23;
            this.buttonAddGroup.Text = "Thêm mới";
            this.buttonAddGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAddGroup.TextColor = System.Drawing.Color.White;
            this.buttonAddGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonAddGroup.UseVisualStyleBackColor = false;
            this.buttonAddGroup.Click += new System.EventHandler(this.buttonAddGroup_Click);
            // 
            // buttonSearchGroup
            // 
            this.buttonSearchGroup.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonSearchGroup.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.buttonSearchGroup.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonSearchGroup.BorderRadius = 0;
            this.buttonSearchGroup.BorderSize = 0;
            this.buttonSearchGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchGroup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchGroup.ForeColor = System.Drawing.Color.Black;
            this.buttonSearchGroup.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearchGroup.Image")));
            this.buttonSearchGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearchGroup.Location = new System.Drawing.Point(192, 12);
            this.buttonSearchGroup.Name = "buttonSearchGroup";
            this.buttonSearchGroup.Size = new System.Drawing.Size(72, 29);
            this.buttonSearchGroup.TabIndex = 21;
            this.buttonSearchGroup.Text = "Tìm";
            this.buttonSearchGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSearchGroup.TextColor = System.Drawing.Color.Black;
            this.buttonSearchGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonSearchGroup.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.button1.Image = global::MayNapKhiTPA.Properties.Resources.iconfinder_Stock_Index_Up_278812;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(1437, -23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 24);
            this.button1.TabIndex = 6;
            this.button1.Text = "Thêm mới";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.button2.Image = global::MayNapKhiTPA.Properties.Resources.iconfinder_Synchronize_278832;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(1524, -23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 24);
            this.button2.TabIndex = 7;
            this.button2.Text = "Thay đổi";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBoxSearchGroup
            // 
            this.textBoxSearchGroup.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxSearchGroup.Location = new System.Drawing.Point(6, 12);
            this.textBoxSearchGroup.Name = "textBoxSearchGroup";
            this.textBoxSearchGroup.Size = new System.Drawing.Size(180, 29);
            this.textBoxSearchGroup.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.button4.Image = global::MayNapKhiTPA.Properties.Resources.iconfinder_Stock_Index_Up_278812;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.Location = new System.Drawing.Point(2162, -62);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(81, 24);
            this.button4.TabIndex = 2;
            this.button4.Text = "Thêm mới";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.button5.Image = global::MayNapKhiTPA.Properties.Resources.iconfinder_Synchronize_278832;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.Location = new System.Drawing.Point(2249, -62);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(81, 24);
            this.button5.TabIndex = 3;
            this.button5.Text = "Thay đổi";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // FormEmployeeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(997, 516);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormEmployeeManagement";
            this.Text = "FormEmployeeManagement";
            this.tabControl1.ResumeLayout(false);
            this.tabPageUser.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPageGroup.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroup)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageUser;
        private TabPage tabPageGroup;
        private Panel panel2;
        private DataGridView dataGridViewUser;
        private Panel panel3;
        private TextBox textBoxSearchUser;
        private Button buttonThemNhanVien;
        private Button buttonSuaNhanVien;
        private Panel panel1;
        private DataGridView dataGridViewGroup;
        private Panel panel4;
        private Button button1;
        private Button button2;
        private TextBox textBoxSearchGroup;
        private Button button4;
        private Button button5;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonSearchUser;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonSearchGroup;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonAddUser;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonChangeUser;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonChangeGroup;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonAddGroup;
    }
}