using System.Collections.Generic;
using MayNapKhiTPA.Models;

namespace MayNapKhiTPA
{
    public static class Common
    {

        public const string ConnectionString = @"Data Source=DESKTOP-P4IC2M8\SQLEXPRESS;Initial Catalog=MayNapKhiTPA;User ID=sa;Password=942001xX";
        public const string LicenseSyncfusion = "NzE5NjE0QDMyMzAyZTMyMmUzMFlqaFh1Qk9GKytyNHNaaE16dktXZFg0cERMU2Qvai9KQmdEYUZSL0U4OE09";

        //pagination
        public static int NUMBER_ELM_ON_PAGE_ACTIVITY = 10;
        public static int NUMBER_ELM_ON_PAGE_RESULT = 15;
        public const int NUMBER_ELM_ON_PAGE_ACTIVITY_IS_SETTING = 50;

        //user login
        public static User USERSESSION;
        public static Group GROUPSESSION;

        //Data Current Chart
        public static double[] chartDataApSuatMachine1 = new double[7] { 0, 0, 0, 0, 0, 0, 0 };
        public static double[] chartDataTheTichMachine1 = new double[7] { 0, 0, 0, 0, 0, 0, 0 };

        public static double[] chartDataApSuatMachine2 = new double[7] { 0, 0, 0, 0, 0, 0, 0 };
        public static double[] chartDataTheTichMachine2 = new double[7] { 0, 0, 0, 0, 0, 0, 0 };

        //Data PLC Current
        public static Data dataMachine1 = new Data();
        public static Data dataMachine2 = new Data();

        //Check IsMachineRunning
        public static bool IsMachine1Running = false;
        public static bool IsMachine2Running = false;


        //TimeMachine
        public static TimerMachine timer = new TimerMachine();
    }

}
