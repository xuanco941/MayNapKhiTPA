using System.Windows.Forms;

namespace MayNapKhiTPA.Forms.ActivityManagement
{
    partial class FormEmployeeActivities
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelUser = new System.Windows.Forms.Panel();
            this.dataGridViewUserActivity = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserActivity)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUser
            // 
            this.panelUser.AutoScroll = true;
            this.panelUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelUser.Location = new System.Drawing.Point(0, 0);
            this.panelUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(277, 615);
            this.panelUser.TabIndex = 0;
            // 
            // dataGridViewUserActivity
            // 
            this.dataGridViewUserActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUserActivity.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUserActivity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewUserActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUserActivity.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewUserActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUserActivity.Location = new System.Drawing.Point(277, 0);
            this.dataGridViewUserActivity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewUserActivity.Name = "dataGridViewUserActivity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewUserActivity.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewUserActivity.RowTemplate.Height = 25;
            this.dataGridViewUserActivity.Size = new System.Drawing.Size(1042, 615);
            this.dataGridViewUserActivity.TabIndex = 1;
            // 
            // FormEmployeeActivities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1319, 615);
            this.Controls.Add(this.dataGridViewUserActivity);
            this.Controls.Add(this.panelUser);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormEmployeeActivities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết hoạt động của nhân viên vận hành";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserActivity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelUser;
        private DataGridView dataGridViewUserActivity;
    }
}