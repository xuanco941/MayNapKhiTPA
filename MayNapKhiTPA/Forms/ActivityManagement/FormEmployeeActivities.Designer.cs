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
            this.panelUser = new System.Windows.Forms.Panel();
            this.dataGridViewEmployeeActivity = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeActivity)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUser
            // 
            this.panelUser.AutoScroll = true;
            this.panelUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelUser.Location = new System.Drawing.Point(0, 0);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(241, 530);
            this.panelUser.TabIndex = 0;
            // 
            // dataGridViewEmployeeActivity
            // 
            this.dataGridViewEmployeeActivity.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridViewEmployeeActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployeeActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEmployeeActivity.Location = new System.Drawing.Point(241, 0);
            this.dataGridViewEmployeeActivity.Name = "dataGridViewEmployeeActivity";
            this.dataGridViewEmployeeActivity.RowTemplate.Height = 25;
            this.dataGridViewEmployeeActivity.Size = new System.Drawing.Size(722, 530);
            this.dataGridViewEmployeeActivity.TabIndex = 1;
            // 
            // FormEmployeeActivities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(963, 530);
            this.Controls.Add(this.dataGridViewEmployeeActivity);
            this.Controls.Add(this.panelUser);
            this.Name = "FormEmployeeActivities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết hoạt động của nhân viên vận hành";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeActivity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelUser;
        private DataGridView dataGridViewEmployeeActivity;
    }
}