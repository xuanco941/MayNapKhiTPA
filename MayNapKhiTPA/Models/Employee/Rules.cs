using System.Data.SqlClient;
using MayNapKhiTPA;
namespace MayNapKhiTPA.Models
{
    public class Rules
    {
        public static bool IsAdmin(int MaNV)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec FindEmployeeByID {MaNV}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);

            SqlDataReader sqlDataReader = command.ExecuteReader();
            //(5) là isAdmin
            if (sqlDataReader.Read() && sqlDataReader.GetBoolean(5) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}

