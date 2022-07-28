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




        public FormDashboard()
        {
            InitializeComponent();
            string[] x = { "60 phút", "50 phút", "40 phút", "30 phút", "20 phút", "10 phút", "1 phút" };

            double[] y1 = { 1, 2, 3, 5, 7, 6, 13 };
            double[] y2 = { 4, 1, 3, 6, 7, 8, 5 };
            double[] y3 = { 2, 7, 8, 6, 7, 8, 18 };
            double[] y4 = { 1, 2, 3, 6, 10, 6, 8 };


            UpdateChart(zedGraphControl1,"Biểu Đồ Áp Suất","Áp suất",x,y1);
            UpdateChart(zedGraphControl2, "Biểu Đồ Thể tích", "Thể tích", x, y2);
            UpdateChart(zedGraphControl3, "Biểu Đồ Thể tích", "Thể tích", x, y3);
            UpdateChart(zedGraphControl4, "Biểu Đồ Áp Suất", "Áp suất", x, y4);

        }


        private void UpdateChart(ZedGraphControl zedGraphControl, string title,string label ,string[] x, double[] y)
        {
            //generate pane
            var pane = zedGraphControl.GraphPane;


            pane.XAxis.Scale.IsVisible = true;
            pane.YAxis.Scale.IsVisible = true;

            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;

            pane.XAxis.Scale.TextLabels = x;
            pane.XAxis.Type = AxisType.Text;

            //
            zedGraphControl.GraphPane.XAxis.Title.Text = "Thời gian";
            zedGraphControl.GraphPane.YAxis.Title.Text = "Giá trị đo";

            //var pointsCurve;
            zedGraphControl.GraphPane.Title.Text = title;
            LineItem pointsCurve = pane.AddCurve(label, null, y, Color.Black);
            pointsCurve.Line.IsVisible = true;
            pointsCurve.Line.Width = 1F;
            //Create your own scale of colors.

            pointsCurve.Symbol.Fill = new Fill(new Color[] { Color.Blue, Color.Green, Color.Red });
            pointsCurve.Symbol.Fill.Type = FillType.Solid;
            pointsCurve.Symbol.Type = SymbolType.Circle;
            pointsCurve.Symbol.Border.IsVisible = true;



            pane.AxisChange();
            zedGraphControl.Refresh();
        }



    }
}
