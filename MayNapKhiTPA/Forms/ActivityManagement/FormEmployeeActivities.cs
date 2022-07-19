using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MayNapKhiTPA.Models;

namespace MayNapKhiTPA.Forms.ActivityManagement
{
    public partial class FormEmployeeActivities : Form
    {
        public FormEmployeeActivities()
        {
            InitializeComponent();
            LoadPanelUser();
        }

        private void LoadPanelUser()
        {            
            //test
            List<Activity> activities = new List<Activity>();
            DataTable dt = new DataTable();
            dt.Columns.Add("No.", typeof(int));
            dt.Columns.Add("Hoạt động", typeof(string));
            dt.Columns.Add("Thời gian", typeof(DateTime));

            string[] arr = new string[5] {"Đỗ Văn Xuân","Đỗ Văn C","Nguyễn Văn A","Đỗ Thị B", "Bùi Thị H" };

            panelUser.AutoScroll = true;
            for(int i =0; i< arr.Length; i++)
            {
                Button btn = new Button();
                btn.Height = 50;
                btn.Text = arr[i].ToString();
                btn.Tag = i;
                btn.ForeColor = Color.FromName("#B0B3B8");
                btn.BackColor = Color.FromName("#3a3b3c");
                btn.Dock = DockStyle.Top;
                btn.Click += new EventHandler(handleClickButtonUser);
                panelUser.Controls.Add(btn);

                string time = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                dt.Rows.Add(i, "Đã start máy", time);
            }




            dataGridViewEmployeeActivity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEmployeeActivity.DataSource = dt;

        }

        private void handleClickButtonUser(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            MessageBox.Show(""+btn.Tag);
        }

    }
}
