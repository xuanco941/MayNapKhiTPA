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
    public partial class FormProcessWorking : Form
    {
        public FormProcessWorking()
        {
            InitializeComponent();
            sfBarcode1.Symbology = BarcodeSymbolType.Code39Extended;
            sfBarcode1.Text = "ABC-123-abc";
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            new FormViewDetailPurchaseOrderDone().Show();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            new FormViewDetailPurchaseOrderWorking().Show();
        }
    }
}
