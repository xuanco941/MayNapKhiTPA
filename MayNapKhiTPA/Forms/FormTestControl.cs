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
    public partial class FormTestControl : Form
    {
        public FormTestControl()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;

        }
    }
}
