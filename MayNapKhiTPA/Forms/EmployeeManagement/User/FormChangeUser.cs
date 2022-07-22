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
            LoadForm();
        }
        public void LoadForm()
        {
            var listUsers = UserBusiness.GetAllUsers();
            var listUsername = from user in listUsers select user.Username;
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
            int id_shift = 1;
            int id_group = 1;
        
            User user = new User(fullname, username, password, phonenumber, email, id_shift, id_group);
            if (String.IsNullOrEmpty(fullname) || String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) )
            {
                MessageBox.Show("Vui lòng điền đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    UserBusiness.UpdateUser(usernameOld, user);
                    changeData?.Invoke("Cập nhật thành công.",FormAlert.enmType.Success);
                }
                catch
                {
                    changeData?.Invoke("Cập nhật thất bại.", FormAlert.enmType.Error);
                }
                this.Close();
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
                try
                {
                    UserBusiness.DeleteUser(username);
                    changeData?.Invoke($"Xóa thành công tài khoản {username}.", FormAlert.enmType.Success);
                }
                catch
                {
                    changeData?.Invoke($"Xóa thất bại.", FormAlert.enmType.Error);
                }
                LoadForm();
                this.Close();
            }
        }

        private void comboBoxSelectUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            //vô hiệu hóa nút xóa khi đây là tài khoản hiện tại
            if (comboBoxSelectUsername.Text == Common.UserNameCurrent)
            {
                buttonDelete.Enabled = false;
            }
            else
            {
                buttonDelete.Enabled = true;
            }


            var listUser = UserBusiness.GetAllUsers();
            string usernameOld = comboBoxSelectUsername.Text;
            var users = from user in listUser where user.Username == usernameOld select user;
            foreach (User user in users)
            {
                textBoxFullName.Texts = user.FullName;
                textBoxUsername.Texts = user.Username;
                textBoxPassword.Texts = user.Password;
                textBoxPhoneNumber.Texts = user.PhoneNumber;
                textBoxEmail.Texts = user.Email;

            }
        }
    }
}
