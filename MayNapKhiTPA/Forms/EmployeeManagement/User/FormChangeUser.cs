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
    public partial class FormChangeUser : Form
    {
        // Define delegate
        public delegate void ChangeData(string msg, FormAlert.enmType enmType);

        // Create instance (null)
        public ChangeData changeData;
        public FormChangeUser()
        {
            InitializeComponent();

            // lấy tất cả tên các ca làm cho vào combobox
            var listShifts = ShiftBusiness.GetAllShifts();
            var listNameShift = from shift in listShifts select shift.Name;
            comboBoxSelectShift.DataSource = listNameShift.ToList();

            //lấy tất cả tên các quyền cho vào combobox
            var listGroups = GroupBusiness.GetAllGroups();
            var listNameGroup = from groupVar in listGroups select groupVar.Name;
            comboBoxSelectGroup.DataSource = listNameGroup.ToList();

            LoadForm();
        }
        public void LoadForm()
        {
            // lấy tất cả các username vào combobox,sap xep nguoc lai theo id
            var listUsers = UserBusiness.GetAllUsers().OrderByDescending(user => user.ID_User);
            var listUsername = (from user in listUsers select user.Username);
            comboBoxSelectUsername.DataSource = listUsername.ToList();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string usernameOld = comboBoxSelectUsername.Text;
            string fullname = textBoxFullName.Texts;
            string username = textBoxUsername.Texts.Trim();
            string password = textBoxPassword.Texts.Trim();
            string phonenumber = textBoxPhoneNumber.Texts.Trim();
            string email = textBoxEmail.Texts.Trim();
            string nameshift = comboBoxSelectShift.Text;

            //get id shift và group từ tên tên combobox (name unique)
            int id_group = GroupBusiness.GetGroupFromName(comboBoxSelectGroup.Text).ID_Group;

            User user = new User(fullname, username, password, phonenumber, email, nameshift, id_group);
            if (String.IsNullOrEmpty(fullname) || String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(nameshift) || String.IsNullOrEmpty(comboBoxSelectGroup.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    UserBusiness.UpdateUser(usernameOld, user);
                    //nếu username cũ là username current , biến tĩnh của program thì cập nhật lại usercurrent
                    if(usernameOld == Common.USERSESSION.Username)
                    {
                        // cập nhật lại quyền hiện tại
                        Common.USERSESSION = user;
                        Common.GROUPSESSION = GroupBusiness.GetGroupFromID(Common.USERSESSION.ID_Group);
                        
                    }
                    //thông báo
                    changeData?.Invoke("Cập nhật thành công.", FormAlert.enmType.Success);
                }
                catch (Exception ex)
                {
                    changeData?.Invoke(ex.Message, FormAlert.enmType.Error);
                }

            }

            LoadForm();
            comboBoxSelectUsername.Text = username;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string username = comboBoxSelectUsername.Text;

            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa tài khoản {username}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //Xóa tài khoản, xóa xong sẽ load lại danh sách username của form
                try
                {
                    if(username == "admin")
                    {
                        MessageBox.Show("Đây là tài khoản mặc định của hệ thống, bạn không thể xóa.","Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        UserBusiness.DeleteUser(username);
                        changeData?.Invoke($"Xóa thành công tài khoản {username}.", FormAlert.enmType.Success);
                    }
                }
                catch
                {
                    changeData?.Invoke($"Xóa thất bại.", FormAlert.enmType.Error);
                }
                LoadForm();
            }
        }

        //chọn tài khoản để cập nhật
        private void comboBoxSelectUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            //vô hiệu hóa nút xóa khi đây là tài khoản hiện tại
            if (comboBoxSelectUsername.Text == Common.USERSESSION.Username)
            {
                buttonDelete.Enabled = false;
            }
            else
            {
                buttonDelete.Enabled = true;
            }
            //neu la tai khoan admin thi khong the xoa, khong the thay doi ten user
 
            if(comboBoxSelectUsername.Text == "admin" && Common.USERSESSION.Username != "admin")
            {
                textBoxUsername.Enabled = false;
                textBoxFullName.Enabled = false;
                textBoxEmail.Enabled = false;
                textBoxPassword.PasswordChar = true;
                textBoxPassword.Enabled = false;
                textBoxPhoneNumber.Enabled = false;
                comboBoxSelectGroup.Enabled = false;
                comboBoxSelectShift.Enabled = false;
                buttonUpdate.Enabled = false;
            }
            else
            {
                textBoxUsername.Enabled = true;
                textBoxFullName.Enabled = true;
                textBoxEmail.Enabled = true;
                textBoxPassword.PasswordChar = false;
                textBoxPassword.Enabled = true;
                textBoxPhoneNumber.Enabled = true;
                comboBoxSelectGroup.Enabled = true;
                comboBoxSelectShift.Enabled = true;
                buttonUpdate.Enabled = true;

                // lấy ra thông tin user có username là username trên combobox
                try
                {
                    var listUser = UserBusiness.GetAllUsers();
                    string usernameOld = comboBoxSelectUsername.Text;
                    User user = listUser.Single(elm => elm.Username == usernameOld);

                    //show trên textbox

                    textBoxFullName.Texts = user.FullName;
                    textBoxUsername.Texts = user.Username;
                    textBoxPassword.Texts = user.Password;
                    textBoxPhoneNumber.Texts = user.PhoneNumber;
                    textBoxEmail.Texts = user.Email;
                    comboBoxSelectShift.Text = user.NameShift;
                    comboBoxSelectGroup.Text = GroupBusiness.GetGroupFromID(user.ID_Group).Name;
                }
                catch
                {
                    changeData?.Invoke($"Không thể lấy thông tin người dùng này.", FormAlert.enmType.Error);
                }
            }

            if (comboBoxSelectUsername.Text == "admin")
            {
                buttonDelete.Enabled = false;
                textBoxUsername.Enabled = false;
                comboBoxSelectGroup.Enabled = false;
            }
            else
            {
                textBoxUsername.Enabled = true;
                buttonDelete.Enabled = true;
                comboBoxSelectGroup.Enabled = true;
            }

        }

        private void textBoxPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textbox only number 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as LW_PhanMemBaoGia.MyControls.TextBoxT).Texts.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
