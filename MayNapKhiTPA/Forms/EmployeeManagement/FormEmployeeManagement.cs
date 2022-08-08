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
            dt.Columns.Add("Số điện thoại");
            dt.Columns.Add("Email");
            dt.Columns.Add("Ca làm");
            dt.Columns.Add("Quyền");

            listUser.ForEach(delegate (User user)
            {
                Group group = GroupBusiness.GetGroupFromID(user.ID_Group);
                dt.Rows.Add(user.FullName, user.Username, user.PhoneNumber, user.Email, user.NameShift, group.Name);
            });
            dataGridViewUser.DataSource = dt;

        }

        //Load datagridview tabpage Group
        public void LoadDataGroup(List<Group> listGroup)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên nhóm quyền");
            dt.Columns.Add("Quản trị nhân viên");
            dt.Columns.Add("Quản trị nhóm quyền");
            dt.Columns.Add("Điều khiển máy");
            dt.Columns.Add("Cài đặt thông số máy");
            dt.Columns.Add("Thiết lập ca làm");
            dt.Columns.Add("Thiết lập bình");
            dt.Columns.Add("Xem lịch sử nạp");
            dt.Columns.Add("Xem lịch sử hoạt động");
            dt.Columns.Add("Xóa lịch sử nạp");
            dt.Columns.Add("Xóa lịch sử hoạt động");


            listGroup.ForEach(delegate (Group group)
            {
                string IsManagementUser = group.IsManagementUser == true ? "Có" : "Không";
                string IsManagementGroup = group.IsManagementGroup == true ? "Có" : "Không";
                string IsControlMachine = group.IsControlMachine == true ? "Có" : "Không";
                string IsSettingMachine = group.IsSettingMachine == true ? "Có" : "Không";
                string IsSettingShift = group.IsSettingShift == true ? "Có" : "Không";
                string IsSettingTemplateMachine = group.IsSettingTemplateMachine == true ? "Có" : "Không";
                string IsViewResult = group.IsViewResult == true ? "Có" : "Không";
                string IsViewActivity = group.IsViewActivity == true ? "Có" : "Không";
                string IsDeleteResult = group.IsDeleteResult == true ? "Có" : "Không";
                string IsDeleteActivity = group.IsDeleteActivity == true ? "Có" : "Không";

                dt.Rows.Add(group.ID_Group, group.Name, IsManagementUser, IsManagementGroup, IsControlMachine, IsSettingMachine,
                    IsSettingShift, IsSettingTemplateMachine, IsViewResult, IsDeleteActivity, IsDeleteResult, IsDeleteActivity
                    );
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
            //check quyền
            if (Common.GROUPSESSION.IsManagementUser)
            {
                // Create an instance of form add user
                FormAddUser formAddUser = new FormAddUser();
                // Create an instance of the delegate
                formAddUser.changeData = new FormAddUser.ChangeData(AlertActive);
                formAddUser.ShowDialog();
            }
            else
            {
                callAlert?.Invoke("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }

        }

        private void buttonChangeUser_Click_1(object sender, EventArgs e)
        {

            //check quyền
            if (Common.GROUPSESSION.IsManagementUser)
            {
                FormChangeUser formChangeUser = new FormChangeUser();
                formChangeUser.changeData = new FormChangeUser.ChangeData(AlertActive);
                formChangeUser.ShowDialog();
            }
            else
            {
                callAlert?.Invoke("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }
        }



        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            //check quyền
            if (Common.GROUPSESSION.IsManagementGroup)
            {
                // Create an instance of form 2
                FormAddGroup formAddGroup = new FormAddGroup();
                // Create an instance of the delegate
                formAddGroup.changeData = new FormAddGroup.ChangeData(AlertActive);
                // Show form 2
                formAddGroup.ShowDialog();
            }
            else
            {
                callAlert?.Invoke("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }

        }

        private void buttonChangeGroup_Click(object sender, EventArgs e)
        {
            //check quyền
            if (Common.GROUPSESSION.IsManagementGroup)
            {
                // Create an instance of form 2
                FormChangeGroup formChangeGroup = new FormChangeGroup();

                // Create an instance of the delegate
                formChangeGroup.changeData = new FormChangeGroup.ChangeData(AlertActive);

                // Show form 2
                formChangeGroup.ShowDialog();
            }
            else
            {
                callAlert?.Invoke("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }
        }





        //Tìm kiếm user 
        private void buttonSearchUser_Click(object sender, EventArgs e)
        {
            try
            {
                SearchUser();
            }
            catch
            {
                MessageBox.Show("Không thể tìm kiếm người dùng.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxSearchUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    SearchUser();
                }
                catch
                {
                    MessageBox.Show("Không thể tìm kiếm người dùng.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Tìm kiếm group
        private void buttonSearchGroup_Click(object sender, EventArgs e)
        {
            try
            {
                SearchGroup();
            }
            catch
            {
                MessageBox.Show("Không thể tìm kiếm nhóm quyền.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBoxSearchGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    SearchGroup();
                }
                catch
                {
                    MessageBox.Show("Không thể tìm kiếm nhóm quyền.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
