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
    public partial class FormData : Form
    {
        public FormData()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            dt.Columns.Add("Áp suất");

            dt.Columns.Add("Lưu lượng");

            dt.Columns.Add("Thể tích");

            dt.Columns.Add("Máy thực hiện");

            dt.Columns.Add("Thời gian");


            dataGridViewSearchData.DataSource = dt;
        }

        private void textBoxApSuatNap_KeyPress(object sender, KeyPressEventArgs e)
        {
            LW_PhanMemBaoGia.MyControls.TextBoxT textBoxT = sender as LW_PhanMemBaoGia.MyControls.TextBoxT;
            //textbox only number 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //giới hạn length cho text box là 6
            if (textBoxT.Texts.Length > 5)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
        }
    }
}
