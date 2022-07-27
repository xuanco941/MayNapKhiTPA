using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayNapKhiTPA.Models
{
    public class TemplateSetting
    {
        public int ID_TemplateSetting { get; set; }
        public string Name { get; set; }
        public double ApSuatNap { get; set; }
        public double TheTichNap { get; set; }
        public double ThoiGianNap { get; set; }
        public double ThoiGianLayMau { get; set; }

        public TemplateSetting(int iD_TemplateSetting, string name, double apSuatNap, double theTichNap, double thoiGianNap, double thoiGianLayMau)
        {
            ID_TemplateSetting = iD_TemplateSetting;
            Name = name;
            ApSuatNap = apSuatNap;
            TheTichNap = theTichNap;
            ThoiGianNap = thoiGianNap;
            ThoiGianLayMau = thoiGianLayMau;
        }

        public TemplateSetting()
        {
        }
    }
}
