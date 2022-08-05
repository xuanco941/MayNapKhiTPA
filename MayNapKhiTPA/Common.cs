using System.Collections.Generic;
using MayNapKhiTPA.Models;

namespace MayNapKhiTPA
{
    public static class Common
    {

        public const string ConnectionString = @"Data Source=DESKTOP-P4IC2M8\SQLEXPRESS;Initial Catalog=MayNapKhiTPA;User ID=sa;Password=942001xX";


        //pagination
        public const int NUMBER_ELM_ON_PAGE_ACTIVITY = 10;
        public const int NUMBER_ELM_ON_PAGE_RESULT = 15;
        public const int NUMBER_ELM_ON_PAGE_ACTIVITY_IS_SETTING = 30;

        //user login
        public static User USERSESSION;
        public static Group GROUPSESSION;
    }

}
