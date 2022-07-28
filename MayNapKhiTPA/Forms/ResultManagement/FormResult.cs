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
    public partial class FormResult : Form
    {

        public FormResult()
        {
            InitializeComponent();
            buttonExcel.ForeColor = Color.Black;
            buttonExcel.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            buttonPrint.ForeColor = Color.Black;
            buttonPrint.Font = new Font("Segoe UI", 9, FontStyle.Bold);


            //
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã mẻ");
            dt.Columns.Add("Áp suất min");
            dt.Columns.Add("Áp suất max");
            dt.Columns.Add("Áp suất trung bình");

            dt.Columns.Add("Lưu lượng min");
            dt.Columns.Add("Lưu lượng max");
            dt.Columns.Add("Lưu lượng trung bình");

            dt.Columns.Add("Thể tích min");
            dt.Columns.Add("Thể tích max");
            dt.Columns.Add("Thể tích trung bình");

            dt.Columns.Add("Thời gian bắt đầu");
            dt.Columns.Add("Thời gian kết thúc");
            dt.Columns.Add("Máy thực hiện");

            dt.Columns.Add("Ngày");


            dataGridViewResult.DataSource = dt;

            List<string> listMay = new List<string> { "Máy nạp 1", "Máy nạp 2", "Tất cả" };
            comboBoxSelectMay.DataSource = listMay;


        }

        private void textBoxGoPage_KeyPress(object sender, KeyPressEventArgs e)
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

        private void buttonCallFormData_Click(object sender, EventArgs e)
        {
            new FormData().Show();
        }
    }
}
