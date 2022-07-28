using System;

namespace MayNapKhiTPA.Models
{
    public class Setting
    {
        // mặc định trên db chỉ có 1 record lưu cài đặt này có ID = 1
        public int ID_Setting { get; set; } = 1;
        public string NameTemplateSetting { get; set; }
        public double ApSuatNap { get; set; }
        public double TheTichNap { get; set; }
        public double ThoiGianNap { get; set; }

        public double ThoiGianLayMau { get; set; }
        public DateTime UpdateAt { get; set; }

        public Setting()
        {
        }

        public Setting(string nameTemplateSetting, double apSuatNap, double theTichNap, double thoiGianNap, double thoiGianLayMau, DateTime updateAt)
        {
            NameTemplateSetting = nameTemplateSetting;
            ApSuatNap = apSuatNap;
            TheTichNap = theTichNap;
            ThoiGianNap = thoiGianNap;
            ThoiGianLayMau = thoiGianLayMau;
            UpdateAt = updateAt;
        }
    }
}
