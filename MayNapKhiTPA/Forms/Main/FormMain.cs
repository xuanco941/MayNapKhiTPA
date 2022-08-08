using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayNapKhiTPA.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            //fullscreen
            this.WindowState = FormWindowState.Maximized;

            //
            labelHeader.Text = "Bảng điều khiển";
            FormDashboard formDashboard = new FormDashboard();
            formDashboard.callAlert = new FormDashboard.CallAlert(Alert);
            ChangeFormContent(formDashboard);
            this.Font = new Font("Bahnschrift", 11);
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            Common.USERSESSION = null;
            Common.GROUPSESSION = null;
            Application.Restart();
        }

        private void ChangeFormContent(Form form)
        {
            //remove controls in panel
            panelContent.Controls.Clear();

            //set new content
            form.TopLevel = false;
            panelContent.Controls.Add(form);
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void buttonNhanVien_Click(object sender, EventArgs e)
        {
            labelHeader.Text = "Quản lý nhân sự";
            FormEmployeeManagement formEmployeeManagement = new FormEmployeeManagement();
            formEmployeeManagement.callAlert = new FormEmployeeManagement.CallAlert(Alert);
            ChangeFormContent(formEmployeeManagement);
            this.Font = new Font("Bahnschrift", 11);

        }


        private void buttonDashboard_Click_1(object sender, EventArgs e)
        {
            labelHeader.Text = "Bảng điều khiển";
            FormDashboard formDashboard = new FormDashboard();
            formDashboard.callAlert = new FormDashboard.CallAlert(Alert);
            ChangeFormContent(formDashboard);
            this.Font = new Font("Bahnschrift", 11);


        }

        private void buttonLichSuDo_Click(object sender, EventArgs e)
        {
            //check quyền
            if (Common.GROUPSESSION.IsViewResult)
            {
                labelHeader.Text = "Lịch sử nạp khí";
                FormResult formResult = new FormResult();
                formResult.callAlert = new FormResult.CallAlert(Alert);
                ChangeFormContent(formResult);
                this.Font = new Font("Bahnschrift", 11);
            }
            else
            {
               Alert("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }

        }

        private void buttonActivity_Click(object sender, EventArgs e)
        {
            //check quyền
            if (Common.GROUPSESSION.IsViewResult)
            {
                labelHeader.Text = "Hoạt động";
                FormActivity formActivity = new FormActivity();
                formActivity.callAlert = new FormActivity.CallAlert(Alert);
                ChangeFormContent(formActivity);
                this.Font = new Font("Bahnschrift", 11);
            }
            else
            {
                Alert("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelHeader.Text = "Cài đặt";
            FormSetting formSetting = new FormSetting();
            formSetting.callAlert = new FormSetting.CallAlert(Alert);
            ChangeFormContent(formSetting);
            this.Font = new Font("Bahnschrift", 11);
        }


        public void Alert(string msg, FormAlert.enmType type)
        {
            FormAlert frm = new FormAlert();
            frm.showAlert(msg, type);
            panelAleart.Controls.Add(frm);
        }
    }
}
