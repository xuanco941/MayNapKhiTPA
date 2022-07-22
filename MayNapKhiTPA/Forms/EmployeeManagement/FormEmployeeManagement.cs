using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MayNapKhiTPA.Models;


namespace MayNapKhiTPA.Forms
{
    public partial class FormEmployeeManagement : Form
    {
        // Aleart Delegate từ FormMain
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;



        public FormEmployeeManagement()
        {
            InitializeComponent();
            LoadTabUser();
            LoadTabGroup();
        }

        //Load datagridview tabpage User
        public void LoadTabUser()
        {
            // get all user from model
            var listUser = UserBusiness.GetAllUsers();
            DataTable dt = new DataTable();
            dt.Columns.Add("Họ tên");
            dt.Columns.Add("Tài khoản");
            dt.Columns.Add("Mật khẩu");
            dt.Columns.Add("Số điện thoại");
            dt.Columns.Add("Email");
            dt.Columns.Add("Ca làm");
            dt.Columns.Add("Quyền");

            listUser.ForEach(delegate (User user)
            {
                dt.Rows.Add(user.FullName, user.Username, user.Password, user.PhoneNumber, user.Email, user.ID_Shift, user.ID_Group);
            });
            dataGridViewUser.DataSource = dt;

        }

        //Load datagridview tabpage Group
        public void LoadTabGroup()
        {
            // get all group from model
            var listGroup = GroupBusiness.GetAllGroups();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên");
            dt.Columns.Add("Quyền quản trị nhân viên");
            dt.Columns.Add("Quyền quản trị cài đặt");

            listGroup.ForEach(delegate (Group group)
            {
                dt.Rows.Add(group.ID_Group, group.Name, group.IsManagementUser, group.IsManagementSetting);
            });
            dataGridViewGroup.DataSource = dt;

        }

        //method gọi Alert ở Main từ form khác thông qua form hiện tại
        public void AlertActive(string msg, FormAlert.enmType enmType)
        {
            callAlert?.Invoke(msg, enmType);
            LoadTabUser();
            LoadTabGroup();
        }


        private void buttonAddUser_Click_1(object sender, EventArgs e)
        {
            // Create an instance of form add user
            FormAddUser formAddUser = new FormAddUser();

            // Create an instance of the delegate
            formAddUser.changeData = new FormAddUser.ChangeData(AlertActive);

            // Show form Them User
            formAddUser.ShowDialog();
        }

        private void buttonChangeUser_Click_1(object sender, EventArgs e)
        {
            FormChangeUser formChangeUser = new FormChangeUser();

            // Create an instance of the delegate
            formChangeUser.changeData = new FormChangeUser.ChangeData(AlertActive);

            // Show form 2
            formChangeUser.ShowDialog();
        }



        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            // Create an instance of form 2
            FormAddGroup formAddGroup = new FormAddGroup();

            // Create an instance of the delegate
            formAddGroup.changeData = new FormAddGroup.ChangeData(AlertActive);

            // Show form 2
            formAddGroup.ShowDialog();
        }

        private void buttonChangeGroup_Click(object sender, EventArgs e)
        {
            // Create an instance of form 2
            FormChangeGroup formChangeGroup = new FormChangeGroup();

            // Create an instance of the delegate
            formChangeGroup.changeData = new FormChangeGroup.ChangeData(AlertActive);

            // Show form 2
            formChangeGroup.ShowDialog();
        }
    }
}
