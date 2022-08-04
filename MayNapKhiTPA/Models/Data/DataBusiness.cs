using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayNapKhiTPA.Models
{
    public class DataBusiness
    {
        public static List<Data> GetAllDatasByIDResult(int ID_Result)
        {
            List<Data> list = new List<Data>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"select * from [Data] where ID_Result = {ID_Result} ORDER BY ID_Data desc";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Data data = new Data(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2), sqlDataReader.GetDouble(3), sqlDataReader.GetDateTime(4), sqlDataReader.GetInt32(5));
                list.Add(data);
            }
            sqlConnection.Close();
            return list;
        }
        public static void AddData(Data data)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec AddData @ApSuat, @TheTich, @LuuLuong, @ID_Result";

            command.Parameters.AddWithValue("ApSuat", data.ApSuat);
            command.Parameters.AddWithValue("TheTich", data.TheTich);
            command.Parameters.AddWithValue("LuuLuong", data.LuuLuong);
            command.Parameters.AddWithValue("ID_Result", data.ID_Result);


            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
