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
            dataGridViewActivitySetting.RowTemplate.Height = 35;
            LoadDataGridViewSetting();



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
            Setting setting = SettingBusiness.GetSetting();
            buttonNameSetting.Text = "Loại bình : " + setting.NameTemplateSetting;
            buttonApSuatNap.Text = "Áp suất nạp : " + setting.ApSuatNap + " bar";
            buttonTheTichNap.Text = "Thể tích nạp : " + setting.TheTichNap + " m3";
            buttonThoiGianNap.Text = "Thời gian nạp : " + setting.ThoiGianNap + " phút";
            buttonThoiGianLayMau.Text = "Thời gian lấy mẫu : " + setting.ThoiGianLayMau + " phút";

            //load combobox select bình
            var listTemplateSetting = TemplateSettingBusiness.GetAllTemplateSettings();
            var listNameTemplateSetting = from templateSetting in listTemplateSetting select templateSetting.Name;
            comboBoxSelectTemplateSetting.DataSource = listNameTemplateSetting.ToList();
        }

        //Load datagridview setting
        private void LoadDataGridViewSetting()
        {
            List<Activity> list = ActivityBusiness.GetActivitiesIsSetting();
            DataTable dt = new DataTable();
            dt.Columns.Add("No.", typeof(int));
            dt.Columns.Add("Hoạt động", typeof(string));
            dt.Columns.Add("Thời gian", typeof(DateTime));
            dt.Columns.Add("Tên người thực hiện");

            // load datagridview từ tham số activities truyền vào
            int count = 1;
            list.ForEach(delegate (Activity activity)
            {
                User user = UserBusiness.GetUserFromID(activity.ID_User);
                //format date từ sql -> c#
                string createAt = activity.Create_At.ToString("dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                dt.Rows.Add(count, activity.Description, createAt, user.FullName);
                count++;
            });
            dataGridViewActivitySetting.DataSource = dt;
        }

        // Load Datagridview TemplateSetting
        private void LoadDataGridViewTemplateSetting()
        {
            List<TemplateSetting> list = TemplateSettingBusiness.GetAllTemplateSettings();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã bình");
            dt.Columns.Add("Tên bình");
            dt.Columns.Add("Áp suất nạp (bar)");
            dt.Columns.Add("Thể tích nạp (m3)");
            dt.Columns.Add("Thời gian nạp (phút)");
            dt.Columns.Add("Thời gian lấy mẫu (phút)");
            list.ForEach(delegate (TemplateSetting templateSetting)
            {
                dt.Rows.Add(templateSetting.ID_TemplateSetting, templateSetting.Name, templateSetting.ApSuatNap, templateSetting.TheTichNap, templateSetting.ThoiGianNap, templateSetting.ThoiGianLayMau);
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
                TemplateSetting templateSetting = new TemplateSetting();
                templateSetting.Name = Name;
                templateSetting.ApSuatNap = double.Parse(ApSuatNap);
                templateSetting.TheTichNap = double.Parse(TheTichNap);
                templateSetting.ThoiGianNap = double.Parse(ThoiGianNap);
                templateSetting.ThoiGianLayMau = double.Parse(ThoiGianLayMau);
                try
                {
                    TemplateSettingBusiness.AddTemplateSetting(templateSetting);
                    callAlert?.Invoke("Thêm thành công.", FormAlert.enmType.Success);
                    LoadDataGridViewTemplateSetting();
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

        //select template setting
        private int ID_TemplateSetting_Selected = 0;
        private void dataGridViewTemplateSetting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridViewTemplateSetting.Rows[rowIndex];

                //id được selected
                ID_TemplateSetting_Selected = int.Parse(row.Cells[0].Value.ToString());

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
                if (ID_TemplateSetting_Selected != 0)
                {
                    try
                    {
                        TemplateSettingBusiness.UpdateTemplateSetting(ID_TemplateSetting_Selected, Name, double.Parse(ApSuatNap),
                         double.Parse(TheTichNap), double.Parse(ThoiGianNap), double.Parse(ThoiGianLayMau));
                        callAlert?.Invoke("Cập nhật thành công.", FormAlert.enmType.Success);
                        LoadDataGridViewTemplateSetting();
                    }
                    catch
                    {
                        callAlert?.Invoke("Gặp lỗi, không thể cập nhật.", FormAlert.enmType.Error);
                    }
                }
                else
                {
                    callAlert?.Invoke("Hãy chọn một bình để tiến hành cập nhật.", FormAlert.enmType.Warning);
                }
            }
            else
            {
                callAlert?.Invoke("Các trường cập nhật không được trống.", FormAlert.enmType.Error);
            }
        }

        private void buttonDeleteTemplateSetting_Click(object sender, EventArgs e)
        {
            if (ID_TemplateSetting_Selected != 0)
            {
                try
                {
                    TemplateSetting templateSetting = TemplateSettingBusiness.GetTemplateSettingFromID(ID_TemplateSetting_Selected);
                    DialogResult dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa bình {templateSetting.Name}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        TemplateSettingBusiness.DeleteTemplateSetting(ID_TemplateSetting_Selected);
                        callAlert?.Invoke("Xóa thành công.", FormAlert.enmType.Success);
                        LoadDataGridViewTemplateSetting();
                        this.ID_TemplateSetting_Selected = 0;
                        textBoxNameTemplateSetting.Texts = null;
                        textBoxApSuatNapTemplateSetting.Texts = null;
                        textBoxTheTichNapTemplateSetting.Texts = null;
                        textBoxThoiGianNapTemplateSetting.Texts = null;
                        textBoxThoiGianLayMauTemplateSetting.Texts = null;
                    }

                }
                catch
                {
                    callAlert?.Invoke("Gặp lỗi, không thể xóa.", FormAlert.enmType.Error);
                }
            }
            else
            {
                callAlert?.Invoke("Hãy chọn một bình trước khi xóa.", FormAlert.enmType.Warning);
            }
        }


        //add Shift
        private void buttonAddShift_Click(object sender, EventArgs e)
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
                    callAlert?.Invoke("Hãy chọn một ca làm để tiến hành cập nhật.", FormAlert.enmType.Warning);
                }
            }
            else
            {
                callAlert?.Invoke("Các trường cập nhật không được trống.", FormAlert.enmType.Error);
            }
        }

        //Xóa ca làm
        private void buttonDeleteShift_Click(object sender, EventArgs e)
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
                callAlert?.Invoke("Hãy chọn một ca làm trước khi xóa.", FormAlert.enmType.Warning);
            }
        }
    }
}
