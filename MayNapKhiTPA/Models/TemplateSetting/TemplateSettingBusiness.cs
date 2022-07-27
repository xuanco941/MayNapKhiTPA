using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayNapKhiTPA.Models
{
    public class TemplateSettingBusiness
    {

        public static List<TemplateSetting> GetAllTemplateSettings()
        {
            List<TemplateSetting> list = new List<TemplateSetting>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = "select * from [TemplateSetting]";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                TemplateSetting templateSetting = new TemplateSetting(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetDouble(2), sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5));
                list.Add(templateSetting);
            }
            sqlConnection.Close();
            return list;
        }


        public static TemplateSetting GetTemplateSettingFromName(string name)
        {
            TemplateSetting templateSetting = new TemplateSetting();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec GetTemplateSettingFromName N'{name}'";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                templateSetting.ID_TemplateSetting = sqlDataReader.GetInt32(0);
                templateSetting.Name = sqlDataReader.GetString(1);
                templateSetting.ApSuatNap = sqlDataReader.GetDouble(2);
                templateSetting.TheTichNap = sqlDataReader.GetDouble(3);
                templateSetting.ThoiGianNap = sqlDataReader.GetDouble(4);
                templateSetting.ThoiGianLayMau = sqlDataReader.GetDouble(5);
            }
            sqlConnection.Close();
            return templateSetting;
        }

        public static TemplateSetting GetTemplateSettingFromID(int ID_TemplateSetting)
        {
            TemplateSetting templateSetting = new TemplateSetting();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec GetTemplateSettingFromID {ID_TemplateSetting}";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                templateSetting.ID_TemplateSetting = sqlDataReader.GetInt32(0);
                templateSetting.Name = sqlDataReader.GetString(1);
                templateSetting.ApSuatNap = sqlDataReader.GetDouble(2);
                templateSetting.TheTichNap = sqlDataReader.GetDouble(3);
                templateSetting.ThoiGianNap = sqlDataReader.GetDouble(4);
                templateSetting.ThoiGianLayMau = sqlDataReader.GetDouble(5);
            }
            sqlConnection.Close();
            return templateSetting;
        }





        // Them Ca làm
        public static void AddTemplateSetting(TemplateSetting templateSetting)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec AddTemplateSetting @Name, @ApSuatNap, @TheTichNap, @ThoiGianNap, @ThoiGianLayMau";
            command.Parameters.AddWithValue("Name", templateSetting.Name);
            command.Parameters.AddWithValue("ApSuatNap", templateSetting.ApSuatNap);
            command.Parameters.AddWithValue("TheTichNap", templateSetting.TheTichNap);
            command.Parameters.AddWithValue("ThoiGianNap", templateSetting.ThoiGianNap);
            command.Parameters.AddWithValue("ThoiGianLayMau", templateSetting.ThoiGianLayMau);


            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        // Sua TK
        public static void UpdateTemplateSetting(int ID_TemplateSetting , string Name,double ApSuatNap, double TheTichNap, double ThoiGianNap, double ThoiGianLayMau)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = "exec UpdateTemplateSetting @ID_TemplateSetting ,@Name , @ApSuatNap, @TheTichNap, @ThoiGianNap, @ThoiGianLayMau";
            command.Parameters.AddWithValue("ID_TemplateSetting", ID_TemplateSetting);
            command.Parameters.AddWithValue("Name", Name);
            command.Parameters.AddWithValue("ApSuatNap", ApSuatNap);
            command.Parameters.AddWithValue("TheTichNap", TheTichNap);
            command.Parameters.AddWithValue("ThoiGianNap", ThoiGianNap);
            command.Parameters.AddWithValue("ThoiGianLayMau", ThoiGianLayMau);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static void DeleteTemplateSetting(int ID_TemplateSetting)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec DeleteTemplateSetting @ID_TemplateSetting";
            command.Parameters.AddWithValue("ID_TemplateSetting", ID_TemplateSetting);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

    }
}
