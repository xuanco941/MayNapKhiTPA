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
namespace MayNapKhiTPA.Forms
{
    public partial class FormSetting : Form
    {
        // Aleart
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;

        //pagination datagridview setting
        // trang hiện tại
        private int page = 1;
        // tổng số trang
        private int pageSize = 1;

        public FormSetting()
        {
            InitializeComponent();

            //setting
            LoadSetting();

            // template setting
            dataGridViewTemplateSetting.RowTemplate.Height = 50;
            LoadDataGridViewTemplateSetting();

            //shift
            dataGridViewShift.RowTemplate.Height = 50;
            LoadDataGridViewShift();

            //Setting
            dataGridViewActivitySetting.RowTemplate.Height = 36;
            GetActivities();


        }

        //textbox only number type tabpage 1
        private void textBoxT5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxApSuatNap_KeyPress(object sender, KeyPressEventArgs e)
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



        // Xu ly data
        //Load setting
        private void LoadSetting()
        {
            Machine machine = MachineBusiness.GetMachine1();
            buttonNameSetting.Text = "Loại bình : " + machine.NameTemplateMachine;
            buttonApSuatNap.Text = "Áp suất nạp : " + machine.ApSuatNap + " bar";
            buttonTheTichNap.Text = "Thể tích nạp : " + machine.TheTichNap + " m3";
            buttonThoiGianNap.Text = "Thời gian nạp : " + machine.ThoiGianNap + " phút";
            buttonThoiGianLayMau.Text = "Thời gian lấy mẫu : " + machine.ThoiGianLayMau + " phút";

            //load combobox select bình
            var listTemplateMachine = TemplateMachineBusiness.GetAllTemplateMachines();
            var listTemplateMachineName = from templateMachine in listTemplateMachine select templateMachine.Name;
            comboBoxSelectTemplateSetting.DataSource = listTemplateMachineName.ToList();
        }

        //Load datagridview setting
        private void LoadDataGridViewSetting(List<Activity> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No.", typeof(int));
            dt.Columns.Add("Hoạt động", typeof(string));
            dt.Columns.Add("Thời gian", typeof(DateTime));
            dt.Columns.Add("Tên người thực hiện");

            // load datagridview từ tham số activities truyền vào
            int count = 1;
            list.ForEach(delegate (Activity activity)
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
                dt.Rows.Add(count, activity.Description, createAt, fullnameButton);
                count++;
            });
            dataGridViewActivitySetting.DataSource = dt;
        }

        // Load Datagridview TemplateSetting
        private void LoadDataGridViewTemplateSetting()
        {
            List<TemplateMachine> list = TemplateMachineBusiness.GetAllTemplateMachines();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã bình");
            dt.Columns.Add("Tên bình");
            dt.Columns.Add("Áp suất nạp (bar)");
            dt.Columns.Add("Thể tích nạp (m3)");
            dt.Columns.Add("Thời gian nạp (phút)");
            dt.Columns.Add("Thời gian lấy mẫu (phút)");
            list.ForEach(delegate (TemplateMachine templateSetting)
            {
                dt.Rows.Add(templateSetting.ID_TemplateMachine, templateSetting.Name, templateSetting.ApSuatNap, templateSetting.TheTichNap, templateSetting.ThoiGianNap, templateSetting.ThoiGianLayMau);
            });
            dataGridViewTemplateSetting.DataSource = dt;
        }

        // load data gridview shift
        private void LoadDataGridViewShift()
        {
            List<Shift> list = ShiftBusiness.GetAllShifts();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Ca");
            dt.Columns.Add("Tên Ca");
            dt.Columns.Add("Thời gian bắt đầu");
            dt.Columns.Add("Thời gian kết thúc");
            list.ForEach(delegate (Shift shift)
            {
                string formatTimeStart = shift.TimeStart.ToString(@"hh\:mm\:ss");
                string formatTimeEnd = shift.TimeEnd.ToString(@"hh\:mm\:ss");

                dt.Rows.Add(shift.ID_Shift, shift.Name, formatTimeStart, formatTimeEnd);
            });
            dataGridViewShift.DataSource = dt;
        }


