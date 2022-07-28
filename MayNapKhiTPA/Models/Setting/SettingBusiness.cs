using System;
using System.Data.SqlClient;
using MayNapKhiTPA;

namespace MayNapKhiTPA.Models
{
    public class SettingBusiness
    {
        public static void UpdateSetting(string Name, double apSuatNap, double theTichNap, double thoiGianNap, double thoiGianLayMau)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "exec UpdateSetting @NameTemplateSetting, @ApSuatNap, @TheTichNap, @ThoiGianNap, @ThoiGianLayMau";

            command.Parameters.AddWithValue("NameTemplateSetting", Name);
            command.Parameters.AddWithValue("ApSuatNap", apSuatNap);
            command.Parameters.AddWithValue("TheTichNap", theTichNap);
            command.Parameters.AddWithValue("ThoiGianNap", thoiGianNap);
            command.Parameters.AddWithValue("ThoiGianLayMau", thoiGianLayMau);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public static Setting GetSetting()
        {
            Setting setting = new Setting();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "Select * from Setting where ID_Setting = 1";
            command.Connection = sqlConnection;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                setting.NameTemplateSetting = sqlDataReader.GetString(1);
                setting.ApSuatNap = sqlDataReader.GetDouble(2);
                setting.TheTichNap = sqlDataReader.GetDouble(3);
                setting.ThoiGianNap = sqlDataReader.GetDouble(4);
                setting.ThoiGianLayMau = sqlDataReader.GetDouble(5);
                setting.UpdateAt = sqlDataReader.GetDateTime(6);

            }
            sqlConnection.Close();
            return setting;
        }
    }
}
