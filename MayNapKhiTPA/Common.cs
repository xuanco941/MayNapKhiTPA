using System.Collections.Generic;

namespace MayNapKhiTPA
{
    public static class Common
    {

        public const string ConnectionString = @"Data Source=DESKTOP-P4IC2M8\SQLEXPRESS;Initial Catalog=MayNapKhiTPA;User ID=sa;Password=942001xX";

        public const int NUMBER_ELM_ON_PAGE_ACTIVITY = 10;

        public const int NUMBER_ELM_ON_PAGE_RESULT = 15;

        public static List<int> listIdUserHasDeleted = new List<int>();

        public static string MessageErrorDashboard;
        public static bool IsLoggedIn { get; set; } = false;
        public static bool IsAdmin { get; set; } = false;

        public static string UserNameCurrent = "";
    }

}
