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
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.ShowUpDown = true;

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        //textbox only number type
        private void textBoxT5_KeyPress(object sender, KeyPressEventArgs e)
        {
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
