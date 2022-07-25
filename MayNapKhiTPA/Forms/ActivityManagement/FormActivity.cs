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

        private string strDatimeTuNgay = null;
        private string strDatimeToiNgay = null;
        private int page = 1;
        private int pageSize = 0;


        public FormActivity()
        {
            InitializeComponent();
            GetActivities();
        }



        private void LoadForm(List<Activity> activities)
        {
            //
            labelBanGhiMoiTrang.Text = "-Tổng số trang: " + pageSize;
            labelTongSoTrang.Text = "-Bản ghi mỗi trang: " + Common.NUMBER_ELM_ON_PAGE_ACTIVITY;



            //
            DataTable dt = new DataTable();
            dt.Columns.Add("No.", typeof(int));
            dt.Columns.Add("Hoạt động", typeof(string));
            dt.Columns.Add("Thời gian", typeof(DateTime));
            dt.Columns.Add("Tài người thực hiện");

            //
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



        private void GetActivities()
        {
            List<Activity> activities = new List<Activity>();
            ActivityBusiness activityBusiness = new ActivityBusiness();

            if (strDatimeTuNgay == null && strDatimeToiNgay == null)
            {
                try
                {
                    int sumActivity = ActivityBusiness.CountActivity();
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
            // nếu ô tìm kiếm không rỗng và khác placeholder
            if(String.IsNullOrEmpty(textBoxGoPage.Texts) == false && textBoxGoPage.Texts != textBoxGoPage.PlaceholderText)
            {

            }


            this.page = int.Parse(textBoxGoPage.Texts);
            GetActivities();
        }


        //validate input chỉ nhập số
        private void textBoxGoPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textbox only number 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as LW_PhanMemBaoGia.MyControls.TextBoxT).Texts.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }
    }
}
