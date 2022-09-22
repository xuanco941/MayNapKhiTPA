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

namespace MayNapKhiTPA.Forms.OrderPurchaseManagement
{
    public partial class FormProcessWorking : Form
    {
        public FormProcessWorking()
        {
            InitializeComponent();

            Code39ExtendedSetting code39Settings = new Code39ExtendedSetting();
            code39Settings.EnableCheckDigit = false;
            code39Settings.ShowCheckDigit = true;
            code39Settings.EncodeStartStopSymbols = true;
            this.sfBarcode1.SymbologySettings = code39Settings;
            sfBarcode1.Text = "ABC-123-abc";
        }
    }
}
