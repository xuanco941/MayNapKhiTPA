using System;

namespace MayNapKhiTPA.Models
{
    public class Result
    {
        public int ID_Result { get; set; }
        public double ApSuatMin { get; set; }
        public double ApSuatMax { get; set; }
        public double ApSuatAvg { get; set; }
        public double TheTichMin { get; set; }
        public double TheTichMax { get; set; }
        public double TheTichAvg { get; set; }
        public double LuuLuongMin { get; set; }
        public double LuuLuongMax { get; set; }
        public double LuuLuongAvg { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int ID_Machine { get; set; }
        public int ID_User { get; set; }
        public Result()
        {
        }

        public Result(int iD_Result, double apSuatMin, double apSuatMax, double apSuatAvg, double theTichMin, double theTichMax, double theTichAvg, double luuLuongMin, double luuLuongMax, double luuLuongAvg, DateTime timeStart, DateTime timeEnd, int iD_Machine, int iD_User)
        {
            ID_Result = iD_Result;
            ApSuatMin = apSuatMin;
            ApSuatMax = apSuatMax;
            ApSuatAvg = apSuatAvg;
            TheTichMin = theTichMin;
            TheTichMax = theTichMax;
            TheTichAvg = theTichAvg;
            LuuLuongMin = luuLuongMin;
            LuuLuongMax = luuLuongMax;
            LuuLuongAvg = luuLuongAvg;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            ID_Machine = iD_Machine;
            ID_User = iD_User;
        }
    }

}

