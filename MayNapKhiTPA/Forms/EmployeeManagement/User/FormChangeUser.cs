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
    public partial class FormChangeUser : Form
    {
        // Define delegate
        public delegate void ChangeData();

        // Create instance (null)
        public ChangeData changeData;
        public FormChangeUser()
        {
            InitializeComponent();
            //LoadForm();
        }
        //public void LoadForm()
        //{
        //    var listNV = EmployeeBusiness.GetAllEmployees();
        //    var listTaiKhoan = from employee in listNV select employee.Username;
        //    comboBoxChonTaiKhoan.DataSource = listTaiKhoan.ToList();

        //}

        //private void buttonSua_Click(object sender, EventArgs e)
        //{
        //    string UsernameOld = comboBoxChonTaiKhoan.Text;
        //    string hoTen = textBoxFullName.Text;
        //    string taiKhoan = textBoxUsername.Text.Trim();
        //    string matKhau = textBoxPassword.Text.Trim();
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
        //    Employee employee = new Employee(hoTen, taiKhoan, matKhau, department, isAdmin);
        //    if (String.IsNullOrEmpty(hoTen) || String.IsNullOrEmpty(taiKhoan) || String.IsNullOrEmpty(matKhau) || String.IsNullOrEmpty(department))
        //    {
        //        MessageBox.Show("Vui lòng điền đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //    else
        //    {
        //        try
        //        {
        //            EmployeeBusiness.UpdateEmployee(UsernameOld, employee);
        //            MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            changeData?.Invoke();
        //        }
        //        catch
        //        {
        //            MessageBox.Show("Cập nhật thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

        //    LoadForm();
        //    comboBoxChonTaiKhoan.Text = taiKhoan;
        //}

        //private void comboBoxChonTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //vô hiệu hóa nút xóa khi đây là tài khoản hiện tại
        //    if (comboBoxChonTaiKhoan.Text == Common.UserNameCurrent)
        //    {
        //        button1.Enabled = false;
        //    }
        //    else
        //    {
        //        button1.Enabled = true;
        //    }


        //    var listNV = EmployeeBusiness.GetAllEmployees();
        //    string TaiKhoanCu = comboBoxChonTaiKhoan.Text;
        //    var employees = from employee in listNV where employee.Username == TaiKhoanCu select employee;
        //    foreach (Employee nv in employees)
        //    {
        //        textBoxFullName.Text = nv.FullName;
        //        textBoxUsername.Text = nv.Username;
        //        textBoxPassword.Text = nv.Password;
        //        textBoxDepartment.Text = nv.Department;
        //        if (nv.IsAdmin == true)
        //        {
        //            radioButtonCo.Checked = true;
        //        }
        //        else
        //        {
        //            radioButtonKhong.Checked = true;
        //        }
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string username = comboBoxChonTaiKhoan.Text;

        //    DialogResult dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa tài khoản {username}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (dialogResult == DialogResult.Yes)
        //    {
        //        try
        //        {
        //            EmployeeBusiness.DeleteEmployee(username);
        //            changeData?.Invoke();
        //        }
        //        catch
        //        {
        //            MessageBox.Show("Xóa thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //        LoadForm();
        //    }


        //}
    }
}
