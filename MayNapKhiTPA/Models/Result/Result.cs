using System;

namespace MayNapKhiTPA.Models
{
    public class Result
    {
        public int ID { get; set; }
        public double ApSuat { get; set; }
        public double TheTich { get; set; }
        public double LuuLuong { get; set; }
        public TimeSpan ThoiGianNap { get; set; }
        public DateTime CreateAt { get; set; }

        public Result(int iD, double apSuat, double theTich, double luuLuong, TimeSpan thoiGianNap, DateTime createAt)
        {
            ID = iD;
            ApSuat = apSuat;
            TheTich = theTich;
            LuuLuong = luuLuong;
            ThoiGianNap = thoiGianNap;
            CreateAt = createAt;
        }

        public Result()
        {
        }
    }

}

