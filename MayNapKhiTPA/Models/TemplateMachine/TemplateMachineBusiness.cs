using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayNapKhiTPA.Models
{
    public class TemplateMachineBusiness
    {

        public static List<TemplateMachine> GetAllTemplateMachines()
        {
            List<TemplateMachine> list = new List<TemplateMachine>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = "select * from [TemplateMachine]";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                TemplateMachine templateMachine = new TemplateMachine(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetDouble(2), sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5));
                list.Add(templateMachine);
            }
            sqlConnection.Close();
            return list;
        }


        public static TemplateMachine GetTemplateMachineFromName(string name)
        {
            TemplateMachine templateMachine = new TemplateMachine();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec GetTemplateMachineFromName N'{name}'";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                templateMachine.ID_TemplateMachine = sqlDataReader.GetInt32(0);
                templateMachine.Name = sqlDataReader.GetString(1);
                templateMachine.ApSuatNap = sqlDataReader.GetDouble(2);
                templateMachine.TheTichNap = sqlDataReader.GetDouble(3);
                templateMachine.ThoiGianNap = sqlDataReader.GetDouble(4);
                templateMachine.ThoiGianLayMau = sqlDataReader.GetDouble(5);
            }
            sqlConnection.Close();
            return templateMachine;
        }

        public static TemplateMachine GetTemplateMachineFromID(int ID_TemplateMachine)
        {
            TemplateMachine templateMachine = new TemplateMachine();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec GetTemplateMachineFromID {ID_TemplateMachine}";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                templateMachine.ID_TemplateMachine = sqlDataReader.GetInt32(0);
                templateMachine.Name = sqlDataReader.GetString(1);
                templateMachine.ApSuatNap = sqlDataReader.GetDouble(2);
                templateMachine.TheTichNap = sqlDataReader.GetDouble(3);
                templateMachine.ThoiGianNap = sqlDataReader.GetDouble(4);
                templateMachine.ThoiGianLayMau = sqlDataReader.GetDouble(5);
            }
            sqlConnection.Close();
            return templateMachine;
        }





        // Them Ca làm
        public static void AddTemplateMachine(TemplateMachine templateMachine)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec AddTemplateMachine @Name, @ApSuatNap, @TheTichNap, @ThoiGianNap, @ThoiGianLayMau";
            command.Parameters.AddWithValue("Name", templateMachine.Name);
            command.Parameters.AddWithValue("ApSuatNap", templateMachine.ApSuatNap);
            command.Parameters.AddWithValue("TheTichNap", templateMachine.TheTichNap);
            command.Parameters.AddWithValue("ThoiGianNap", templateMachine.ThoiGianNap);
            command.Parameters.AddWithValue("ThoiGianLayMau", templateMachine.ThoiGianLayMau);


            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        // Sua TK
        public static void UpdateTemplateMachine(int ID_TemplateMachine , string Name,double ApSuatNap, double TheTichNap, double ThoiGianNap, double ThoiGianLayMau)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = "exec UpdateTemplateMachine @ID_TemplateMachine ,@Name , @ApSuatNap, @TheTichNap, @ThoiGianNap, @ThoiGianLayMau";
            command.Parameters.AddWithValue("ID_TemplateMachine", ID_TemplateMachine);
            command.Parameters.AddWithValue("Name", Name);
            command.Parameters.AddWithValue("ApSuatNap", ApSuatNap);
            command.Parameters.AddWithValue("TheTichNap", TheTichNap);
            command.Parameters.AddWithValue("ThoiGianNap", ThoiGianNap);
            command.Parameters.AddWithValue("ThoiGianLayMau", ThoiGianLayMau);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static void DeleteTemplateMachine(int ID_TemplateMachine)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec DeleteTemplateMachine @ID_TemplateMachine";
            command.Parameters.AddWithValue("ID_TemplateMachine", ID_TemplateMachine);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

    }
}