        // add template setting
        private void buttonAddTemplateSetting_Click(object sender, EventArgs e)
        {
            //check quyền
            if (Common.GROUPSESSION.IsSettingTemplateMachine)
            {
                string Name = textBoxNameTemplateSetting.Texts;
                string ApSuatNap = textBoxApSuatNapTemplateSetting.Texts;
                string TheTichNap = textBoxTheTichNapTemplateSetting.Texts;
                string ThoiGianNap = textBoxThoiGianNapTemplateSetting.Texts;
                string ThoiGianLayMau = textBoxThoiGianLayMauTemplateSetting.Texts;

                if (!String.IsNullOrEmpty(Name) && Name != textBoxNameTemplateSetting.PlaceholderText
                   && !String.IsNullOrEmpty(ApSuatNap) && ApSuatNap != textBoxApSuatNapTemplateSetting.PlaceholderText
                   && !String.IsNullOrEmpty(TheTichNap) && TheTichNap != textBoxTheTichNapTemplateSetting.PlaceholderText
                   && !String.IsNullOrEmpty(ThoiGianNap) && ThoiGianNap != textBoxThoiGianNapTemplateSetting.PlaceholderText
                   && !String.IsNullOrEmpty(ThoiGianLayMau) && ThoiGianLayMau != textBoxThoiGianLayMauTemplateSetting.PlaceholderText)
                {
                    TemplateMachine templateMachine = new TemplateMachine();
                    templateMachine.Name = Name;
                    templateMachine.ApSuatNap = double.Parse(ApSuatNap);
                    templateMachine.TheTichNap = double.Parse(TheTichNap);
                    templateMachine.ThoiGianNap = double.Parse(ThoiGianNap);
                    templateMachine.ThoiGianLayMau = double.Parse(ThoiGianLayMau);
                    try
                    {
                        TemplateMachineBusiness.AddTemplateMachine(templateMachine);
                        callAlert?.Invoke("Thêm thành công.", FormAlert.enmType.Success);
                        LoadDataGridViewTemplateSetting();
                        LoadSetting();
                    }
                    catch
                    {
                        callAlert?.Invoke("Tên này đã tồn tại.", FormAlert.enmType.Error);
                    }
                }
                else
                {
                    callAlert?.Invoke("Các trường thêm không được trống.", FormAlert.enmType.Error);
                }
            }
            else
            {
                callAlert?.Invoke("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }


        }

        //select template setting
        private int ID_TemplateMachine_Selected = 0;
        private void dataGridViewTemplateSetting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridViewTemplateSetting.Rows[rowIndex];

                //id được selected
                ID_TemplateMachine_Selected = int.Parse(row.Cells[0].Value.ToString());

                textBoxNameTemplateSetting.Texts = Convert.ToString(row.Cells[1].Value);
                textBoxApSuatNapTemplateSetting.Texts = Convert.ToString(row.Cells[2].Value);
                textBoxTheTichNapTemplateSetting.Texts = Convert.ToString(row.Cells[3].Value);
                textBoxThoiGianNapTemplateSetting.Texts = Convert.ToString(row.Cells[4].Value);
                textBoxThoiGianLayMauTemplateSetting.Texts = Convert.ToString(row.Cells[5].Value);

                //highlight row
                row.Cells[0].Selected = true;
                row.Cells[1].Selected = true;
                row.Cells[2].Selected = true;
                row.Cells[3].Selected = true;
                row.Cells[4].Selected = true;
                row.Cells[5].Selected = true;

                textBoxNameTemplateSetting.ForeColor = Color.FromArgb(62, 120, 138);
                textBoxApSuatNapTemplateSetting.ForeColor = Color.FromArgb(62, 120, 138);
                textBoxTheTichNapTemplateSetting.ForeColor = Color.FromArgb(62, 120, 138);
                textBoxThoiGianNapTemplateSetting.ForeColor = Color.FromArgb(62, 120, 138);
                textBoxThoiGianLayMauTemplateSetting.ForeColor = Color.FromArgb(62, 120, 138);
            }
        }

