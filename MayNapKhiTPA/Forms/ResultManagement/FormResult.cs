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
    public partial class FormResult : Form
    {
        // Aleart
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;


        //var name query tất cả
        private const string allMachine = "Tất cả";


        //query 
        private string strDatimeTuNgay = null;
        private string strDatimeToiNgay = null;
        private string nameMachine = allMachine;
        private double ApSuat1 = 0;
        private double ApSuat2 = 0;
        private double TheTich1 = 0;
        private double TheTich2 = 0;
        private double LuuLuong1 = 0;
        private double LuuLuong2 = 0;

        // trang hiện tại
        private int page = 1;
        // tổng số trang
        private int pageSize = 1;


        public FormResult()
        {
            InitializeComponent();
            buttonExcel.ForeColor = Color.Black;
            buttonExcel.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            buttonPrint.ForeColor = Color.Black;
            buttonPrint.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            dataGridViewResult.RowTemplate.Height = 45;


            LoadComboBox();
            GetResults();
        }

        //METHOD
        // Load ComboBox
        private void LoadComboBox()
        {
            List<string> listMay = ResultBusiness.GetListMachineHasResult();
            listMay.Insert(0, allMachine);
            comboBoxSelectMay.DataSource = listMay;
        }
        // Load DataGridView
        private void LoadDataGridView(List<Result> list)
        {
            //
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã mẻ");
            dt.Columns.Add("Áp suất min");
            dt.Columns.Add("Áp suất max");
            dt.Columns.Add("Áp suất trung bình");

            dt.Columns.Add("Thể tích min");
            dt.Columns.Add("Thể tích max");
            dt.Columns.Add("Thể tích trung bình");

            dt.Columns.Add("Lưu lượng min");
            dt.Columns.Add("Lưu lượng max");
            dt.Columns.Add("Lưu lượng trung bình");

            dt.Columns.Add("Thời gian bắt đầu");
            dt.Columns.Add("Thời gian kết thúc");
            dt.Columns.Add("Máy thực hiện");

            dt.Columns.Add("Người thực hiện");

            list.ForEach(delegate (Result result)
            {
                //format date từ sql -> c#
                string TimeStart = result.TimeStart.ToString("hh:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                string TimeEnd = result.TimeEnd.ToString("hh:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);

                string fullnameButton = result.Worker;
                User user = UserBusiness.GetUserFromUserName(result.Worker);
                if (user != null)
                {
                    fullnameButton = user.FullName;
                }
                else
                {
                    fullnameButton = result.Worker + " (không còn tồn tại)";
                }

                if (TimeStart == TimeEnd)
                {
                    dt.Rows.Add(result.ID_Result, "Chưa có", "Chưa có", "Chưa có", "Chưa có", "Chưa có", "Chưa có",
                    "Chưa có", "Chưa có", "Chưa có",
                    TimeStart, "Chưa có", result.NameMachine, fullnameButton);
                }
                else
                {
                    dt.Rows.Add(result.ID_Result, result.ApSuatMin, result.ApSuatMax, result.ApSuatAvg, result.TheTichMin, result.TheTichMax, result.TheTichAvg,
                    result.LuuLuongMin, result.LuuLuongMax, result.LuuLuongAvg,
                    TimeStart, TimeEnd, result.NameMachine, fullnameButton);
                }

            });

            dataGridViewResult.DataSource = dt;
        }




        //get activity dựa trên thông số trên trang (ngày, trang)
        private void GetResults()
        {
            List<Result> results = new List<Result>();

            // nếu tham số không có ngày thì get tất cả
            if (strDatimeTuNgay == null && strDatimeToiNgay == null)
            {
                try
                {
                    // đếm tổng số activity
                    int sumResult = ResultBusiness.CountResult();
                    // pagesize bằng tổng số activity chia cho số phần tử mỗi trang
                    this.pageSize = (sumResult / Common.NUMBER_ELM_ON_PAGE_RESULT);
                    if (sumResult % Common.NUMBER_ELM_ON_PAGE_RESULT != 0)
                    {
                        this.pageSize = this.pageSize + 1;
                    }
                    results = ResultBusiness.GetAllResults(page);
                }
                catch
                {
                    // Lỗi
                }
            }
            // nếu có ngày
            else
            {
                try
                {
                    int sumResult = ResultBusiness.CountResultByDay(strDatimeTuNgay, strDatimeToiNgay);
                    this.pageSize = (sumResult / Common.NUMBER_ELM_ON_PAGE_RESULT);
                    if (sumResult % Common.NUMBER_ELM_ON_PAGE_RESULT != 0)
                    {
                        this.pageSize = this.pageSize + 1;
                    }
                    results = ResultBusiness.GetResultByDay(strDatimeTuNgay, strDatimeToiNgay, page);
                }
                catch
                {
                    //Lỗi
                }
            }






            if (this.pageSize == 0)
            {
                buttonPage1.Enabled = false;
                buttonPage2.Enabled = false;
                buttonPage3.Enabled = false;
                buttonPageNext.Enabled = false;
            }
            else if (this.pageSize == 1)
            {
                buttonPage1.Enabled = true;
                buttonPage2.Enabled = false;
                buttonPage3.Enabled = false;
                buttonPageNext.Enabled = false;
            }
            else if (this.pageSize == 2)
            {
                buttonPage1.Enabled = true;
                buttonPage2.Enabled = true;
                buttonPage3.Enabled = false;
                buttonPageNext.Enabled = false;
            }
            else if (this.pageSize == 3)
            {
                buttonPage1.Enabled = true;
                buttonPage2.Enabled = true;
                buttonPage3.Enabled = true;
                buttonPageNext.Enabled = false;
            }
            else
            {
                buttonPage1.Enabled = true;
                buttonPage2.Enabled = true;
                buttonPage3.Enabled = true;
                buttonPageNext.Enabled = true;
            }

            LoadDataGridView(results);
        }




        private void GoPage()
        {
            // nếu ô tìm kiếm không rỗng và khác placeholder
            if (String.IsNullOrEmpty(textBoxGoPage.Texts) == false && textBoxGoPage.Texts != textBoxGoPage.PlaceholderText && int.Parse(textBoxGoPage.Texts) > 0)
            {
                if (int.Parse(textBoxGoPage.Texts) > this.pageSize)
                {
                    callAlert?.Invoke("Số trang tối đa hiện tại là: " + pageSize, FormAlert.enmType.Info);
                }
                else
                {
                    this.page = int.Parse(textBoxGoPage.Texts);
                    GetResults();
                    //set lại button trang
                    if (this.page == this.pageSize)
                    {
                        buttonPage1.Text = (page - 2).ToString();
                        buttonPage2.Text = (page - 1).ToString();
                        buttonPage3.Text = page.ToString();
                    }
                    else
                    {
                        buttonPage1.Text = (page - 1).ToString();
                        buttonPage2.Text = page.ToString();
                        buttonPage3.Text = (page + 1).ToString();
                    }

                }
            }
        }



        private void textBoxGoPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textbox only number 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //giới hạn length cho text box là 6
            if (textBoxGoPage.Texts.Length > 5)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
        }

        private void buttonCallFormData_Click(object sender, EventArgs e)
        {
            new FormData().Show();
        }

        private void buttonCustomLoc_Click(object sender, EventArgs e)
        {
            //lấy ngày ở datetimepicker rồi chuyển về dạng yyyy-mm-dd, lưu vào các strdatetime, field của lớp
            DateTime tuNgay = Convert.ToDateTime(dateTimePickerTuNgay.Value);
            DateTime toiNgay = Convert.ToDateTime(dateTimePickerToiNgay.Value).AddDays(1);
            strDatimeTuNgay = tuNgay.Year + "-" + tuNgay.Month + "-" + tuNgay.Day;
            strDatimeToiNgay = toiNgay.Year + "-" + toiNgay.Month + "-" + toiNgay.Day;
            //đặt page về trang 1, đặt các button về mặc định
            this.page = 1;
            buttonPage1.Text = 1.ToString();
            buttonPage2.Text = 2.ToString();
            buttonPage3.Text = 3.ToString();

            GetResults();
        }

        private void buttonCustomGoPage_Click(object sender, EventArgs e)
        {
            GoPage();
        }

        private void textBoxGoPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GoPage();
            }
        }
    }
}
