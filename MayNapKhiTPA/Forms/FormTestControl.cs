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
    public partial class FormTestControl : Form
    {
        public FormTestControl()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;


            //
            //
            DataTable dt = new DataTable();
            dt.Columns.Add("No.", typeof(int));
            dt.Columns.Add("Hoạt động", typeof(string));
            dt.Columns.Add("Thời gian", typeof(DateTime));
            dt.Columns.Add("Tên người thực hiện");

            // load datagridview từ tham số activities truyền vào
            
            dataGridView1.DataSource = dt;
        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {

        }
    }
}
