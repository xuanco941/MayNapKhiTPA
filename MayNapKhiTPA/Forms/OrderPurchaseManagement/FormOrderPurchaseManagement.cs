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
    public partial class FormOrderPurchaseManagement : Form
    {
        // Aleart
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;

        public FormOrderPurchaseManagement()
        {
            InitializeComponent();
        }
    }
}
