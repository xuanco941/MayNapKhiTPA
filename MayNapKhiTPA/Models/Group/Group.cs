using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayNapKhiTPA.Models
{
    internal class Group
    {
        public int ID_Group { get; set; }
        public string Name { get; set; }
        public bool IsManagementSetting { get; set; }
        public bool IsManagementUser { get; set; }

        public Group(int iD_Group, string name, bool isManagementSetting, bool isManagementUser)
        {
            ID_Group = iD_Group;
            Name = name;
            IsManagementSetting = isManagementSetting;
            IsManagementUser = isManagementUser;
        }
    }
}
