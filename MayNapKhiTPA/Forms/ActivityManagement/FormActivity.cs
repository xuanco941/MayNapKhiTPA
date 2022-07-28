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

            //setting header column
            dataGridViewActivity.ColumnHeadersDefaultCellStyle.Font = new Font("Bahnschrift", 12, FontStyle.Regular);
        }


        // Load form
        private void LoadForm(List<Activity> activities)
        {
            //
            labelBanGhiMoiTrang.Text = "- Tổng số trang: " + pageSize;
            labelTongSoTrang.Text = "- Bản ghi mỗi trang: " + Common.NUMBER_ELM_ON_PAGE_ACTIVITY;
            labelPage.Text = "- Đang ở trang: " + this.page;
            //
            if (strDatimeTuNgay != null && strDatimeToiNgay != null)
            {
                string[] arr1 = strDatimeTuNgay.Split('-');
                string[] arr2 = strDatimeToiNgay.Split('-');
                string infoTuNgay = arr1[2] + "-" + arr1[1] + "-" + arr1[0];
                string infoToiNgay = (int.Parse(arr2[2]) - 1) + "-" + arr2[1] + "-" + arr2[0];
                if (infoTuNgay == infoToiNgay)
                {
                    labelTuNgay.Text = "- Hoạt động trong ngày: " + infoTuNgay;
                    labelToiNgay.Text = "";
                }
                else
                {
                    labelTuNgay.Text = "- Từ ngày: " + infoTuNgay;
                    labelToiNgay.Text = "- Tới ngày: " + infoToiNgay;
                }
            }
            else
            {
                labelTuNgay.Text = "- Không có.";
                labelToiNgay.Text = "- Không có.";
            }

            //
            DataTable dt = new DataTable();
            dt.Columns.Add("No.");
            dt.Columns.Add("Hoạt động");
            dt.Columns.Add("Thời gian");
            dt.Columns.Add("Tên người thực hiện");

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
                    this.pageSize = (sumActivity / Common.NUMBER_ELM_ON_PAGE_ACTIVITY);
                    if (sumActivity % Common.NUMBER_ELM_ON_PAGE_ACTIVITY != 0)
                    {
                        this.pageSize = this.pageSize + 1;
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
                    this.pageSize = (sumActivity / Common.NUMBER_ELM_ON_PAGE_ACTIVITY);
                    if (sumActivity % Common.NUMBER_ELM_ON_PAGE_ACTIVITY != 0)
                    {
                        this.pageSize = this.pageSize + 1;
                    }
                    activities = activityBusiness.GetActivityByDay(strDatimeTuNgay, strDatimeToiNgay, page);
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

            LoadForm(activities);
        }

        private void GoPage()
        {
            // nếu ô tìm kiếm không rỗng và khác placeholder
            if (String.IsNullOrEmpty(textBoxGoPage.Texts) == false && textBoxGoPage.Texts != textBoxGoPage.PlaceholderText)
            {
                if (int.Parse(textBoxGoPage.Texts) > this.pageSize)
                {
                    callAlert?.Invoke("Số trang tối đa hiện tại là: " + pageSize, FormAlert.enmType.Error);
                }
                else
                {
                    this.page = int.Parse(textBoxGoPage.Texts);
                    GetActivities();
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


        // show form chia tiết hoạt động của user
        private void buttonCallFormEmployeeActivities_Click(object sender, EventArgs e)
        {
            // Show form 
            new FormEmployeeActivities().Show();
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
            // select button trang
            Button button = sender as Button;

            if (this.page > this.pageSize)
            {
                this.page = this.pageSize;
            }
            else
            {
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
                    //nếu tràng hiện tại là trang cuối cùng thì đặt các nút là các những trang cuối
                    if (this.page == this.pageSize)
                    {
                        buttonPage1.Text = (page - 2).ToString();
                        buttonPage2.Text = (page - 1).ToString();
                        buttonPage3.Text = page.ToString();
                    }
                }
            }
            GetActivities();


        }

        //btn next page
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
                GetActivities();
            }


        }

        private void buttonLoc_Click(object sender, EventArgs e)
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

            GetActivities();
        }
    }
}
