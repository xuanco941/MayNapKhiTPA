using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            // template setting
            dataGridViewTemplateSetting.RowTemplate.Height = 50;
            LoadDataGridViewTemplateSetting();

            //shift
            dataGridViewShift.RowTemplate.Height = 50;
            LoadDataGridViewShift();
        }

        //textbox only number type tabpage 1
        private void textBoxT5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textbox only number 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as LW_PhanMemBaoGia.MyControls.TextBoxT).Texts.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxApSuatNap_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textbox chỉ nhập số  
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // chỉ cho 1 dấu chấm
            if ((e.KeyChar == '.') && ((sender as LW_PhanMemBaoGia.MyControls.TextBoxT).Texts.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }



        // Xu ly data
        // Load Datagridview TemplateSetting
        private void LoadDataGridViewTemplateSetting()
        {
            List<TemplateSetting> list = TemplateSettingBusiness.GetAllTemplateSettings();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã bình");
            dt.Columns.Add("Tên bình");
            dt.Columns.Add("Áp suất nạp");
            dt.Columns.Add("Thể tích nạp");
            dt.Columns.Add("Thời gian nạp");
            dt.Columns.Add("Thời gian lấy mẫu");
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
                dt.Rows.Add(shift.ID_Shift, shift.Name, shift.TimeStart, shift.TimeEnd);
            });
            dataGridViewShift.DataSource = dt;
        }



        private void buttonAddTemplateSetting_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxNameTemplateSetting.Texts) && textBoxNameTemplateSetting.Texts != textBoxNameTemplateSetting.PlaceholderText
                && !String.IsNullOrEmpty(textBoxApSuatNapTemplateSetting.Texts) && textBoxApSuatNapTemplateSetting.Texts != textBoxApSuatNapTemplateSetting.PlaceholderText
                && !String.IsNullOrEmpty(textBoxTheTichNapTemplateSetting.Texts) && textBoxTheTichNapTemplateSetting.Texts != textBoxTheTichNapTemplateSetting.PlaceholderText
                && !String.IsNullOrEmpty(textBoxThoiGianNapTemplateSetting.Texts) && textBoxThoiGianNapTemplateSetting.Texts != textBoxThoiGianNapTemplateSetting.PlaceholderText
                && !String.IsNullOrEmpty(textBoxThoiGianLayMauTemplateSetting.Texts) && textBoxThoiGianLayMauTemplateSetting.Texts != textBoxThoiGianLayMauTemplateSetting.PlaceholderText)
            {
                TemplateSetting templateSetting = new TemplateSetting();
                templateSetting.Name = textBoxNameTemplateSetting.Texts;
                templateSetting.ApSuatNap = double.Parse(textBoxApSuatNapTemplateSetting.Texts);
                templateSetting.TheTichNap = double.Parse(textBoxTheTichNapTemplateSetting.Texts);
                templateSetting.ThoiGianNap = double.Parse(textBoxThoiGianNapTemplateSetting.Texts);
                templateSetting.ThoiGianLayMau = double.Parse(textBoxThoiGianLayMauTemplateSetting.Texts);
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
                callAlert?.Invoke("Dữ liệu thêm không được trống.", FormAlert.enmType.Error);
            }

        }


        private void dataGridViewTemplateSetting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridViewTemplateSetting.Rows[e.RowIndex];
            textBoxNameTemplateSetting.Texts = Convert.ToString(row.Cells[1].Value);
            textBoxApSuatNapTemplateSetting.Texts = Convert.ToString(row.Cells[2].Value);
            textBoxTheTichNapTemplateSetting.Texts = Convert.ToString(row.Cells[3].Value);
            textBoxThoiGianNapTemplateSetting.Texts = Convert.ToString(row.Cells[4].Value);
            textBoxThoiGianLayMauTemplateSetting.Texts = Convert.ToString(row.Cells[5].Value);

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
}
