using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayNapKhiTPA.Models
{
    public class Group
    {

        public int ID_Group { get; set; }
        public string Name { get; set; }
        public bool IsManagementUser { get; set; }
        public bool IsManagementGroup { get; set; }
        public bool IsControlMachine { get; set; }
        public bool IsSettingMachine { get; set; }
        public bool IsSettingShift { get; set; }
        public bool IsSettingTemplateMachine { get; set; }
        public bool IsViewResult { get; set; }
        public bool IsViewActivity { get; set; }
        public bool IsDeleteResult { get; set; }
        public bool IsDeleteActivity { get; set; }

        public Group(int iD_Group, string name, bool isManagementUser, bool isManagementGroup, bool isControlMachine, bool isSettingMachine, bool isSettingShift, bool isSettingTemplateMachine, bool isViewResult, bool isViewActivity, bool isDeleteResult, bool isDeleteActivity)
        {
            ID_Group = iD_Group;
            Name = name;
            IsManagementUser = isManagementUser;
            IsManagementGroup = isManagementGroup;
            IsControlMachine = isControlMachine;
            IsSettingMachine = isSettingMachine;
            IsSettingShift = isSettingShift;
            IsSettingTemplateMachine = isSettingTemplateMachine;
            IsViewResult = isViewResult;
            IsViewActivity = isViewActivity;
            IsDeleteResult = isDeleteResult;
            IsDeleteActivity = isDeleteActivity;
        }

        public Group()
        {

        }
    }
}
