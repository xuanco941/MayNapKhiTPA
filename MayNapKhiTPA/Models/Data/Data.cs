using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayNapKhiTPA.Models
{
    public class Data
    {
        public int ID_Data { get; set; }
        public double ApSuat { get; set; }
        public double TheTich { get; set; }
        public double LuuLuong { get; set; }
        public DateTime CreateAt { get; set; }
        public int ID_Result { get; set; }

        public Data(int iD_Data, double apSuat, double theTich, double luuLuong, DateTime createAt, int iD_Result)
        {
            ID_Data = iD_Data;
            ApSuat = apSuat;
            TheTich = theTich;
            LuuLuong = luuLuong;
            CreateAt = createAt;
            ID_Result = iD_Result;
        }

        public Data()
        {
        }
    }
}
