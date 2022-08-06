using System.Collections.Generic;
using System.Data.SqlClient;
using MayNapKhiTPA;

namespace MayNapKhiTPA.Models
{

    public class ResultBusiness
    {
        public static List<Result> GetAllResults(int page)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();


            int? start = (page - 1) * Common.NUMBER_ELM_ON_PAGE_RESULT;
            int? end = page * Common.NUMBER_ELM_ON_PAGE_RESULT;
            string sql = $"exec PaginationResult {start},{end}";

            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {

                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        public static List<Result> GetResultByDay(string tungay, string toingay, int page)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();


            int start = (page - 1) * Common.NUMBER_ELM_ON_PAGE_RESULT;
            int end = page * Common.NUMBER_ELM_ON_PAGE_RESULT;
            string sql = $"exec PaginationResultByDay {start},{end},'{tungay}','{toingay}'";

            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                        sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        public static int CountResult()
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = "select count(*) from Result";
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

        public static int CountResultByDay(string tungay, string toingay)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec CountResultDayToDay '{tungay}', '{toingay}'";
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


        public static int AddResultAndReturnIDResult(Result result)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = $"AddResultAndReturnIDResult N'{result.NameMachine}', N'{result.Worker}'";
            command.Connection = sqlConnection;

            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }

        public static List<Result> GetResultFromWorker(string worker)
        {

            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec GetResultFromWorker N'{worker}'";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                         sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                         sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13));
                list.Add(result);
            }
            sqlConnection.Close();

            return list;
        }


        public static List<string> GetListWorkerHasResult()
        {

            List<string> list = new List<string>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec GetListWorkerHasResult";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                list.Add(sqlDataReader.GetString(0));
            }
            sqlConnection.Close();

            return list;
        }
        public static List<string> GetListMachineHasResult()
        {

            List<string> list = new List<string>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec GetListMachineHasResult";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                list.Add(sqlDataReader.GetString(0));
            }
            sqlConnection.Close();

            return list;
        }

        public static Result GetResultFromID(int ID_Result)
        {
            Result result = null;
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"GetResultFromID {ID_Result}";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                         sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                         sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13));
            }
            sqlConnection.Close();
            return result;
        }

        public static void DeleteResultFromID(int ID_Result)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = $"exec DeleteResultFromID {ID_Result}";
            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
