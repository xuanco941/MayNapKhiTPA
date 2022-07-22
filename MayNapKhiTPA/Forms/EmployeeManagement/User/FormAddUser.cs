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

namespace MayNapKhiTPA.Forms.EmployeeManagement.User
{
    public partial class FormAddUser : Form
    {
        public FormAddUser()
        {

            InitializeComponent();
        }
        // Define delegate
        public delegate void ChangeData();

        // Create instance (null)
        public ChangeData changeData;

        private void buttonThem_Click(object sender, EventArgs e)
        {
            string fullname = textBoxFullName.Texts;
            string username = textBoxUsername.Texts.Trim();
            string password = textBoxPassword.Texts.Trim();
            string phonenumber = textBoxSoDienThoai.Texts.Trim();
            string email = textBoxEmail.Texts.Trim();

            int id_shift = 1;
            int id_permission = 1;

            Employee employee = new Employee(fullname, username, password, phonenumber, email, id_shift, id_permission);

            if (String.IsNullOrEmpty(fullname) || String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                try
                {
                    EmployeeBusiness.AddEmployee(employee);
                    MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    changeData?.Invoke();
                }
                catch
                {
                    MessageBox.Show("Thêm nhân viên thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

        }

    }
}
