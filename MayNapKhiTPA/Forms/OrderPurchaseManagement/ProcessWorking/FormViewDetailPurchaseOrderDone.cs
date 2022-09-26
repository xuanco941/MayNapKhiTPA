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

namespace MayNapKhiTPA.Forms.OrderPurchaseManagement.ProcessWorking
{
    public partial class FormViewDetailPurchaseOrderDone : Form
    {
        public FormViewDetailPurchaseOrderDone()
        {
            InitializeComponent();
            sfBarcode1.Symbology = BarcodeSymbolType.Code39Extended;
            sfBarcode1.Text = "ABC-123-abc";
        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
