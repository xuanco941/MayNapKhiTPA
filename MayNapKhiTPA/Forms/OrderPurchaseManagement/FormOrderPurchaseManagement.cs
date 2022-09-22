using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MayNapKhiTPA.Forms.OrderPurchaseManagement.PurchaseOrder;

namespace MayNapKhiTPA.Forms.OrderPurchaseManagement
{
    public partial class FormOrderPurchaseManagement : Form
    {
        // Aleart
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;

        //change form
        public delegate void ChangeForm(Form form);
        public ChangeForm changeForm;
        public FormOrderPurchaseManagement()
        {
            InitializeComponent();
        }

        private void buttonPurchaseOrder_Click(object sender, EventArgs e)
        {
            changeForm?.Invoke(new FormPurchaseOrder());
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            changeForm?.Invoke(new FormProcessWorking());
        }

        private void buttonTodolist_Click(object sender, EventArgs e)
        {
            changeForm?.Invoke(new FormWorkingList());
        }
    }
}
