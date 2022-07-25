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

namespace MayNapKhiTPA.Forms
{
    public partial class FormChangeGroup : Form
    {
        // tạo 1 delegate có 2 biến để call alert ở main
        public delegate void ChangeData(string msg, FormAlert.enmType enmType);
        // Create instance (null)
        public ChangeData changeData;
        public FormChangeGroup()
        {
            InitializeComponent();
            //lấy tất cả tên các quyền cho vào combobox
            var listGroups = GroupBusiness.GetAllGroups();
            var listNameGroup = from groupVar in listGroups select groupVar.Name;
            comboBoxSelectGroup.DataSource = listNameGroup.ToList();
        }
        
    }
}
