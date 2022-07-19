﻿using System;
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
            dt.Columns.Add("No.");
            dt.Columns.Add("Áp suất");
            dt.Columns.Add("Lưu lượng");
            dt.Columns.Add("Thể tích");
            dt.Columns.Add("Thời gian bắt đầu");
            dt.Columns.Add("Thời gian kết thúc");
            dt.Columns.Add("Ngày");


            dataGridViewResult.DataSource = dt;

        }

    }
}
