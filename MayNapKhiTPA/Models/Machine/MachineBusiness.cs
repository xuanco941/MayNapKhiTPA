using System;
using System.Data.SqlClient;
using MayNapKhiTPA;

namespace MayNapKhiTPA.Models
{
    public class MachineBusiness
    {
        public static void UpdateMachine(string NameTemplateMachine, double apSuatNap, double theTichNap, double thoiGianNap, double thoiGianLayMau)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "exec UpdateMachine @NameTemplateMachine, @ApSuatNap, @TheTichNap, @ThoiGianNap, @ThoiGianLayMau";

            command.Parameters.AddWithValue("NameTemplateMachine", NameTemplateMachine);
            command.Parameters.AddWithValue("ApSuatNap", apSuatNap);
            command.Parameters.AddWithValue("TheTichNap", theTichNap);
            command.Parameters.AddWithValue("ThoiGianNap", thoiGianNap);
            command.Parameters.AddWithValue("ThoiGianLayMau", thoiGianLayMau);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public static Machine GetMachine1()
        {
            Machine machine = new Machine();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            // lấy cài đặt của máy 1
            command.CommandText = "Select * from Machine where ID_Machine = 1";
            command.Connection = sqlConnection;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                machine.ID_Machine = sqlDataReader.GetInt32(0);
                machine.NameMachine = sqlDataReader.GetString(1);
                machine.NameTemplateMachine = sqlDataReader.GetString(2);
                machine.ApSuatNap = sqlDataReader.GetDouble(3);
                machine.TheTichNap = sqlDataReader.GetDouble(4);
                machine.ThoiGianNap = sqlDataReader.GetDouble(5);
                machine.ThoiGianLayMau = sqlDataReader.GetDouble(6);
                machine.UpdateAt = sqlDataReader.GetDateTime(7);

            }
            sqlConnection.Close();
            return machine;
        }
    }
}
