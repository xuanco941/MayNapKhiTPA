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
            pdfDocumentView1.Load("abc.pdf");
        }

    }
}
