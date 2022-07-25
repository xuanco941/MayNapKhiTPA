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
            List<User> listUsers = new List<User>();
            //lấy danh sách id_user tham gia hoạt động, sau đó tìm thông tin user đó và thêm vào list user
            foreach (int id_user in ActivityBusiness.GetListIDUserHasActivity())
            {
                listUsers.Add(UserBusiness.GetUserFromID(id_user));
            }

            foreach(User user in listUsers)
            {
                Button btn = new Button();
                btn.Height = 50;
                btn.Text = user.FullName;
                //tag để lưu id_user
                btn.Tag = user.ID_User;
                btn.ForeColor = Color.FromName("#B0B3B8");
                btn.BackColor = Color.FromName("#3a3b3c");
                btn.Dock = DockStyle.Top;
                btn.Click += new EventHandler(handleClickButtonUser);
                panelUser.Controls.Add(btn);
            }

            // load 1 thông tin của user
            if (panelUser.Controls.Count > 0) {
                int id_user_first = Int32.Parse(panelUser.Controls[0].Tag.ToString());
                LoadDatagridView(ActivityBusiness.GetActivityFromIDUser(id_user_first));
            }

        }
        //load datagridview
        private void LoadDatagridView(List<Activity> activities)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Hoạt động", typeof(string));
            dt.Columns.Add("Ngày thực hiện", typeof(DateTime));
            activities.ForEach(delegate (Activity activity)
            {
                string createAt = activity.Create_At.ToString("dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                dt.Rows.Add(activity.Description, createAt);
            });
            dataGridViewUserActivity.DataSource = dt;
        }
        //function delegate event click button render from list user
        private void handleClickButtonUser(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            LoadDatagridView(ActivityBusiness.GetActivityFromIDUser(Int32.Parse(btn.Tag.ToString())));

        }

    }
}
