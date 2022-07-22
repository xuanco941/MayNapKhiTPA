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

            // generate some fake data
            double[] y = { 1, 2, 3, 4, 5, 7, 6, 9, 13 };
            string[] schools = { "A", "B", "C", "D", "E", "F", "G", "H", "J" };

            //generate pane
            var pane = zedGraphControl1.GraphPane;


            pane.XAxis.Scale.IsVisible = true;
            pane.YAxis.Scale.IsVisible = true;

            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;

            pane.XAxis.Scale.TextLabels = schools;
            pane.XAxis.Type = AxisType.Text;

            //
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Thời gian";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Đơn vị đo";

            //var pointsCurve;
            zedGraphControl1.GraphPane.Title.Text = "Biểu đồ đo áp suất";
            LineItem pointsCurve = pane.AddCurve("Áp suất", null, y, Color.Black);
            pointsCurve.Line.IsVisible = true;
            pointsCurve.Line.Width = 3.0F;
            //Create your own scale of colors.

            pointsCurve.Symbol.Fill = new Fill(new Color[] { Color.Blue, Color.Green, Color.Red });
            pointsCurve.Symbol.Fill.Type = FillType.Solid;
            pointsCurve.Symbol.Type = SymbolType.Circle;
            pointsCurve.Symbol.Border.IsVisible = true;



            pane.AxisChange();
            zedGraphControl1.Refresh();
        }

    }
}
