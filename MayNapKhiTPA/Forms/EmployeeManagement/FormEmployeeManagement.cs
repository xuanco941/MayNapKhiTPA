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
            // set chieu cao cua row datagridview la 50px
            dataGridViewUser.RowTemplate.Height = 50;
            dataGridViewGroup.RowTemplate.Height = 50;

            //load datagridview
            LoadDataUser(UserBusiness.GetAllUsers());
            LoadDataGroup(GroupBusiness.GetAllGroups());
        }

      

        //method gọi Alert ở Main từ form khác thông qua form hiện tại, delegate
        public void AlertActive(string msg, FormAlert.enmType enmType)
        {
            callAlert?.Invoke(msg, enmType);
            //load lai 2 datagridview
            LoadDataUser(UserBusiness.GetAllUsers());
            LoadDataGroup(GroupBusiness.GetAllGroups());
        }




        //METHOD

        //Load datagridview tabpage User
        public void LoadDataUser(List<User> listUser)
        {
            // get all user from model
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
                Shift shift = ShiftBusiness.GetShiftFromID(user.ID_Shift);
                Group group = GroupBusiness.GetGroupFromID(user.ID_Group);
                dt.Rows.Add(user.FullName, user.Username, user.Password, user.PhoneNumber, user.Email, shift.Name, group.Name);
            });
            dataGridViewUser.DataSource = dt;

        }

        //Load datagridview tabpage Group
        public void LoadDataGroup(List<Group> listGroup)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên");
            dt.Columns.Add("Quyền quản trị nhân viên");
            dt.Columns.Add("Quyền quản trị cài đặt");

            listGroup.ForEach(delegate (Group group)
            {
                string IsManagementUser = group.IsManagementUser == true ? "Có" : "Không";
                string IsManagementSetting = group.IsManagementSetting == true ? "Có" : "Không";
                dt.Rows.Add(group.ID_Group, group.Name, IsManagementUser, IsManagementSetting);
            });
            dataGridViewGroup.DataSource = dt;

        }

        //Tìm kiếm
        public void SearchUser()
        {
            //nếu ô tìm kiếm rỗng hoặc chữ nhập vào trùng với chữ placeholdertext, mặc định texts của textbox custom này bằng với placeholdertext
            if (String.IsNullOrEmpty(textBoxSearchUser.Texts) == false && textBoxSearchUser.Texts != textBoxSearchUser.PlaceholderText)
            {
                LoadDataUser(UserBusiness.FindUserByFullNameOrUsername(textBoxSearchUser.Texts));
            }
            else
            {
                LoadDataUser(UserBusiness.GetAllUsers());
            }
        }

        public void SearchGroup()
        {
            //nếu ô tìm kiếm rỗng hoặc chữ nhập vào trùng với chữ placeholdertext, mặc định texts của textbox custom này bằng với placeholdertext
            if (String.IsNullOrEmpty(textBoxSearchGroup.Texts) == false && textBoxSearchGroup.Texts != textBoxSearchGroup.PlaceholderText)
            {
                LoadDataGroup(GroupBusiness.FindGroupByName(textBoxSearchGroup.Texts));
            }
            else
            {
                LoadDataGroup(GroupBusiness.GetAllGroups());
            }
        }



        //EVENT

        // Toast form add, change
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





        //Tìm kiếm user 
        private void buttonSearchUser_Click(object sender, EventArgs e)
        {
            SearchUser();
        }

        private void textBoxSearchUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchUser();
            }
        }
        //Tìm kiếm group
        private void buttonSearchGroup_Click(object sender, EventArgs e)
        {
            SearchGroup();
        }
        private void textBoxSearchGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchGroup();
            }
        }
    }
}
