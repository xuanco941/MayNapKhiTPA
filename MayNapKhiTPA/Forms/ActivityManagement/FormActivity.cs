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
            dataGridViewActivity.RowTemplate.Height = 35;
        }


        // Load form
        private void LoadForm(List<Activity> activities)
        {
            //
            labelBanGhiMoiTrang.Text = "- Tổng số trang: " + pageSize+".";
            labelTongSoTrang.Text = "- Bản ghi mỗi trang: " + Common.NUMBER_ELM_ON_PAGE_ACTIVITY+".";
            labelPage.Text = "- Đang ở trang: " + this.page+".";
            //
            if (strDatimeTuNgay != null && strDatimeToiNgay != null)
            {
                string[] arr1 = strDatimeTuNgay.Split('-');
                string[] arr2 = strDatimeToiNgay.Split('-');
                string infoTuNgay = arr1[2] + "-" + arr1[1] + "-" + arr1[0];
                string infoToiNgay = (int.Parse(arr2[2]) - 1) + "-" + arr2[1] + "-" + arr2[0];
                labelTuNgay.Text = "- Lọc từ ngày: " + infoTuNgay + ".";
                labelToiNgay.Text = "- Lọc tới ngày: " + infoToiNgay + ".";
            }
            else
            {
                labelTuNgay.Text = "- Lọc từ ngày: trống.";
                labelToiNgay.Text = "- Lọc tới ngày: trống.";
            }

            //
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Hoạt động");
            dt.Columns.Add("Thời gian");
            dt.Columns.Add("Người thực hiện");

            // load datagridview từ tham số activities truyền vào
            activities.ForEach(delegate (Activity activity)
            {
                string fullnameButton = activity.Worker;
                User user = UserBusiness.GetUserFromUserName(activity.Worker);
                if (user != null)
                {
                    fullnameButton = user.FullName;
                }
                else
                {
                    fullnameButton = activity.Worker + " (không còn tồn tại)";
                }
                //format date từ sql -> c#
                string createAt = activity.Create_At.ToString("hh:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                dt.Rows.Add(activity.ID_Activity, activity.Description, createAt, fullnameButton);
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
                    MessageBox.Show("Không thể tải lên dữ liệu", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Không thể tải lên dữ liệu", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (String.IsNullOrEmpty(textBoxGoPage.Texts) == false && textBoxGoPage.Texts != textBoxGoPage.PlaceholderText && int.Parse(textBoxGoPage.Texts) > 0)
            {
                if (int.Parse(textBoxGoPage.Texts) > this.pageSize)
                {
                    callAlert?.Invoke("Số trang tối đa hiện tại là: " + pageSize, FormAlert.enmType.Info);
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
            GetActivities();


        }

        //btn next page
        private void buttonPageNext_Click(object sender, EventArgs e)
        {
            if (this.page == this.pageSize)
            {
                callAlert?.Invoke("Bạn đang ở trang cuối cùng.", FormAlert.enmType.Info);
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

        private void buttonLoc_Click_1(object sender, EventArgs e)
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

        private void buttonCallFormEmployeeActivities_Click(object sender, EventArgs e)
        {
            new FormEmployeeActivities().Show();
        }



        public void AlertActive(string msg, FormAlert.enmType enmType)
        {
            callAlert?.Invoke(msg, enmType);
            //load lai datagridview
            this.page = 1;
            buttonPage1.Text = 1.ToString();
            buttonPage2.Text = 2.ToString();
            buttonPage3.Text = 3.ToString();
            GetActivities();
            
        }
        private void btnChangeNumElmPage_Click(object sender, EventArgs e)
        {
            FormChangeNumElmOnPage form = new FormChangeNumElmOnPage();
            form.changeData = new FormChangeNumElmOnPage.ChangeData(AlertActive);
            form.ShowDialog();
        }
        private void buttonDeleteDataActivity_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa dữ liệu hoạt động đang hiển thị tại trang này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridViewActivity.Rows)
                {
                    try
                    {
                        ActivityBusiness.DeleteActivityFromID(int.Parse(row.Cells[0].Value.ToString()));
                    }
                    catch
                    {
                        continue;
                    }
                }
                this.page = 1;
                buttonPage1.Text = 1.ToString();
                buttonPage2.Text = 2.ToString();
                buttonPage3.Text = 3.ToString();
                GetActivities();
                callAlert("Xóa thành công!", FormAlert.enmType.Success);
            }
        }


    }
}
