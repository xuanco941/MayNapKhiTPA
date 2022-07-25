using System.Collections.Generic;
using System.Data.SqlClient;

namespace MayNapKhiTPA.Models
{

    public class ActivityBusiness
    {
        public static List<Activity> GetAllActivities(int? page)
        {
            List<Activity> list = new List<Activity>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql;
            if (page != null && page != 0)
            {
                int? start = (page - 1) * Common.NUMBER_ELM_ON_PAGE_ACTIVITY;
                int? end = page * Common.NUMBER_ELM_ON_PAGE_ACTIVITY;
                sql = $"exec paginationActivity {start},{end}";
            }
            else
            {
                sql = "select * from Activity order by Activity.Activity_ID DESC";
            }
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Activity activity = new Activity(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetBoolean(2), sqlDataReader.GetDateTime(3), sqlDataReader.GetInt32(4));
                list.Add(activity);
            }
            sqlConnection.Close();
            return list;
        }

        public List<Activity> GetActivityByDay(string tungay, string toingay, int? page)
        {
            List<Activity> list = new List<Activity>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql;
            if (page != null && page != 0)
            {
                int? start = (page - 1) * Common.NUMBER_ELM_ON_PAGE_ACTIVITY;
                int? end = page * Common.NUMBER_ELM_ON_PAGE_ACTIVITY;
                sql = $"exec PaginationActivityByDay {start},{end},'{tungay}','{toingay}'";
            }
            else
            {
                sql = $"exec FindActivityByDayToDay '{tungay}', '{toingay}'";
            }
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Activity activity = new Activity(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetBoolean(2), sqlDataReader.GetDateTime(3), sqlDataReader.GetInt32(4));
                list.Add(activity);
            }
            sqlConnection.Close();
            return list;
        }

        public static int CountActivity()
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = "select count(*) from Activity";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }

        public static int CountActivityByDay(string tungay, string toingay)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec CountActivityDayToDay '{tungay}', '{toingay}'";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }


        public static void AddActivity(Activity activity)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = $"AddActivity {activity.Description}, {activity.IsSetting}, {activity.ID_User}";
            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static List<Activity> GetActivityFromIDUser(int ID_User)
        {

            List<Activity> list = new List<Activity>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec GetActivityFromIDUser {ID_User}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Activity activity = new Activity(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetBoolean(2), sqlDataReader.GetDateTime(3), sqlDataReader.GetInt32(4));
                list.Add(activity);
            }
            sqlConnection.Close();

            return list;
        }

        public static List<int> GetListIDUserHasActivity()
        {

            List<int> list = new List<int>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec GetListIDUserHasActivity";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                list.Add(sqlDataReader.GetInt32(0)) ;
            }
            sqlConnection.Close();

            return list;
        }


    }

}
