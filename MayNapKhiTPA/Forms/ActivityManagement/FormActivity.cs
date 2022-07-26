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
using MayNapKhiTPA.Models;
using MayNapKhiTPA.Forms.ActivityManagement;
namespace MayNapKhiTPA.Forms
{
    public partial class FormActivity : Form
    {
        // Aleart
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;


        // ngày để query 
        private string strDatimeTuNgay = null;
        private string strDatimeToiNgay = null;
        // trang hiện tại
        private int page = 1;
        // tổng số trang
        private int pageSize = 1;


        public FormActivity()
        {
            InitializeComponent();
            GetActivities();
        }

        // Load form
        private void LoadForm(List<Activity> activities)
        {
            //
            labelBanGhiMoiTrang.Text = "- Tổng số trang: " + pageSize;
            labelTongSoTrang.Text = "- Bản ghi mỗi trang: " + Common.NUMBER_ELM_ON_PAGE_ACTIVITY;
            labelPage.Text = "- Đang ở trang: " + this.page;


            //
            DataTable dt = new DataTable();
            dt.Columns.Add("No.", typeof(int));
            dt.Columns.Add("Hoạt động", typeof(string));
            dt.Columns.Add("Thời gian", typeof(DateTime));
            dt.Columns.Add("Tài người thực hiện");

            // load datagridview từ tham số activities truyền vào
            int count = 1;
            activities.ForEach(delegate (Activity activity)
            {
                User user = UserBusiness.GetUserFromID(activity.ID_User);
                //format date từ sql -> c#
                string createAt = activity.Create_At.ToString("dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                dt.Rows.Add(count, activity.Description, createAt, user.FullName);
                count++;
            });
            dataGridViewActivity.DataSource = dt;
        }

        //get activity dựa trên thông số trên trang (ngày, trang)
        private void GetActivities()
        {
            List<Activity> activities = new List<Activity>();
            ActivityBusiness activityBusiness = new ActivityBusiness();

            // nếu tham số không có ngày thì get tất cả
            if (strDatimeTuNgay == null && strDatimeToiNgay == null)
            {
                try
                {
                    // đếm tổng số activity
                    int sumActivity = ActivityBusiness.CountActivity();
                    // pagesize bằng tổng số activity chia cho số phần tử mỗi trang
                    pageSize = (sumActivity / Common.NUMBER_ELM_ON_PAGE_ACTIVITY);
                    if (sumActivity % Common.NUMBER_ELM_ON_PAGE_ACTIVITY != 0)
                    {
                        pageSize = pageSize + 1;
                    }
                    activities = ActivityBusiness.GetAllActivities(page);
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
                    int sumActivity = ActivityBusiness.CountActivityByDay(strDatimeTuNgay, strDatimeToiNgay);
                    int countPage = (sumActivity / Common.NUMBER_ELM_ON_PAGE_ACTIVITY);
                    if (sumActivity % Common.NUMBER_ELM_ON_PAGE_ACTIVITY != 0)
                    {
                        countPage = countPage + 1;
                    }
                    activities = activityBusiness.GetActivityByDay(strDatimeTuNgay, strDatimeToiNgay, page);
                }
                catch
                {
                    //Lỗi
                }
            }
            LoadForm(activities);
        }

        private void GoPage()
        {
            // nếu ô tìm kiếm không rỗng và khác placeholder
            if (String.IsNullOrEmpty(textBoxGoPage.Texts) == false && textBoxGoPage.Texts != textBoxGoPage.PlaceholderText)
            {
                if (int.Parse(textBoxGoPage.Texts) > this.pageSize)
                {
                    callAlert?.Invoke("Tổng số trang hiện tại là: " + pageSize, FormAlert.enmType.Error);
                }
                else
                {
                    this.page = int.Parse(textBoxGoPage.Texts);
                    GetActivities();
                }
            }
        }


        // show form chia tiết hoạt động của user
        private void buttonCallFormEmployeeActivities_Click(object sender, EventArgs e)
        {
            // Create an instance of form 
            FormEmployeeActivities formEmployeeActivities = new FormEmployeeActivities();

            // Show form 
            formEmployeeActivities.Show();
        }

        private void buttonLoc_Click_1(object sender, EventArgs e)
        {
            //lấy ngày ở datetimepicker rồi chuyển về dạng yyyy-mm-dd, lưu vào các strdatetime, field của lớp
            DateTime tuNgay = Convert.ToDateTime(dateTimePickerTuNgay.Value);
            DateTime toiNgay = Convert.ToDateTime(dateTimePickerToiNgay.Value).AddDays(1);
            strDatimeTuNgay = tuNgay.Year + "-" + tuNgay.Month + "-" + tuNgay.Day;
            strDatimeToiNgay = toiNgay.Year + "-" + toiNgay.Month + "-" + toiNgay.Day;
            page = 1;
            GetActivities();
        }

        private void buttonGoPage_Click(object sender, EventArgs e)
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


        //validate input chuyển trang chỉ nhập số
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

        //3 nút chuyển trang (số)
        private void buttonPage1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            this.page = int.Parse(button.Text);

            if (this.page < 2)
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
            }

            GetActivities();
        }

        //btn next page
        private void buttonPageNext_Click(object sender, EventArgs e)
        {
            int numPageButton3 = int.Parse(buttonPage3.Text);
            if (pageSize == numPageButton3)
            {
                this.page = pageSize;
            }
            else
            {
                this.page = numPageButton3 + 1;
            }
            GetActivities();
        }

    
    }
}
