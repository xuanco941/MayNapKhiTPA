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
        string[] x = { "14 giây", "12 giây", "10 giây", "8 giây", "6 giây", "4 giây", "2 giây" };

        double[] yApSuat1 = { 0, 0, 0, 0, 0, 0, 0 };
        double[] yTheTich1 = { 0, 0, 0, 0, 0, 0, 0 };
        double[] yApSuat2 = { 0, 0, 0, 0, 0, 0, 0 };
        double[] yTheTich2 = { 0, 0, 0, 0, 0, 0, 0 };

        //name label
        string labelApSuat = "Áp suất";
        string labelTheTich = "Thể tích";
        public FormDashboard()
        {
            InitializeComponent();

            // tạo các chart rỗng
            double[] y = { 0, 0, 0, 0, 0, 0, 0 };

            CreateChart(zedGraphControlApSuat1, "Biểu Đồ Áp Suất", x, labelApSuat, y);
            CreateChart(zedGraphControlTheTich1, "Biểu Đồ Thể tích", x, labelTheTich, y);
            CreateChart(zedGraphControlApSuat2, "Biểu Đồ Áp Suất", x, labelApSuat, y);
            CreateChart(zedGraphControlTheTich2, "Biểu Đồ Thể tích", x, labelTheTich, y);

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
            LineItem pointsCurve = zedGraphControl.GraphPane.AddCurve(label, null, y, Color.Black);

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

        public double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i<7; i++)
            {
                if (i+1 == 7)
                {
                    yApSuat1[i] = GetRandomNumber(23, 96) -33;
                    yApSuat2[i] = GetRandomNumber(0, 100) +10;
                    yTheTich1[i] = GetRandomNumber(5, 80) + 1;
                    yTheTich2[i] = GetRandomNumber(9, 87) +33;

                    continue;
                }
                else
                {
                    yApSuat1[i] = yApSuat1[i + 1];
                    yApSuat2[i] = yApSuat2[i + 1];
                    yTheTich1[i] = yTheTich1[i + 1];
                    yTheTich2[i] = yTheTich2[i + 1];
                }
            }



            UpdateChart(zedGraphControlApSuat1, labelApSuat, yApSuat1);
            UpdateChart(zedGraphControlApSuat2, labelApSuat, yApSuat2);
            UpdateChart(zedGraphControlTheTich1, labelTheTich, yTheTich1);
            UpdateChart(zedGraphControlTheTich2, labelTheTich, yTheTich2);


        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (Common.GROUPSESSION.IsControlMachine)
            {

            }
            else
            {
                callAlert?.Invoke("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Common.GROUPSESSION.IsControlMachine)
            {

            }
            else
            {
                callAlert?.Invoke("Tài khoản của bạn không có quyền này.", FormAlert.enmType.Info);
            }
        }
    }
}
