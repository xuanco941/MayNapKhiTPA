using System;

namespace MayNapKhiTPA.Models
{
    public class Result
    {
        public int ID_Result { get; set; }
        public double ApSuat { get; set; }
        public double TheTich { get; set; }
        public double LuuLuong { get; set; }
        public TimeSpan ThoiGianNap { get; set; }
        public DateTime CreateAt { get; set; }

        public Result()
        {
        }

    }

}

