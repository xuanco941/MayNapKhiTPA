using System;

namespace MayNapKhiTPA.Models
{
    public class Activity
    {
        public int ID_Activity { get; set; }
        public string Description { get; set; }
        public bool IsSetting { get; set; }
        public DateTime Create_At { get; set; }
        public int ID_User { get; set; }

        public Activity(int iD_Activity, string description, bool isSetting, DateTime create_At, int iD_User)
        {
            ID_Activity = iD_Activity;
            Description = description;
            IsSetting = isSetting;
            Create_At = create_At;
            ID_User = iD_User;
        }
        public Activity()
        {
        }
    }
}

