using MayNapKhiTPA.Library;
using MayNapKhiTPA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

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
        private string time1 = null;
        private string time2 = null;
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
            buttonExcel.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Bold);

            buttonPrint.ForeColor = Color.Black;
            buttonPrint.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Bold);

            dataGridViewResult.RowTemplate.Height = 45;


            try
            {
                LoadComboBox();
            }
            catch
            {
                //Lỗi tải danh sách mẻ nạp
                MessageBox.Show("Không thể tải lên dữ liệu của danh sách các máy.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                GetResults();
            }
            catch
            {
                //Lỗi tải danh sách mẻ nạp
                MessageBox.Show("Không thể tải lên dữ liệu các mẻ nạp.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            System.Data.DataTable dt = new System.Data.DataTable();
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
            //--Không chọn tên Machine, không chọn ngày, không chọn chỉ số
            if (this.nameMachine == allMachine && this.time1 == null && this.checkApSuat == false && this.checkTheTich == false && this.checkLuuLuong == false)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_NoName_NoDate_NoParameter());
                listResults = PaginationResult.Pagination_NoName_NoDate_NoParameter(this.page, Common.NUMBER_ELM_ON_PAGE_RESULT);
            }
            //--Chọn tên, chọn ngày, chọn chỉ số (3 chỉ số) (NAME_DATE_PARAMETER)
            else if (this.nameMachine != allMachine && this.time1 != null && this.checkApSuat != false && this.checkTheTich != false && this.checkLuuLuong != false)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_YesName_YesDate_YesParameter_ApSuat_TheTich_LuuLuong(nameMachine, time1, time2, apSuat1, apSuat2, theTich1, theTich2, luuLuong1, luuLuong2));
                listResults = PaginationResult.Pagination_YesName_YesDate_YesParameter_ApSuat_TheTich_LuuLuong(page, Common.NUMBER_ELM_ON_PAGE_RESULT, nameMachine, time1, time2, apSuat1, apSuat2, theTich1, theTich2, luuLuong1, luuLuong2);
            }
            //--Chọn tên Machine,có chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Thể tích)
            else if (this.nameMachine != allMachine && this.time1 != null && this.checkApSuat != false && this.checkTheTich != false && this.checkLuuLuong != true)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_YesName_YesDate_YesParameter_ApSuat_TheTich(nameMachine, time1, time2, apSuat1, apSuat2, theTich1, theTich2));
                listResults = PaginationResult.Pagination_YesName_YesDate_YesParameter_ApSuat_TheTich(page, Common.NUMBER_ELM_ON_PAGE_RESULT, nameMachine, time1, time2, apSuat1, apSuat2, theTich1, theTich2);
            }
            //--Có chọn tên Machine, có chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Lưu Lượng)
            else if (this.nameMachine != allMachine && this.time1 != null && this.checkApSuat != false && this.checkTheTich != true && this.checkLuuLuong != false)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_YesName_YesDate_YesParameter_ApSuat_LuuLuong(nameMachine, time1, time2, apSuat1, apSuat2, luuLuong1, luuLuong2));
                listResults = PaginationResult.Pagination_YesName_YesDate_YesParameter_ApSuat_LuuLuong(page, Common.NUMBER_ELM_ON_PAGE_RESULT, nameMachine, time1, time2, apSuat1, apSuat2, luuLuong1, luuLuong2);
            }
            //--Có chọn tên Machine, có chọn ngày, có chọn chỉ số (2 chỉ số (thể tích - lưu lượng))
            else if (this.nameMachine != allMachine && this.time1 != null && this.checkApSuat != true && this.checkTheTich != false && this.checkLuuLuong != false)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_YesName_YesDate_YesParameter_TheTich_LuuLuong(nameMachine, time1, time2, theTich1, theTich2, luuLuong1, luuLuong2));
                listResults = PaginationResult.Pagination_YesName_YesDate_YesParameter_TheTich_LuuLuong(page, Common.NUMBER_ELM_ON_PAGE_RESULT, nameMachine, time1, time2, theTich1, theTich2, luuLuong1, luuLuong2);
            }
            //--Có chọn tên Machine, có chọn ngày, có chọn chỉ số (1 thể tích)
            else if (this.nameMachine != allMachine && this.time1 != null && this.checkApSuat != true && this.checkTheTich != false && this.checkLuuLuong != true)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_YesName_YesDate_YesParameter_TheTich(nameMachine, time1, time2, theTich1, theTich2));
                listResults = PaginationResult.Pagination_YesName_YesDate_YesParameter_TheTich(page, Common.NUMBER_ELM_ON_PAGE_RESULT, nameMachine, time1, time2, theTich1, theTich2);
            }
            //--Có chọn tên Machine, có chọn ngày, có chọn chỉ số (1 - lưu lượng)
            else if (this.nameMachine != allMachine && this.time1 != null && this.checkApSuat != true && this.checkTheTich != true && this.checkLuuLuong != false)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_YesName_YesDate_YesParameter_LuuLuong(nameMachine, time1, time2, luuLuong1, luuLuong2));
                listResults = PaginationResult.Pagination_YesName_YesDate_YesParameter_LuuLuong(page, Common.NUMBER_ELM_ON_PAGE_RESULT, nameMachine, time1, time2, luuLuong1, luuLuong2);
            }
            //--Có chọn tên Machine, có chọn ngày, có chọn chỉ số (1 chỉ số - Áp suất)
            else if (this.nameMachine != allMachine && this.time1 != null && this.checkApSuat != false && this.checkTheTich != true && this.checkLuuLuong != true)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_YesName_YesDate_YesParameter_ApSuat(nameMachine, time1, time2, apSuat1, apSuat2));
                listResults = PaginationResult.Pagination_YesName_YesDate_YesParameter_ApSuat(page, Common.NUMBER_ELM_ON_PAGE_RESULT, nameMachine, time1, time2, apSuat1, apSuat2);
            }
            //--Không chọn tên Machine, có chọn ngày, không chọn chỉ số (DATE)
            else if (this.nameMachine == allMachine && this.time1 != null && this.checkApSuat != true && this.checkTheTich != true && this.checkLuuLuong != true)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_NoName_YesDate_NoParameter(time1, time2));
                listResults = PaginationResult.Pagination_NoName_YesDate_NoParameter(page, Common.NUMBER_ELM_ON_PAGE_RESULT, time1, time2);
            }
            //--Chọn tên Machine, không chọn ngày, không chọn chỉ số(NAME)
            else if (this.nameMachine != allMachine && this.time1 == null && this.checkApSuat != true && this.checkTheTich != true && this.checkLuuLuong != true)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_YesName_NoDate_NoParameter(nameMachine));
                listResults = PaginationResult.Pagination_YesName_NoDate_NoParameter(page, Common.NUMBER_ELM_ON_PAGE_RESULT, nameMachine);
            }
            //--Không chọn tên Machine, không chọn ngày, có chọn chỉ số(3 chỉ số) 
            else if (this.nameMachine == allMachine && this.time1 == null && this.checkApSuat != false && this.checkTheTich != false && this.checkLuuLuong != false)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_NoName_NoDate_YesParameter_ApSuat_TheTich_LuuLuong(apSuat1, apSuat2, theTich1, theTich2, luuLuong1, luuLuong2));
                listResults = PaginationResult.Pagination_NoName_NoDate_YesParameter_ApSuat_TheTich_LuuLuong(page, Common.NUMBER_ELM_ON_PAGE_RESULT, apSuat1, apSuat2, theTich1, theTich2, luuLuong1, luuLuong2);
            }
            //--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Thể tích)
            else if (this.nameMachine == allMachine && this.time1 == null && this.checkApSuat != false && this.checkTheTich != false && this.checkLuuLuong != true)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_NoName_NoDate_YesParameter_ApSuat_TheTich(apSuat1, apSuat2, theTich1, theTich2));
                listResults = PaginationResult.Pagination_NoName_NoDate_YesParameter_ApSuat_TheTich(page, Common.NUMBER_ELM_ON_PAGE_RESULT, apSuat1, apSuat2, theTich1, theTich2);
            }
            //--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Lưu Lượng)
            else if (this.nameMachine == allMachine && this.time1 == null && this.checkApSuat != false && this.checkTheTich != true && this.checkLuuLuong != false)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_NoName_NoDate_YesParameter_ApSuat_LuuLuong(apSuat1, apSuat2, luuLuong1, luuLuong2));
                listResults = PaginationResult.Pagination_NoName_NoDate_YesParameter_ApSuat_LuuLuong(page, Common.NUMBER_ELM_ON_PAGE_RESULT, apSuat1, apSuat2, luuLuong1, luuLuong2);
            }
            //--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (2 chỉ số (thể tích - lưu lượng))
            else if (this.nameMachine == allMachine && this.time1 == null && this.checkApSuat != true && this.checkTheTich != false && this.checkLuuLuong != false)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_NoName_NoDate_YesParameter_TheTich_LuuLuong(theTich1, theTich2, luuLuong1, luuLuong2));
                listResults = PaginationResult.Pagination_NoName_NoDate_YesParameter_TheTich_LuuLuong(page, Common.NUMBER_ELM_ON_PAGE_RESULT, theTich1, theTich2, luuLuong1, luuLuong2);
            }
            //--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (1 thể tích)
            else if (this.nameMachine == allMachine && this.time1 == null && this.checkApSuat != true && this.checkTheTich != false && this.checkLuuLuong != true)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_NoName_NoDate_YesParameter_TheTich(theTich1, theTich2));
                listResults = PaginationResult.Pagination_NoName_NoDate_YesParameter_TheTich(page, Common.NUMBER_ELM_ON_PAGE_RESULT, theTich1, theTich2);
            }
            //--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (1 - lưu lượng)
            else if (this.nameMachine == allMachine && this.time1 == null && this.checkApSuat != true && this.checkTheTich != true && this.checkLuuLuong != false)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_NoName_NoDate_YesParameter_LuuLuong(luuLuong1, luuLuong2));
                listResults = PaginationResult.Pagination_NoName_NoDate_YesParameter_LuuLuong(page, Common.NUMBER_ELM_ON_PAGE_RESULT, luuLuong1, luuLuong2);
            }
            //--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (1 chỉ số - Áp suất)
            else if (this.nameMachine == allMachine && this.time1 == null && this.checkApSuat != false && this.checkTheTich != true && this.checkLuuLuong != true)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_NoName_NoDate_YesParameter_ApSuat(apSuat1, apSuat2));
                listResults = PaginationResult.Pagination_NoName_NoDate_YesParameter_ApSuat(page, Common.NUMBER_ELM_ON_PAGE_RESULT, apSuat1, apSuat2);
            }
            //--Chọn tên, chọn ngày, không chọn chỉ số (NAME_DATE)
            else if (this.nameMachine != allMachine && this.time1 != null && this.checkApSuat != true && this.checkTheTich != true && this.checkLuuLuong != true)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_YesName_YesDate_NoParameter(nameMachine, time1, time2));
                listResults = PaginationResult.Pagination_YesName_YesDate_NoParameter(page, Common.NUMBER_ELM_ON_PAGE_RESULT, nameMachine, time1, time2);
            }
            //--Chọn tên, không chọn ngày, chọn chỉ số (3 chỉ số) (NAME_DATE_PARAMETER)
            else if (this.nameMachine != allMachine && this.time1 == null && this.checkApSuat != false && this.checkTheTich != false && this.checkLuuLuong != false)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_YesName_NoDate_YesParameter_ApSuat_TheTich_LuuLuong(nameMachine, apSuat1, apSuat2, theTich1, theTich2, luuLuong1, luuLuong2));
                listResults = PaginationResult.Pagination_YesName_NoDate_YesParameter_ApSuat_TheTich_LuuLuong(page, Common.NUMBER_ELM_ON_PAGE_RESULT, nameMachine, apSuat1, apSuat2, theTich1, theTich2, luuLuong1, luuLuong2);
            }
            //--Chọn tên Machine,không chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Thể tích)
            else if (this.nameMachine != allMachine && this.time1 == null && this.checkApSuat != false && this.checkTheTich != false && this.checkLuuLuong != true)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_YesName_NoDate_YesParameter_ApSuat_TheTich(nameMachine, apSuat1, apSuat2, theTich1, theTich2));
                listResults = PaginationResult.Pagination_YesName_NoDate_YesParameter_ApSuat_TheTich(page, Common.NUMBER_ELM_ON_PAGE_RESULT, nameMachine, apSuat1, apSuat2, theTich1, theTich2);
            }
            //--Có chọn tên Machine, không chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Lưu Lượng)
            else if (this.nameMachine != allMachine && this.time1 == null && this.checkApSuat != false && this.checkTheTich != true && this.checkLuuLuong != false)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_YesName_NoDate_YesParameter_ApSuat_LuuLuong(nameMachine, apSuat1, apSuat2, luuLuong1, luuLuong2));
                listResults = PaginationResult.Pagination_YesName_NoDate_YesParameter_ApSuat_LuuLuong(page, Common.NUMBER_ELM_ON_PAGE_RESULT, nameMachine, apSuat1, apSuat2, luuLuong1, luuLuong2);
            }
            //--Có chọn tên Machine, không chọn ngày, có chọn chỉ số (2 chỉ số (thể tích - lưu lượng))
            else if (this.nameMachine != allMachine && this.time1 == null && this.checkApSuat != true && this.checkTheTich != false && this.checkLuuLuong != false)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_YesName_NoDate_YesParameter_TheTich_LuuLuong(nameMachine, theTich1, theTich2, luuLuong1, luuLuong2));
                listResults = PaginationResult.Pagination_YesName_NoDate_YesParameter_TheTich_LuuLuong(page, Common.NUMBER_ELM_ON_PAGE_RESULT, nameMachine, theTich1, theTich2, luuLuong1, luuLuong2);
            }
            //--Có chọn tên Machine, không chọn ngày, có chọn chỉ số (1 thể tích)
            else if (this.nameMachine != allMachine && this.time1 == null && this.checkApSuat != true && this.checkTheTich != false && this.checkLuuLuong != true)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_YesName_NoDate_YesParameter_TheTich(nameMachine, theTich1, theTich2));
                listResults = PaginationResult.Pagination_YesName_NoDate_YesParameter_TheTich(page, Common.NUMBER_ELM_ON_PAGE_RESULT, nameMachine, theTich1, theTich2);
            }
            //--Có chọn tên Machine, không chọn ngày, có chọn chỉ số (1 - lưu lượng)
            else if (this.nameMachine != allMachine && this.time1 == null && this.checkApSuat != true && this.checkTheTich != true && this.checkLuuLuong != false)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_YesName_NoDate_YesParameter_LuuLuong(nameMachine, luuLuong1, luuLuong2));
                listResults = PaginationResult.Pagination_YesName_NoDate_YesParameter_LuuLuong(page, Common.NUMBER_ELM_ON_PAGE_RESULT, nameMachine, luuLuong1, luuLuong2);
            }
            //--Có chọn tên Machine, có chọn ngày, có chọn chỉ số (1 chỉ số - Áp suất)
            else if (this.nameMachine != allMachine && this.time1 == null && this.checkApSuat != false && this.checkTheTich != true && this.checkLuuLuong != true)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_YesName_NoDate_YesParameter_ApSuat(nameMachine, apSuat1, apSuat2));
                listResults = PaginationResult.Pagination_YesName_NoDate_YesParameter_ApSuat(page, Common.NUMBER_ELM_ON_PAGE_RESULT, nameMachine, apSuat1, apSuat2);
            }
            //--không chọn tên, chọn ngày, chọn chỉ số (3 chỉ số) (NAME_DATE_PARAMETER)
            else if (this.nameMachine == allMachine && this.time1 != null && this.checkApSuat != false && this.checkTheTich != false && this.checkLuuLuong != false)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_NoName_YesDate_YesParameter_ApSuat_TheTich_LuuLuong(time1, time2, apSuat1, apSuat2, theTich1, theTich2, luuLuong1, luuLuong2));
                listResults = PaginationResult.Pagination_NoName_YesDate_YesParameter_ApSuat_TheTich_LuuLuong(page, Common.NUMBER_ELM_ON_PAGE_RESULT, time1, time2, apSuat1, apSuat2, theTich1, theTich2, luuLuong1, luuLuong2);
            }
            //--Không chọn tên Machine,có chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Thể tích)
            else if (this.nameMachine == allMachine && this.time1 != null && this.checkApSuat != false && this.checkTheTich != false && this.checkLuuLuong != true)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_NoName_YesDate_YesParameter_ApSuat_TheTich(time1, time2, apSuat1, apSuat2, theTich1, theTich2));
                listResults = PaginationResult.Pagination_NoName_YesDate_YesParameter_ApSuat_TheTich(page, Common.NUMBER_ELM_ON_PAGE_RESULT, time1, time2, apSuat1, apSuat2, theTich1, theTich2);
            }
            //--Không chọn tên Machine, có chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Lưu Lượng)
            else if (this.nameMachine == allMachine && this.time1 != null && this.checkApSuat != false && this.checkTheTich != true && this.checkLuuLuong != false)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_NoName_YesDate_YesParameter_ApSuat_LuuLuong(time1, time2, apSuat1, apSuat2, luuLuong1, luuLuong2));
                listResults = PaginationResult.Pagination_NoName_YesDate_YesParameter_ApSuat_LuuLuong(page, Common.NUMBER_ELM_ON_PAGE_RESULT, time1, time2, apSuat1, apSuat2, luuLuong1, luuLuong2);
            }
            //--Không chọn tên Machine, có chọn ngày, có chọn chỉ số (2 chỉ số (thể tích - lưu lượng))
            else if (this.nameMachine == allMachine && this.time1 != null && this.checkApSuat != true && this.checkTheTich != false && this.checkLuuLuong != false)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_NoName_YesDate_YesParameter_TheTich_LuuLuong(time1, time2, theTich1, theTich2, luuLuong1, luuLuong2));
                listResults = PaginationResult.Pagination_NoName_YesDate_YesParameter_TheTich_LuuLuong(page, Common.NUMBER_ELM_ON_PAGE_RESULT, time1, time2, theTich1, theTich2, luuLuong1, luuLuong2);
            }
            //--Không chọn tên Machine, có chọn ngày, có chọn chỉ số (1 thể tích)
            else if (this.nameMachine == allMachine && this.time1 != null && this.checkApSuat != true && this.checkTheTich != false && this.checkLuuLuong != true)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_NoName_YesDate_YesParameter_TheTich(time1, time2, theTich1, theTich2));
                listResults = PaginationResult.Pagination_NoName_YesDate_YesParameter_TheTich(page, Common.NUMBER_ELM_ON_PAGE_RESULT, time1, time2, theTich1, theTich2);
            }
            //--Không chọn tên Machine, có chọn ngày, có chọn chỉ số (1 - lưu lượng)
            else if (this.nameMachine == allMachine && this.time1 != null && this.checkApSuat != true && this.checkTheTich != true && this.checkLuuLuong != false)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_NoName_YesDate_YesParameter_LuuLuong(time1, time2, luuLuong1, luuLuong2));
                listResults = PaginationResult.Pagination_NoName_YesDate_YesParameter_LuuLuong(page, Common.NUMBER_ELM_ON_PAGE_RESULT, time1, time2, luuLuong1, luuLuong2);
            }
            //--Không chọn tên Machine, có chọn ngày, có chọn chỉ số (1 chỉ số - Áp suất)
            else if (this.nameMachine == allMachine && this.time1 != null && this.checkApSuat != false && this.checkTheTich != true && this.checkLuuLuong != true)
            {
                ChangePageSizeFromSumResult(PaginationResult.Count_NoName_YesDate_YesParameter_ApSuat(time1, time2, apSuat1, apSuat2));
                listResults = PaginationResult.Pagination_NoName_YesDate_YesParameter_ApSuat(page, Common.NUMBER_ELM_ON_PAGE_RESULT, time1, time2, apSuat1, apSuat2);
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
            time1 = tuNgay.Year + "-" + tuNgay.Month + "-" + tuNgay.Day;
            time2 = toiNgay.Year + "-" + toiNgay.Month + "-" + toiNgay.Day;

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

            try
            {
                GetResults();
            }
            catch
            {
                //Lỗi tải danh sách mẻ nạp
                MessageBox.Show("Không thể tải lên dữ liệu", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;

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
            try
            {
                GetResults();
            }
            catch
            {
                //Lỗi tải danh sách mẻ nạp
                MessageBox.Show("Không thể tải lên dữ liệu", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                try
                {
                    GetResults();
                }
                catch
                {
                    //Lỗi tải danh sách mẻ nạp
                    MessageBox.Show("Không thể tải lên dữ liệu", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //public DataGridView CloneDataGrid(DataGridView mainDataGridView)
        //{
        //    DataGridView cloneDataGridView = new DataGridView();

        //    if (cloneDataGridView.Columns.Count == 0)
        //    {
        //        foreach (DataGridViewColumn datagrid in mainDataGridView.Columns)
        //        {
        //            cloneDataGridView.Columns.Add(datagrid.Clone() as DataGridViewColumn);
        //        }
        //    }

        //    DataGridViewRow dataRow = new DataGridViewRow();

        //    for (int i = 0; i < mainDataGridView.Rows.Count; i++)
        //    {
        //        dataRow = (DataGridViewRow)mainDataGridView.Rows[i].Clone();
        //        int Index = 0;
        //        foreach (DataGridViewCell cell in mainDataGridView.Rows[i].Cells)
        //        {
        //            dataRow.Cells[Index].Value = cell.Value;
        //            Index++;
        //        }
        //        cloneDataGridView.Rows.Add(dataRow);
        //    }
        //    cloneDataGridView.AllowUserToAddRows = false;
        //    cloneDataGridView.Refresh();


        //    return cloneDataGridView;
        //}
        private void buttonPrint_Click(object sender, EventArgs e)
        {

            DGVPrinter printer = new DGVPrinter();

            printer.Title = "TPA - Total Automation Solutions";

            printer.SubTitle = "("+DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)+")";

            printer.TitleSpacing = 5;

            printer.SubTitleSpacing = 30;

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;

            printer.PageNumbers = true;

            printer.PageNumberInHeader = false;

            printer.PorportionalColumns = true;

            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.Footer = "TPA";

            printer.FooterSpacing = 15;


            PrinterSettings ps = new PrinterSettings();
            PrintDocument recordDoc = new PrintDocument();
            recordDoc.PrinterSettings = ps;
            IEnumerable<PaperSize> paperSizes = ps.PaperSizes.Cast<PaperSize>();
            PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A4); // setting paper size to A4 size
            recordDoc.DefaultPageSettings.PaperSize = sizeA4;
            printer.printDocument.DefaultPageSettings.PaperSize = sizeA4;


            printer.PrintDataGridView(dataGridViewResult);
        }


        //Excel
       
        private void buttonExcel_Click(object sender, EventArgs e)
        {
            if (dataGridViewResult.Rows.Count > 0)
            {
                Excel.Application XcelApp = new Excel.Application();

                XcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridViewResult.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dataGridViewResult.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridViewResult.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewResult.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dataGridViewResult.Rows[i].Cells[j].Value.ToString();
                        XcelApp.Cells[i+2,j+1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    }
                }
                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;
            }
        }


    }
}
