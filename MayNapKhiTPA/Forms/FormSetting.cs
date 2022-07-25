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
    public partial class FormSetting : Form
    {
        // Aleart
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;


        public FormSetting()
        {
            InitializeComponent();
        }

        //textbox only number type tabpage 1
        private void textBoxT5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxApSuatNap_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textbox chỉ nhập số  
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // chỉ cho 1 dấu chấm
            if ((e.KeyChar == '.') && ((sender as LW_PhanMemBaoGia.MyControls.TextBoxT).Texts.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
