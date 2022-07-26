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
    public partial class FormAddUser : Form
    {
        public FormAddUser()
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
        }
        // Define delegate
        public delegate void ChangeData(string msg, FormAlert.enmType enmType);

        // Create instance (null)
        public ChangeData changeData;

        private void buttonThem_Click(object sender, EventArgs e)
        {
            string fullname = textBoxFullName.Texts;
            string username = textBoxUsername.Texts.Trim();
            string password = textBoxPassword.Texts.Trim();
            string phonenumber = textBoxSoDienThoai.Texts.Trim();
            string email = textBoxEmail.Texts.Trim();

            int id_shift = ShiftBusiness.GetShiftFromName(comboBoxSelectShift.Text).ID_Shift;
            int id_group = GroupBusiness.GetGroupFromName(comboBoxSelectGroup.Text).ID_Group;

            User user = new User(fullname, username, password, phonenumber, email, id_shift, id_group);

            if (String.IsNullOrEmpty(fullname) || String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                try
                {
                    UserBusiness.AddUser(user);
                    changeData?.Invoke($"Thêm thành công tài khoản {user.Username}.",FormAlert.enmType.Success);
                    this.Close();
                }
                catch
                {
                    changeData?.Invoke("Thêm tài khoản thất bại, tên tài khoản phải là duy nhất.", FormAlert.enmType.Error);
                }

            }

        }

        private void textBoxSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
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
