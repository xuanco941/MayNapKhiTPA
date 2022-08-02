using MayNapKhiTPA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        }

        private void LoadDataGridView(List<Data> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Áp suất");

            dt.Columns.Add("Thể tích");

            dt.Columns.Add("Lưu lượng");

            dt.Columns.Add("Ngày");

            list.ForEach(delegate (Data data)
            {
                dt.Rows.Add(data.ApSuat, data.TheTich, data.LuuLuong);
            });

            dataGridViewSearchData.DataSource = dt;
        }

        private void LoadInfo(string timeStart, string timeEnd, string nameMachine, string nameUser)
        {
            labelNgayBatDau.Text = "- Thời gian bắt đầu : " + timeStart;
            labelNgayKetThuc.Text = "- Thời gian kết thúc : " + timeEnd;
            labelMachine.Text = "- Máy thực hiện : " + nameMachine;
            labelFullNameUser.Text = "- Người thực hiện : " + nameUser;
        }

        //đang làm dở
        private void LoadForm()
        {
            if (String.IsNullOrEmpty(textBoxIDResult.Texts) == false && textBoxIDResult.Texts != textBoxIDResult.PlaceholderText)
            {
                int IDResult = int.Parse(textBoxIDResult.Texts);

                Result result = ResultBusiness.GetResultFromID(IDResult);
                if(result != null)
                {
                    string TimeStart = result.TimeStart.ToString("dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                    string TimeEnd = result.TimeEnd.ToString("dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                    if (TimeStart == TimeEnd)
                    {
                        LoadInfo("Chưa có", "Chưa có", "Chưa có", "Chưa có");
                    }
                    else
                    {
                        LoadInfo(TimeStart,TimeEnd,result.NameMachine,result.Worker);
                        LoadDataGridView(DataBusiness.GetAllDatasByIDResult(IDResult));
                    }
                }
                else
                {
                    //alert
                }

            }
        }
        private void buttonViewDetsil_Click(object sender, EventArgs e)
        {

        }

        private void textBoxIDResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
        }

        private void textBoxIDResult_KeyPress(object sender, KeyPressEventArgs e)
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