        //update template setting
        private void buttonUpdateTemplateSetting_Click(object sender, EventArgs e)
        {
            if (Common.GROUPSESSION.IsSettingTemplateMachine)
            {
                string Name = textBoxNameTemplateSetting.Texts;
                string ApSuatNap = textBoxApSuatNapTemplateSetting.Texts;
                string TheTichNap = textBoxTheTichNapTemplateSetting.Texts;
                string ThoiGianNap = textBoxThoiGianNapTemplateSetting.Texts;
                string ThoiGianLayMau = textBoxThoiGianLayMauTemplateSetting.Texts;

                if (!String.IsNullOrEmpty(Name) && Name != textBoxNameTemplateSetting.PlaceholderText
                   && !String.IsNullOrEmpty(ApSuatNap) && ApSuatNap != textBoxApSuatNapTemplateSetting.PlaceholderText
                   && !String.IsNullOrEmpty(TheTichNap) && TheTichNap != textBoxTheTichNapTemplateSetting.PlaceholderText
                   && !String.IsNullOrEmpty(ThoiGianNap) && ThoiGianNap != textBoxThoiGianNapTemplateSetting.PlaceholderText
                   && !String.IsNullOrEmpty(ThoiGianLayMau) && ThoiGianLayMau != textBoxThoiGianLayMauTemplateSetting.PlaceholderText)
                {
                    if (ID_TemplateMachine_Selected != 0)
                    {
                        try
                        {
                            TemplateMachineBusiness.UpdateTemplateMachine(ID_TemplateMachine_Selected, Name, double.Parse(ApSuatNap),
                             double.Parse(TheTichNap), double.Parse(ThoiGianNap), double.Parse(ThoiGianLayMau));
                            callAlert?.Invoke("Cập nhật thành công.", FormAlert.enmType.Success);
                            LoadDataGridViewTemplateSetting();
                            LoadSetting();
                        }
                        catch
                        {
                            callAlert?.Invoke("Gặp lỗi, không thể cập nhật.", FormAlert.enmType.Error);
                        }
                    }
                    else
                    {
                        callAlert?.Invoke("Hãy chọn một bình để tiến hành cập nhật.", FormAlert.enmType.Info);
                    }
                }
                else
                {
                    callAlert?.Invoke("Các trường cập nhật không được trống.", FormAlert.enmType.Error);
                }
            }
            else
            {
                callAlert?.Invoke("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }

        }

        private void buttonDeleteTemplateSetting_Click(object sender, EventArgs e)
        {

            if (Common.GROUPSESSION.IsSettingTemplateMachine)
            {
                if (ID_TemplateMachine_Selected != 0)
                {
                    try
                    {
                        TemplateMachine templateSetting = TemplateMachineBusiness.GetTemplateMachineFromID(ID_TemplateMachine_Selected);
                        DialogResult dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa bình {templateSetting.Name}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            TemplateMachineBusiness.DeleteTemplateMachine(ID_TemplateMachine_Selected);
                            callAlert?.Invoke("Xóa thành công.", FormAlert.enmType.Success);
                            LoadDataGridViewTemplateSetting();
                            this.ID_TemplateMachine_Selected = 0;
                            textBoxNameTemplateSetting.Texts = null;
                            textBoxApSuatNapTemplateSetting.Texts = null;
                            textBoxTheTichNapTemplateSetting.Texts = null;
                            textBoxThoiGianNapTemplateSetting.Texts = null;
                            textBoxThoiGianLayMauTemplateSetting.Texts = null;
                            LoadSetting();
                        }

                    }
                    catch
                    {
                        callAlert?.Invoke("Gặp lỗi, không thể xóa.", FormAlert.enmType.Error);
                    }
                }
                else
                {
                    callAlert?.Invoke("Hãy chọn một bình trước khi xóa.", FormAlert.enmType.Info);
                }
            }
            else
            {
                callAlert?.Invoke("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }

        }


        //add Shift
        private void buttonAddShift_Click(object sender, EventArgs e)
        {
            if (Common.GROUPSESSION.IsSettingShift)
            {
                string Name = textBoxNameShift.Texts;
                DateTime TimeStart = dateTimePickerTimeStart.Value;
                DateTime TimeEnd = dateTimePickerTimeEnd.Value;


                if (!String.IsNullOrEmpty(Name) && Name != textBoxNameShift.PlaceholderText && dateTimePickerTimeStart.Value != null && dateTimePickerTimeStart.Value != null)
                {
                    Shift shift = new Shift();
                    shift.Name = Name;
                    shift.TimeStart = TimeStart.TimeOfDay;
                    shift.TimeEnd = TimeEnd.TimeOfDay;
                    try
                    {
                        ShiftBusiness.AddShift(shift);
                        callAlert?.Invoke("Thêm thành công.", FormAlert.enmType.Success);
                        LoadDataGridViewShift();
                    }
                    catch
                    {
                        callAlert?.Invoke("Tên ca làm này đã tồn tại.", FormAlert.enmType.Error);
                    }
                }
                else
                {
                    callAlert?.Invoke("Các trường thêm không được trống.", FormAlert.enmType.Error);
                }
            }
            else
            {
                callAlert?.Invoke("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }


        }


        int ID_Shift_Selected = 0;
        //select a item
        private void dataGridViewShift_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0)
            {
                row = dataGridViewShift.Rows[rowIndex];

                //id được selected
                ID_Shift_Selected = int.Parse(row.Cells[0].Value.ToString());

                textBoxNameShift.Texts = Convert.ToString(row.Cells[1].Value);
                dateTimePickerTimeStart.Value = Convert.ToDateTime(row.Cells[2].Value);
                dateTimePickerTimeEnd.Value = Convert.ToDateTime(row.Cells[3].Value);


                //highlight row
                row.Cells[0].Selected = true;
                row.Cells[1].Selected = true;
                row.Cells[2].Selected = true;
                row.Cells[3].Selected = true;

                textBoxNameShift.ForeColor = Color.FromArgb(62, 120, 138);

            }

        }


        //update shift
        private void buttonUpdateShift_Click(object sender, EventArgs e)
        {
            if (Common.GROUPSESSION.IsSettingShift)
            {
                string Name = textBoxNameShift.Texts;
                DateTime TimeStart = dateTimePickerTimeStart.Value;
                DateTime TimeEnd = dateTimePickerTimeEnd.Value;
                if (!String.IsNullOrEmpty(Name) && Name != textBoxNameShift.PlaceholderText && TimeStart != null && TimeEnd != null)
                {
                    if (ID_Shift_Selected != 0)
                    {
                        try
                        {
                            ShiftBusiness.UpdateShift(ID_Shift_Selected, Name, TimeStart.TimeOfDay, TimeEnd.TimeOfDay);
                            callAlert?.Invoke("Cập nhật ca làm thành công.", FormAlert.enmType.Success);
                            LoadDataGridViewShift();
                        }
                        catch
                        {
                            callAlert?.Invoke("Gặp lỗi, không thể cập nhật.", FormAlert.enmType.Error);
                        }
                    }
                    else
                    {
                        callAlert?.Invoke("Hãy chọn một ca làm để tiến hành cập nhật.", FormAlert.enmType.Info);
                    }
                }
                else
                {
                    callAlert?.Invoke("Các trường cập nhật không được trống.", FormAlert.enmType.Error);
                }
            }
            else
            {
                callAlert?.Invoke("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }

        }

        //Xóa ca làm
        private void buttonDeleteShift_Click(object sender, EventArgs e)
        {
            if (Common.GROUPSESSION.IsSettingShift)
            {
                if (this.ID_Shift_Selected != 0)
                {
                    try
                    {
                        Shift shift = ShiftBusiness.GetShiftFromID(ID_Shift_Selected);
                        DialogResult dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa {shift.Name}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            ShiftBusiness.DeleteShift(ID_Shift_Selected);
                            callAlert?.Invoke("Xóa thành công.", FormAlert.enmType.Success);
                            LoadDataGridViewShift();
                            this.ID_Shift_Selected = 0;
                            textBoxNameShift.Texts = null;
                        }

                    }
                    catch
                    {
                        callAlert?.Invoke("Gặp lỗi, không thể xóa.", FormAlert.enmType.Error);
                    }
                }
                else
                {
                    callAlert?.Invoke("Hãy chọn một ca làm trước khi xóa.", FormAlert.enmType.Info);
                }
            }
            else
            {
                callAlert?.Invoke("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }

        }


        //select bình
        private void comboBoxSelectTemplateSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            // lấy ra thông tin user có username là username trên combobox
            TemplateMachine templateSetting = TemplateMachineBusiness.GetTemplateMachineFromName(comboBoxSelectTemplateSetting.Text);

            //show trên textbox

            if (comboBoxSelectTemplateSetting.Text != "Tùy chỉnh")
            {
                textBoxApSuatNap.Texts = templateSetting.ApSuatNap.ToString();
                textBoxTheTichNap.Texts = templateSetting.TheTichNap.ToString();
                textBoxThoiGianNap.Texts = templateSetting.ThoiGianNap.ToString();
                textBoxThoiGianLayMau.Texts = templateSetting.ThoiGianLayMau.ToString();

                textBoxApSuatNap.ForeColor = Color.FromArgb(62, 120, 138);
                textBoxTheTichNap.ForeColor = Color.FromArgb(62, 120, 138);
                textBoxThoiGianNap.ForeColor = Color.FromArgb(62, 120, 138);
                textBoxThoiGianLayMau.ForeColor = Color.FromArgb(62, 120, 138);
            }


        }

        private void buttonSaveSetting_Click(object sender, EventArgs e)
        {
            //check quyền
            if (Common.GROUPSESSION.IsSettingMachine)
            {
                string Name = comboBoxSelectTemplateSetting.Text;
                string ApSuatNap = textBoxApSuatNap.Texts;
                string TheTichNap = textBoxTheTichNap.Texts;
                string ThoiGianNap = textBoxThoiGianNap.Texts;
                string ThoiGianLayMau = textBoxThoiGianLayMau.Texts;

                if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(ApSuatNap) && textBoxApSuatNap.Texts != textBoxApSuatNap.PlaceholderText
                && !String.IsNullOrEmpty(TheTichNap) && textBoxTheTichNap.Texts != textBoxTheTichNap.PlaceholderText
                && !String.IsNullOrEmpty(ThoiGianNap) && textBoxThoiGianNap.Texts != textBoxThoiGianNap.PlaceholderText
                && !String.IsNullOrEmpty(ThoiGianLayMau) && textBoxThoiGianLayMau.Texts != textBoxThoiGianLayMau.PlaceholderText)
                {
                    try
                    {
                        MachineBusiness.UpdateMachine(Name, double.Parse(ApSuatNap), double.Parse(TheTichNap), double.Parse(ThoiGianNap), double.Parse(ThoiGianLayMau));

                        //lưu lại hành động thay đôi cài đặt
                        Activity activity = new Activity();
                        activity.Description = "Cập nhật cài đặt máy";
                        activity.IsSetting = true;
                        activity.Worker = Common.USERSESSION.Username;
                        ActivityBusiness.AddActivity(activity);
                        //load lại datagridview + thông số cài đặt hiện tại
                        LoadSetting();
                        GetActivities();
                        comboBoxSelectTemplateSetting.Text = Name;
                        //aleart
                        callAlert?.Invoke("Cập nhật cài đặt máy thành công.", FormAlert.enmType.Success);

                    }
                    catch
                    {
                        callAlert?.Invoke("Lỗi hệ thống, không thể cập nhật cài đặt.", FormAlert.enmType.Error);
                    }
                }
                else
                {
                    callAlert?.Invoke("Các trường cài đặt không được trống.", FormAlert.enmType.Error);
                }
            }
            else
            {
                callAlert?.Invoke("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }
          
        }





        //pagination 
        private void GetActivities()
        {
            List<Activity> activities = new List<Activity>();
            try
            {
                // đếm tổng số activity
                int sumActivity = ActivityBusiness.CountActivityIsSetting();
                // pagesize bằng tổng số activity chia cho số phần tử mỗi trang
                this.pageSize = (sumActivity / Common.NUMBER_ELM_ON_PAGE_ACTIVITY_IS_SETTING);
                if (sumActivity % Common.NUMBER_ELM_ON_PAGE_ACTIVITY_IS_SETTING != 0)
                {
                    this.pageSize = this.pageSize + 1;
                }
                activities = ActivityBusiness.PaginationActivityIsSetting(page);
            }
            catch
            {
                // Lỗi
                MessageBox.Show("Không thể tải lên lịch sử hoạt động cài đặt.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            LoadDataGridViewSetting(activities);
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
            GetActivities();
        }

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

    }
}
