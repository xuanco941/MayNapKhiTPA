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
                sql = "select * from Activity order by Activity.ID_Activity DESC";
            }
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Activity activity = new Activity(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetBoolean(2), sqlDataReader.GetDateTime(3), sqlDataReader.GetString(4));
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
                sql = $"exec FindActivityByDay '{tungay}', '{toingay}'";
            }
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Activity activity = new Activity(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetBoolean(2), sqlDataReader.GetDateTime(3), sqlDataReader.GetString(4));
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
            command.CommandText = $"AddActivity N'{activity.Description}', {activity.IsSetting}, N'{activity.Worker}'";
            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static List<Activity> GetActivityFromWorker(string worker)
        {

            List<Activity> list = new List<Activity>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec GetActivityFromWorker N'{worker}'";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Activity activity = new Activity(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetBoolean(2), sqlDataReader.GetDateTime(3), sqlDataReader.GetString(4));
                list.Add(activity);
            }
            sqlConnection.Close();

            return list;
        }


        public static List<string> GetListWorkerHasActivity()
        {

            List<string> list = new List<string>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec GetListWorkerHasActivity";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                list.Add(sqlDataReader.GetString(0)) ;
            }
            sqlConnection.Close();

            return list;
        }

        public static List<Activity> GetActivitiesIsSetting()
        {

            List<Activity> list = new List<Activity>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"select * from Activity where isSetting = 1";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Activity activity = new Activity(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetBoolean(2), sqlDataReader.GetDateTime(3), sqlDataReader.GetString(4));
                list.Add(activity);
            }
            sqlConnection.Close();

            return list;
        }

    }

}
