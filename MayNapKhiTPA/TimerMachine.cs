using System;
using System.Timers;
using MayNapKhiTPA.Models;

namespace MayNapKhiTPA
{
    public class TimerMachine
    {


        public Timer TimerMachine1;
        public Timer TimerMachine2;

        //Time Save Result
        // mặc định 10s
        public int timeInterval { get; set; } = 10000;

        public void RunTimerMachine1()
        {
            // Create a timer
            TimerMachine1 = new Timer();

            TimerMachine1.Interval = timeInterval;

            // Hook up the Elapsed event for the timer. 
            TimerMachine1.Elapsed += UpdateDataMachine1;

            // Have the timer fire repeated events (true is the default)
            TimerMachine1.AutoReset = true;

            // Start the timer
            TimerMachine1.Enabled = true;
        }
        public void ClearTimeMachine1()
        {
            if (TimerMachine1 != null && TimerMachine1.Enabled == true)
            {
                TimerMachine1.Stop();
                TimerMachine1.Dispose();
            }
            //set lại các data thành 0;
            Common.dataMachine1 = new Data();

            Common.chartDataApSuatMachine1 = new double[] { 0, 0, 0, 0, 0, 0, 0 };
            Common.chartDataTheTichMachine1 = new double[] { 0, 0, 0, 0, 0, 0, 0 };

        }

        public void UpdateDataMachine1(object sender, ElapsedEventArgs e)
        {
            Random random = new Random();

            Common.dataMachine1.ApSuat = random.NextDouble() * (0 - 121) + 121 - 31;
            Common.dataMachine1.TheTich = random.NextDouble() * (0 - 141) + 141 - 23;
            Common.dataMachine1.LuuLuong = random.NextDouble() * (7 - 111) + 111 - 12;
            try
            {
                DataBusiness.AddData(Common.dataMachine1);
            }
            catch
            {
                //
            }


            for (int i = 0; i < Common.chartDataApSuatMachine1.Length; i++)
            {
                if (i + 1 == Common.chartDataApSuatMachine1.Length)
                {
                    Common.chartDataApSuatMachine1[i] = Common.dataMachine1.ApSuat;
                    Common.chartDataTheTichMachine1[i] = Common.dataMachine1.TheTich;
                }
                else
                {
                    Common.chartDataApSuatMachine1[i] = Common.chartDataApSuatMachine1[i + 1];
                    Common.chartDataTheTichMachine1[i] = Common.chartDataTheTichMachine1[i + 1];
                }
            }
        }












        // timer machine 2

        public void RunTimerMachine2()
        {
            // Create a timer
            TimerMachine2 = new Timer();

            TimerMachine2.Interval = timeInterval;

            // Hook up the Elapsed event for the timer. 
            TimerMachine2.Elapsed += UpdateDataMachine2;

            // Have the timer fire repeated events (true is the default)
            TimerMachine2.AutoReset = true;

            // Start the timer
            TimerMachine2.Enabled = true;
        }
        public void ClearTimeMachine2()
        {
            if (TimerMachine2 != null && TimerMachine2.Enabled == true)
            {
                TimerMachine2.Stop();
                TimerMachine2.Dispose();

            }
            //set lại các data thành 0;
            Common.dataMachine2 = new Data();
            Common.chartDataApSuatMachine2 = new double[] { 0, 0, 0, 0, 0, 0, 0 };
            Common.chartDataTheTichMachine2 = new double[] { 0, 0, 0, 0, 0, 0, 0 };

        }

        public void UpdateDataMachine2(object sender, ElapsedEventArgs e)
        {
            Random random = new Random();

            Common.dataMachine2.ApSuat = random.NextDouble() * ((5 - 153) + 153) + 10;
            Common.dataMachine2.TheTich = random.NextDouble() * ((3 - 132) + 132) + 10;
            Common.dataMachine2.LuuLuong = random.NextDouble() * ((7 - 96) + 96) + 28;
            try
            {

                DataBusiness.AddData(Common.dataMachine2);
            }
            catch
            {
                //
            }


            for (int i = 0; i < Common.chartDataApSuatMachine2.Length; i++)
            {
                if (i + 1 == Common.chartDataApSuatMachine2.Length)
                {
                    Common.chartDataApSuatMachine2[i] = Common.dataMachine2.ApSuat;
                    Common.chartDataTheTichMachine2[i] = Common.dataMachine2.TheTich;
                }
                else
                {
                    Common.chartDataApSuatMachine2[i] = Common.chartDataApSuatMachine2[i + 1];
                    Common.chartDataTheTichMachine2[i] = Common.chartDataTheTichMachine2[i + 1];
                }
            }
        }









    }
}