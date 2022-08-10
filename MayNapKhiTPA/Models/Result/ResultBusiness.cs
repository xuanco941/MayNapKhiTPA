using System.Collections.Generic;
using System.Data.SqlClient;
using MayNapKhiTPA;

namespace MayNapKhiTPA.Models
{

    public class ResultBusiness
    {

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
            string sql = $"exec GetResultFromID {ID_Result}";
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
        public static void UpdateResult(int ID_Result)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = $"exec UpdateResult {ID_Result}";
            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static int AddResultAndReturnIDResult(string nameMachine, string woker)
        {
            int idResult = 0;
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec AddResultAndReturnIDResult N'{nameMachine}', N'{woker}'";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                idResult = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();
            return idResult;
        }

    }
}
