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
        public double ApSuatNap { get; set; }
        public double TheTichNap { get; set; }
        public TimeSpan ThoiGianNap { get; set; }
        public TimeSpan ThoiGianLayMau { get; set; }
    }
}
