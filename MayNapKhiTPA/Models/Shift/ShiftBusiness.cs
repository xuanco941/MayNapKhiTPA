using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayNapKhiTPA.Models
{
    internal class ShiftBusiness
    {
        public static List<Shift> GetAllShifts()
        {
            List<Shift> list = new List<Shift>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = "select * from Shift";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Shift shift = new Shift(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetTimeSpan(2), sqlDataReader.GetTimeSpan(3));
                list.Add(shift);
            }
            sqlConnection.Close();
            return list;
        }



        // Them Ca làm
        public static void AddShift(Shift shift)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec AddShift @Name, @TimeStart, @TimeEnd";
            command.Parameters.AddWithValue("Name", shift.Name);
            command.Parameters.AddWithValue("TimeStart", shift.TimeStart);
            command.Parameters.AddWithValue("TimeEnd", shift.TimeEnd);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        // Sua TK
        public static void UpdateShift(int ID_Shift, string Name, TimeSpan TimeStart, TimeSpan TimeEnd)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = "exec UpdateShift @ID_Shift, @Name, @TimeStart, @TimeEnd";

            command.Parameters.AddWithValue("ID_Shift", ID_Shift);
            command.Parameters.AddWithValue("Name", Name);
            command.Parameters.AddWithValue("TimeStart", TimeStart);
            command.Parameters.AddWithValue("TimeEnd", TimeEnd);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static void DeleteShift(int ID_Shift)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec DeleteShift @ID_Shift";
            command.Parameters.AddWithValue("ID_Shift", ID_Shift);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
