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
            string sql = $"select * from [Data] where ID_Result = {ID_Result}";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Data data = new Data(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2), sqlDataReader.GetDouble(3), sqlDataReader.GetDateTime(4), sqlDataReader.GetInt32(6));
                list.Add(data);
            }
            sqlConnection.Close();
            return list;
        }
    }
}
