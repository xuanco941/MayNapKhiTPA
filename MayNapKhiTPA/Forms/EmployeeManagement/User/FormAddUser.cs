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

        //private void buttonThem_Click(object sender, EventArgs e)
        //{
        //    string fullname = textBoxHoTen.Text;
        //    string username = textBoxTaiKhoan.Text.Trim();
        //    string password = textBoxMatKhau.Text.Trim();
        //    string department = textBoxDepartment.Text;
        //    bool isAdmin = false;
        //    if (radioButtonCo.Checked)
        //    {
        //        isAdmin = true;
        //    }
        //    if (radioButtonKhong.Checked)
        //    {
        //        isAdmin = false;
        //    }

        //    Employee employee = new Employee(fullname, username, password, department,isAdmin);

        //    if (String.IsNullOrEmpty(fullname) || String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
        //    {
        //        MessageBox.Show("Vui lòng điền đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //    else
        //    {
        //        if (EmployeeBusiness.AddEmployee(employee) == true)
        //        {
        //            MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            textBoxHoTen.Text = null;
        //            textBoxTaiKhoan.Text = null;
        //            textBoxMatKhau.Text = null;
        //            textBoxDepartment.Text = null;
        //            radioButtonKhong.Checked = true;
        //            changeData?.Invoke();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Thêm nhân viên thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

        //}

    }
}
