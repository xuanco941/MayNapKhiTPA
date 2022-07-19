using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MayNapKhiTPA.Models;

namespace MayNapKhiTPA.Forms.EmployeeManagement.Group
{
    public partial class FormAddGroup : Form
    {
        public FormAddGroup()
        {

            InitializeComponent();
        }
        // Define delegate
        public delegate void ChangeData();

        // Create instance (null)
        public ChangeData changeData;

    }
}
