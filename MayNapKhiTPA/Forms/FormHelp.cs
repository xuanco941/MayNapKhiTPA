using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayNapKhiTPA.Forms
{
    public partial class FormHelp : Form
    {
        public FormHelp()
        {
            InitializeComponent();
            string cur = Directory.GetCurrentDirectory();
            axAcroPDF1.LoadFile("abc.pdf");
            axAcroPDF1.setShowToolbar(false);
            axAcroPDF1.setZoom(90);
            axAcroPDF1.Show();
        }

    }
}
