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

        private bool checkApSuat = false;
        private double apSuat1 = 0;
        private double apSuat2 = 0;

        private bool checkTheTich = false;
        private double theTich1 = 0;
        private double theTich2 = 0;

        private bool checkLuuLuong = false;
        private double luuLuong1 = 0;
        private double luuLuong2 = 0;

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

                string fullname = result.Worker;
                User user = UserBusiness.GetUserFromUserName(result.Worker);
                if (user != null)
                {
                    fullname = user.FullName;
                }
                else
                {
                    fullname = result.Worker + " (không còn tồn tại)";
                }

                if (TimeStart == TimeEnd)
                {
                    dt.Rows.Add(result.ID_Result, "Chưa có", "Chưa có", "Chưa có", "Chưa có", "Chưa có", "Chưa có",
                    "Chưa có", "Chưa có", "Chưa có",
                    TimeStart, "Chưa có", result.NameMachine, fullname);
                }
                else
                {
                    dt.Rows.Add(result.ID_Result, result.ApSuatMin, result.ApSuatMax, result.ApSuatAvg, result.TheTichMin, result.TheTichMax, result.TheTichAvg,
                    result.LuuLuongMin, result.LuuLuongMax, result.LuuLuongAvg,
                    TimeStart, TimeEnd, result.NameMachine, fullname);
                }

            });

            dataGridViewResult.DataSource = dt;
        }



        private void ChangePageSizeFromSumResult(int countResult)
        {
            float value = (float)countResult / (float)Common.NUMBER_ELM_ON_PAGE_RESULT;
            this.pageSize = (int)Math.Ceiling(value);

        }


        //get activity dựa trên thông số trên trang (ngày, trang)
        private void GetResults()
        {
            List<Result> listResults = new List<Result>();

            //dieu kien
            if (this.nameMachine == FormResult.allMachine && this.strDatimeTuNgay == null && this.checkApSuat == false && this.checkTheTich == false && this.checkLuuLuong == false)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_NoName_NoDate_NoParameter());
                listResults = PaginationResult.Pagination_NoName_NoDate_NoParameter(this.page, Common.NUMBER_ELM_ON_PAGE_RESULT);
            }















            //set button
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

            LoadDataGridView(listResults);
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

            //set name machine
            this.nameMachine = comboBoxSelectMay.Text;

            //lấy ngày ở datetimepicker rồi chuyển về dạng yyyy-mm-dd, lưu vào các strdatetime, field của lớp
            DateTime tuNgay = Convert.ToDateTime(dateTimePickerTuNgay.Value);
            DateTime toiNgay = Convert.ToDateTime(dateTimePickerToiNgay.Value).AddDays(1);
            strDatimeTuNgay = tuNgay.Year + "-" + tuNgay.Month + "-" + tuNgay.Day;
            strDatimeToiNgay = toiNgay.Year + "-" + toiNgay.Month + "-" + toiNgay.Day;

            //set check parameter
            this.checkApSuat = checkBoxApSuat.Checked;
            this.checkTheTich = checkBoxTheTich.Checked;
            this.checkLuuLuong = checkBoxLuuLuong.Checked;

            //set value parameter
            this.apSuat1 = Convert.ToDouble(numericUpDownApSuat1.Value);
            this.apSuat2 = Convert.ToDouble(numericUpDownApSuat2.Value);
            this.theTich1 = Convert.ToDouble(numericUpDownTheTich1.Value);
            this.theTich2 = Convert.ToDouble(numericUpDownTheTich2.Value);
            this.luuLuong1 = Convert.ToDouble(numericUpDownLuuLuong1.Value);
            this.luuLuong2 = Convert.ToDouble(numericUpDownLuuLuong2.Value);


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

        private void buttonPage1_Click(object sender, EventArgs e)
        {
            // select button trang
            Button button = sender as Button;

            if (this.page > this.pageSize)
            {
                this.page = this.pageSize;
            }
            else
            {
                this.page = int.Parse(button.Text);
                if (this.page <= 2)
                {
                    buttonPage1.Text = 1.ToString();
                    buttonPage2.Text = 2.ToString();
                    buttonPage3.Text = 3.ToString();
                }
                else
                {
                    buttonPage1.Text = (page - 1).ToString();
                    buttonPage2.Text = page.ToString();
                    buttonPage3.Text = (page + 1).ToString();
                    //nếu tràng hiện tại là trang cuối cùng thì đặt các nút là các những trang cuối
                    if (this.page == this.pageSize)
                    {
                        buttonPage1.Text = (page - 2).ToString();
                        buttonPage2.Text = (page - 1).ToString();
                        buttonPage3.Text = page.ToString();
                    }
                }
            }
            GetResults();

        }

        private void buttonPageNext_Click(object sender, EventArgs e)
        {
            if (this.page == this.pageSize)
            {
                callAlert?.Invoke("Bạn đang ở trang cuối cùng.", FormAlert.enmType.Warning);
            }
            else
            {
                // bấm next sẽ là trang số ở button3 + 1
                int numPageButton3 = int.Parse(buttonPage3.Text);
                if (numPageButton3 < this.pageSize)
                {
                    if (this.page == 1)
                    {
                        this.page = 3;
                        buttonPage1.Text = 2.ToString();
                        buttonPage2.Text = 3.ToString();
                        buttonPage3.Text = 4.ToString();
                    }
                    else
                    {
                        this.page = numPageButton3 + 1;
                        //set lại button 1,2,3 
                        if (this.page == this.pageSize)
                        {
                            buttonPage1.Text = (this.page - 2).ToString();
                            buttonPage2.Text = (this.page - 1).ToString();
                            buttonPage3.Text = (this.page).ToString();
                        }
                        if (this.page + 1 <= this.pageSize)
                        {
                            buttonPage1.Text = (this.page - 1).ToString();
                            buttonPage2.Text = (this.page).ToString();
                            buttonPage3.Text = (this.page + 1).ToString();
                        }
                        if (this.page + 2 <= this.pageSize)
                        {
                            buttonPage1.Text = (this.page).ToString();
                            buttonPage2.Text = (this.page + 1).ToString();
                            buttonPage3.Text = (this.page + 2).ToString();
                        }
                    }


                }
                else
                {
                    this.page = this.pageSize;
                }
                GetResults();
            }
        }
    }
}
