﻿using Syncfusion.Windows.Forms.Barcode;
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
            sfBarcode1.Symbology = BarcodeSymbolType.Code39Extended;
            sfBarcode1.Text = "ABC-123-abc";
            this.Controls.Add(this.sfBarcode1);
        }
    }
}
