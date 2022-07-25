using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayNapKhiTPA.Models
{
    public class Shift
    {
        public int ID_Shift { get; set; }
        public string Name { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }

        public Shift(int iD_Shift, string name, TimeSpan timeStart, TimeSpan timeEnd)
        {
            ID_Shift = iD_Shift;
            Name = name;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
        }

        public Shift()
        {
        }
    }
}
