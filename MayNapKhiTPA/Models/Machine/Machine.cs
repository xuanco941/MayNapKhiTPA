using System;

namespace MayNapKhiTPA.Models
{
    public class Machine
    {
        // mặc định trên db chỉ có 1 record lưu cài đặt này có ID = 1
        public int ID_Machine { get; set; }
        public string NameMachine { get; set; }
        public string NameTemplateMachine { get; set; }
        public double ApSuatNap { get; set; }
        public double TheTichNap { get; set; }
        public double ThoiGianNap { get; set; }

        public double ThoiGianLayMau { get; set; }
        public DateTime UpdateAt { get; set; }

        public Machine(int iD_Machine, string nameMachine, string nameTemplateMachine, double apSuatNap, double theTichNap, double thoiGianNap, double thoiGianLayMau, DateTime updateAt)
        {
            ID_Machine = iD_Machine;
            NameMachine = nameMachine;
            NameTemplateMachine = nameTemplateMachine;
            ApSuatNap = apSuatNap;
            TheTichNap = theTichNap;
            ThoiGianNap = thoiGianNap;
            ThoiGianLayMau = thoiGianLayMau;
            UpdateAt = updateAt;
        }

        public Machine()
        {
        }
    }
}
