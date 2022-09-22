﻿namespace MayNapKhiTPA.Forms.OrderPurchaseManagement
{
    partial class FormOrderPurchaseManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrderPurchaseManagement));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonTodolist = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonProcess = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonPurchaseOrder = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 566F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1299, 566);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonTodolist);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(868, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(428, 560);
            this.panel3.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonProcess);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(435, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 560);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonPurchaseOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 560);
            this.panel1.TabIndex = 0;
            // 
            // buttonTodolist
            // 
            this.buttonTodolist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.buttonTodolist.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.buttonTodolist.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonTodolist.BorderRadius = 14;
            this.buttonTodolist.BorderSize = 0;
            this.buttonTodolist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTodolist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTodolist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTodolist.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTodolist.ForeColor = System.Drawing.Color.White;
            this.buttonTodolist.Image = ((System.Drawing.Image)(resources.GetObject("buttonTodolist.Image")));
            this.buttonTodolist.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonTodolist.Location = new System.Drawing.Point(0, 0);
            this.buttonTodolist.Name = "buttonTodolist";
            this.buttonTodolist.Size = new System.Drawing.Size(428, 560);
            this.buttonTodolist.TabIndex = 20;
            this.buttonTodolist.Text = "Danh mục cần làm";
            this.buttonTodolist.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonTodolist.TextColor = System.Drawing.Color.White;
            this.buttonTodolist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonTodolist.UseVisualStyleBackColor = false;
            this.buttonTodolist.Click += new System.EventHandler(this.buttonTodolist_Click);
            // 
            // buttonProcess
            // 
            this.buttonProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.buttonProcess.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.buttonProcess.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonProcess.BorderRadius = 15;
            this.buttonProcess.BorderSize = 0;
            this.buttonProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProcess.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProcess.ForeColor = System.Drawing.Color.White;
            this.buttonProcess.Image = ((System.Drawing.Image)(resources.GetObject("buttonProcess.Image")));
            this.buttonProcess.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonProcess.Location = new System.Drawing.Point(0, 0);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(427, 560);
            this.buttonProcess.TabIndex = 21;
            this.buttonProcess.Text = "Tiến trình sản xuất";
            this.buttonProcess.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonProcess.TextColor = System.Drawing.Color.White;
            this.buttonProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonProcess.UseVisualStyleBackColor = false;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // buttonPurchaseOrder
            // 
            this.buttonPurchaseOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.buttonPurchaseOrder.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.buttonPurchaseOrder.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonPurchaseOrder.BorderRadius = 15;
            this.buttonPurchaseOrder.BorderSize = 0;
            this.buttonPurchaseOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPurchaseOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPurchaseOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPurchaseOrder.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPurchaseOrder.ForeColor = System.Drawing.Color.White;
            this.buttonPurchaseOrder.Image = ((System.Drawing.Image)(resources.GetObject("buttonPurchaseOrder.Image")));
            this.buttonPurchaseOrder.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonPurchaseOrder.Location = new System.Drawing.Point(0, 0);
            this.buttonPurchaseOrder.Name = "buttonPurchaseOrder";
            this.buttonPurchaseOrder.Size = new System.Drawing.Size(426, 560);
            this.buttonPurchaseOrder.TabIndex = 19;
            this.buttonPurchaseOrder.Text = "Đơn hàng";
            this.buttonPurchaseOrder.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonPurchaseOrder.TextColor = System.Drawing.Color.White;
            this.buttonPurchaseOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonPurchaseOrder.UseVisualStyleBackColor = false;
            this.buttonPurchaseOrder.Click += new System.EventHandler(this.buttonPurchaseOrder_Click);
            // 
            // FormOrderPurchaseManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 566);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormOrderPurchaseManagement";
            this.Text = "FormOrderPurchaseManagement";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonTodolist;
        private System.Windows.Forms.Panel panel2;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonProcess;
        private System.Windows.Forms.Panel panel1;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonPurchaseOrder;
    }
}