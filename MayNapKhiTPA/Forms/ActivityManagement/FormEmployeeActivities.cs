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
            //setting header column
            dataGridViewUserActivity.ColumnHeadersDefaultCellStyle.Font = new Font("Bahnschrift", 12, FontStyle.Regular);
            dataGridViewUserActivity.RowTemplate.Height = 35;
        }

        private void LoadPanelUser()
        {
            //lấy danh sách id_user tham gia hoạt động, sau đó tìm thông tin user đó và thêm vào list user
            foreach (string worker in ActivityBusiness.GetListWorkerHasActivity())
            {
                string fullnameButton = worker;

                User user = UserBusiness.GetUserFromUserName(worker);
                if (user != null)
                {
                    fullnameButton = user.FullName;
                }
                else
                {
                    fullnameButton = worker + " (không còn tồn tại)";
                }

                Button btn = new Button();
                btn.Height = 50;
                btn.Text = fullnameButton;
                //tag để lưu username
                btn.Tag = worker;
                btn.ForeColor = Color.FromName("#B0B3B8");
                btn.BackColor = Color.FromName("#3a3b3c");
                btn.Dock = DockStyle.Top;
                btn.Cursor = Cursors.Hand;
                btn.Click += new EventHandler(handleClickButtonUser);
                panelUser.Controls.Add(btn);

            }



            // load 1 thông tin của user
            if (panelUser.Controls.Count > 0)
            {
                string username = panelUser.Controls[0].Tag.ToString();
                LoadDatagridView(ActivityBusiness.GetActivityFromWorker(username));
            }

        }
        //load datagridview
        private void LoadDatagridView(List<Activity> activities)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Hoạt động");
            dt.Columns.Add("Ngày thực hiện");
            activities.ForEach(delegate (Activity activity)
            {
                string createAt = activity.Create_At.ToString("hh:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                dt.Rows.Add(activity.Description, createAt);
            });
            dataGridViewUserActivity.DataSource = dt;
        }
        //function delegate event click button render from list user
        private void handleClickButtonUser(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            LoadDatagridView(ActivityBusiness.GetActivityFromWorker(btn.Tag.ToString()));
        }

    }
}
