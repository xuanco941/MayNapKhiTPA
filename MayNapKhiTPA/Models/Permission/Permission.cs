using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayNapKhiTPA.Models
{
    internal class Permission
    {
        public int ID_Permission { get; set; }
        public string Name { get; set; }
        public bool IsManagementSetting { get; set; }
        public bool IsManagementEmployee { get; set; }

        public Permission(int iD_Permission, bool isManagementSetting, bool isManagementEmployee)
        {
            ID_Permission = iD_Permission;
            IsManagementSetting = isManagementSetting;
            IsManagementEmployee = isManagementEmployee;
        }
    }
}
