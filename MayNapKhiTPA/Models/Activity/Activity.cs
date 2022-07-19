using System;

namespace MayNapKhiTPA.Models
{
    public class Activity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }

        public Activity(int iD, string name, DateTime time)
        {
            ID = iD;
            Name = name;
            Time = time;
        }

    }
}

