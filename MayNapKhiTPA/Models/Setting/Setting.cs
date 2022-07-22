using System;

namespace MayNapKhiTPA.Models
{
    public class Setting
    {
        public int ID_Setting { get; set; } = 1;
        public double ApSuatNap { get; set; }
        public double TheTichNap { get; set; }
        public TimeSpan ThoiGianNap { get; set; }

        public TimeSpan ThoiGianLayMau { get; set; }
        public DateTime UpdateAt { get; set; }

    }
}
