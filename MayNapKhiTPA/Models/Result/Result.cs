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
        public string NameMachine { get; set; }
        public string Worker { get; set; }

        public bool Status { get; set; }
        public Result()
        {
        }

        public Result(int iD_Result, double apSuatMin, double apSuatMax, double apSuatAvg, double theTichMin, double theTichMax, double theTichAvg, double luuLuongMin, double luuLuongMax, double luuLuongAvg, DateTime timeStart, DateTime timeEnd, string nameMachine, string worker, bool status)
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
            NameMachine = nameMachine;
            Worker = worker;
            Status = status;
        }
    }

}

