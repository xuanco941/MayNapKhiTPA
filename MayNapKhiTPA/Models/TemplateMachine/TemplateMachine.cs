using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayNapKhiTPA.Models
{
    public class TemplateMachine
    {
        public int ID_TemplateMachine { get; set; }
        public string Name { get; set; }
        public double ApSuatNap { get; set; }
        public double TheTichNap { get; set; }
        public double ThoiGianNap { get; set; }
        public double ThoiGianLayMau { get; set; }

        public TemplateMachine(int iD_TemplateMachine, string name, double apSuatNap, double theTichNap, double thoiGianNap, double thoiGianLayMau)
        {
            ID_TemplateMachine = iD_TemplateMachine;
            Name = name;
            ApSuatNap = apSuatNap;
            TheTichNap = theTichNap;
            ThoiGianNap = thoiGianNap;
            ThoiGianLayMau = thoiGianLayMau;
        }

        public TemplateMachine()
        {
        }
    }
}
