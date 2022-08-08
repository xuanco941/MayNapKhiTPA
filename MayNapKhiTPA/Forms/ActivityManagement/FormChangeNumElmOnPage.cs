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
    public partial class FormChangeNumElmOnPage : Form
    {
        // Define delegate
        public delegate void ChangeData(string msg, FormAlert.enmType enmType);

        // Create instance (null)
        public ChangeData changeData;

        public FormChangeNumElmOnPage()
        {
            InitializeComponent();
            label1.Text = $"Số dòng hiển thị (hiện tại là {Common.NUMBER_ELM_ON_PAGE_ACTIVITY}):";
        }

        private void ChangeNumElm()
        {
            if (!String.IsNullOrEmpty(textBoxNumElm.Texts) && textBoxNumElm.Texts != textBoxNumElm.PlaceholderText && int.Parse(textBoxNumElm.Texts) > 0)
            {
                Common.NUMBER_ELM_ON_PAGE_ACTIVITY = int.Parse(textBoxNumElm.Texts);
                changeData.Invoke("Cập nhật số dòng hiển thị trang hoạt động là: "+textBoxNumElm.Texts,FormAlert.enmType.Success);
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chỉ nhập số.", "Cú pháp sai", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void buttonSaveSetting_Click(object sender, EventArgs e)
        {
            ChangeNumElm();
        }

        private void textBoxNumElm_KeyPress(object sender, KeyPressEventArgs e)
        {
            LW_PhanMemBaoGia.MyControls.TextBoxT textBoxT = sender as LW_PhanMemBaoGia.MyControls.TextBoxT;
            //textbox only number 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //giới hạn length cho text box là 3
            if (textBoxT.Texts.Length > 3)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
        }

        private void textBoxNumElm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChangeNumElm();
            }
        }
    }
}
