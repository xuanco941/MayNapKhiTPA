using System;
using System.Data.SqlClient;
using MayNapKhiTPA;

namespace MayNapKhiTPA.Models
{
    public class SettingBusiness
    {
        public static void UpdateSetting(double ApSuat, TimeSpan ThoiGianNapGioiHan)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "exec UpdateThongSoMay @ApSuat, @ThoiGianNapGioiHan";

            command.Parameters.AddWithValue("ApSuat", ApSuat);
            command.Parameters.AddWithValue("ThoiGianNapGioiHan", ThoiGianNapGioiHan);
            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
