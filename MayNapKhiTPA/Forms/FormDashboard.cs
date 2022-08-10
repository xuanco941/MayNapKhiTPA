using MayNapKhiTPA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
namespace MayNapKhiTPA.Forms
{
    public partial class FormDashboard : Form
    {
        //ALEART
        // Define delegate
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        // Create instance (null)
        public CallAlert callAlert;

        //x
        string[] x = { "60 giây", "50 giây", "40 giây", "30 giây", "20 giây", "10 giây", "1 giây" };

        //name label
        string labelApSuat = "Áp suất";
        string labelTheTich = "Thể tích";
        public FormDashboard()
        {
            InitializeComponent();

            CreateChart(zedGraphControlApSuat1, "Biểu Đồ Áp Suất", x, labelApSuat, Common.chartDataApSuatMachine1);
            CreateChart(zedGraphControlTheTich1, "Biểu Đồ Thể tích", x, labelTheTich, Common.chartDataTheTichMachine1);
            CreateChart(zedGraphControlApSuat2, "Biểu Đồ Áp Suất", x, labelApSuat, Common.chartDataApSuatMachine2);
            CreateChart(zedGraphControlTheTich2, "Biểu Đồ Thể tích", x, labelTheTich, Common.chartDataTheTichMachine2);


            //check btn start, end
            if (Common.IsMachine1Running == true)
            {
                buttonStartMachine1.Enabled = false;
            }
            else
            {
                buttonStartMachine1.Enabled = true;
            }

            if (Common.IsMachine2Running == true)
            {
                buttonStartMachine2.Enabled = false;
            }
            else
            {
                buttonStartMachine2.Enabled = true;
            }
            //start timer
            timer1.Start();

        }


        private void CreateChart(ZedGraphControl zedGraphControl, string title, string[] x, string label, double[] y)
        {
            //generate pane

            zedGraphControl.GraphPane.XAxis.Scale.IsVisible = true;
            zedGraphControl.GraphPane.YAxis.Scale.IsVisible = true;

            zedGraphControl.GraphPane.XAxis.MajorGrid.IsVisible = true;
            zedGraphControl.GraphPane.YAxis.MajorGrid.IsVisible = true;

            zedGraphControl.GraphPane.XAxis.Scale.TextLabels = x;
            zedGraphControl.GraphPane.XAxis.Type = AxisType.Text;

            //
            zedGraphControl.GraphPane.XAxis.Title.Text = "Thời gian";
            zedGraphControl.GraphPane.YAxis.Title.Text = "Giá trị đo";

            //var pointsCurve;
            zedGraphControl.GraphPane.Title.Text = title;

            // thêm 1 line không có dữ liệu
            zedGraphControl.GraphPane.AddCurve(label, null, y, Color.Black);

            zedGraphControl.GraphPane.AxisChange();
            zedGraphControl.Refresh();

        }
        private void UpdateChart(ZedGraphControl zedGraphControl, string label, double[] y)
        {
            zedGraphControl.GraphPane.CurveList.Clear();
            Color color;
            if (label == labelApSuat)
            {
                color = Color.DarkOrange;
            }
            else
            {
                color = Color.MediumSeaGreen;
            }
            LineItem pointsCurve = zedGraphControl.GraphPane.AddCurve(label, null, y, color);

            pointsCurve.Line.IsVisible = true;
            pointsCurve.Line.Width = 2;
            //Create your own scale of colors.

            pointsCurve.Symbol.Fill = new Fill(new Color[] { Color.Blue, Color.Green, Color.DarkBlue });
            pointsCurve.Symbol.Fill.Type = FillType.Solid;
            pointsCurve.Symbol.Type = SymbolType.Diamond;
            pointsCurve.Symbol.Border.IsVisible = true;

            zedGraphControl.GraphPane.AxisChange();
            zedGraphControl.Refresh();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateChart(zedGraphControlApSuat1, labelApSuat, Common.chartDataApSuatMachine1);
            UpdateChart(zedGraphControlTheTich1, labelTheTich, Common.chartDataTheTichMachine1);
            UpdateChart(zedGraphControlApSuat2, labelApSuat, Common.chartDataApSuatMachine2);
            UpdateChart(zedGraphControlTheTich2, labelTheTich, Common.chartDataTheTichMachine2);
        }

        private void buttonStartMachine1_Click(object sender, EventArgs e)
        {
            if (Common.GROUPSESSION.IsControlMachine)
            {
                try
                {
                    //Machine 1 is running
                    Common.IsMachine1Running = true;
                    //thêm result rỗng và lấy id result đó cho biến data 1
                    Common.dataMachine1.ID_Result = ResultBusiness.AddResultAndReturnIDResult("Máy 1", Common.USERSESSION.Username);
                    //bắt đầu lưu dữ liệu 10s/1lần
                    Common.timer.RunTimerMachine1();
                    //disabled nút start cho đến khi ấn ngừng nạp
                    buttonStartMachine1.Enabled = false;
                    callAlert.Invoke("Máy 1 đã bắt đầu nạp.", FormAlert.enmType.Success);
                }
                catch
                {
                    callAlert.Invoke("Có lỗi xảy ra khi khởi chạy máy 1.", FormAlert.enmType.Error);
                }
            }
            else
            {
                callAlert?.Invoke("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }
        }

        private void buttonStopMachine1_Click(object sender, EventArgs e)
        {
            if (Common.GROUPSESSION.IsControlMachine)
            {

                if (Common.IsMachine1Running == true)
                {
                    //update
                    ResultBusiness.UpdateResult(Common.dataMachine1.ID_Result);
                    //Stop timer machine 1
                    Common.timer.ClearTimeMachine1();

                    //
                    Common.IsMachine1Running = false;
                    buttonStartMachine1.Enabled = true;

                    //
                    callAlert?.Invoke("Đã ngừng nạp máy 1.", FormAlert.enmType.Success);

                }
            }
            else
            {
                callAlert?.Invoke("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }
        }

        private void buttonStartMachine2_Click(object sender, EventArgs e)
        {
            if (Common.GROUPSESSION.IsControlMachine)
            {
                try
                {
                    //Machine 1 is running
                    Common.IsMachine2Running = true;
                    //thêm result rỗng và lấy id result đó cho biến data 1
                    Common.dataMachine2.ID_Result = ResultBusiness.AddResultAndReturnIDResult("Máy 2", Common.USERSESSION.Username);
                    //Start timer2 save data
                    Common.timer.RunTimerMachine2();

                    //disabled nút start cho đến khi ấn ngừng nạp
                    buttonStartMachine2.Enabled = false;
                    callAlert.Invoke("Máy 2 đã bắt đầu nạp.", FormAlert.enmType.Success);
                }
                catch
                {
                    callAlert.Invoke("Có lỗi xảy ra khi khởi chạy máy 2.", FormAlert.enmType.Error);
                }
                timer1.Start();
            }
            else
            {
                callAlert?.Invoke("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }
        }

        private void buttonStopMachine2_Click(object sender, EventArgs e)
        {
            if (Common.GROUPSESSION.IsControlMachine)
            {
                if (Common.IsMachine2Running == true)
                {
                    //update
                    ResultBusiness.UpdateResult(Common.dataMachine2.ID_Result);
                    //delete timer
                    Common.timer.ClearTimeMachine2();

                    //
                    buttonStartMachine2.Enabled = true;
                    Common.IsMachine2Running = false;

                    //
                    callAlert?.Invoke("Đã ngừng nạp máy 2.", FormAlert.enmType.Success);
                }

            }
            else
            {
                callAlert?.Invoke("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }
        }
    }
}
