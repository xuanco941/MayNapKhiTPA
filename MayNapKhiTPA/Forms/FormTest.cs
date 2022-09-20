using Syncfusion.Windows.Forms.Barcode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayNapKhiTPA.Forms
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
            sfBarcode1.Symbology = BarcodeSymbolType.Code11;
            sfBarcode1.Height = 70;
            sfBarcode1.Text = "999-888";
            this.Controls.Add(this.sfBarcode1);
        }
    }
}
