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
using MayNapKhiTPA.Forms.EmployeeManagement.User;
using MayNapKhiTPA.Forms.EmployeeManagement.Group;


namespace MayNapKhiTPA.Forms
{
    public partial class FormEmployeeManagement : Form
    {
        public FormEmployeeManagement()
        {
            InitializeComponent();
            LoadForm();
        }
        public void LoadForm()
        {
            var listNhanVien = EmployeeBusiness.GetAllEmployees();
            DataTable dt = new DataTable();
            dt.Columns.Add("Họ tên", typeof(string));
            dt.Columns.Add("Tài khoản", typeof(string));
            dt.Columns.Add("Mật khẩu", typeof(string));
            dt.Columns.Add("Phòng ban", typeof(string));
            dt.Columns.Add("Quyền ", typeof(string));

            listNhanVien.ForEach(delegate (Employee employee)
            {
                string str = employee.IsAdmin == true ? "Mặc định (Admin)" : "Nhân viên";
                dt.Rows.Add(employee.FullName, employee.Username, employee.Password, employee.Department, str);
            });
            dataGridViewUser.DataSource = dt;



        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            // Create an instance of form 2
            FormAddUser formAddUser = new FormAddUser();

            // Create an instance of the delegate
            formAddUser.changeData = new FormAddUser.ChangeData(LoadForm);

            // Show form Them Nhan Vien
            formAddUser.ShowDialog();
        }

        private void buttonChangeUser_Click(object sender, EventArgs e)
        {
            // Create an instance of form 2
            FormChangeUser formChangeUser = new FormChangeUser();

            // Create an instance of the delegate
            formChangeUser.changeData = new FormChangeUser.ChangeData(LoadForm);

            // Show form 2
            formChangeUser.ShowDialog();
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            // Create an instance of form 2
            FormAddGroup formAddGroup = new FormAddGroup();

            // Create an instance of the delegate
            formAddGroup.changeData = new FormAddGroup.ChangeData(LoadForm);

            // Show form 2
            formAddGroup.ShowDialog();
        }

        private void buttonChangeGroup_Click(object sender, EventArgs e)
        {
            // Create an instance of form 2
            FormChangeGroup formChangeGroup = new FormChangeGroup();

            // Create an instance of the delegate
            formChangeGroup.changeData = new FormChangeGroup.ChangeData(LoadForm);

            // Show form 2
            formChangeGroup.ShowDialog();
        }
    }
}
