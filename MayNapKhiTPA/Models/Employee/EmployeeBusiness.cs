using System.Collections.Generic;
using System.Data.SqlClient;
using MayNapKhiTPA;
namespace MayNapKhiTPA.Models
{

    public class EmployeeBusiness
    {
        public static bool AuthLogin(string username, string password)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            //Dung procedure co san tren db
            string sql = $"exec FindEmployeeByUsername '{username.ToString().Trim()}'";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();

            // 3 la cloumn password
            if (sqlDataReader.Read() && ((string)sqlDataReader["Password"]).Trim() == password.ToString().Trim())
            {
                sqlConnection.Close();
                return true;
            }
            else
            {
                sqlConnection.Close();
                return false;
            }
        }

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = "select * from Employee";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Employee employee = new Employee((int)sqlDataReader["ID_Employee"], (string)sqlDataReader["FullName"],
                    (string)sqlDataReader["Username"], (string)sqlDataReader["Password"], (string)sqlDataReader["PhoneNumber"], (string)sqlDataReader["Email"], (int)sqlDataReader["ID_Shift"], (int)sqlDataReader["ID_Permission"]);
                list.Add(employee);
            }
            sqlConnection.Close();
            return list;
        }



        // Them TK
        public static void AddEmployee(Employee employee)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec AddEmployee @FullName, @Username, @Password,@PhoneNumber, @Email, @ID_Shift, @ID_Permission";
            command.Parameters.AddWithValue("FullName", employee.FullName);
            command.Parameters.AddWithValue("Username", employee.Username.ToString().Trim());
            command.Parameters.AddWithValue("Password", employee.Password.ToString().Trim());
            command.Parameters.AddWithValue("PhoneNumber", employee.PhoneNumber.ToString().Trim());
            command.Parameters.AddWithValue("Email", employee.Email.ToString().Trim());
            command.Parameters.AddWithValue("ID_Shift", employee.ID_Shift);
            command.Parameters.AddWithValue("ID_Permission", employee.ID_Permission);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        // Sua TK
        public static void UpdateEmployee(string UsernameOld, Employee employee)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = "exec UpdateEmployee @UsernameOld, @FullName, @Username, @Password, @PhoneNumber, @Email, @ID_Shift, @ID_Permission";
            command.Parameters.AddWithValue("UsernameOld", UsernameOld);
            command.Parameters.AddWithValue("FullName", employee.FullName);
            command.Parameters.AddWithValue("Username", employee.Username.ToString().Trim());
            command.Parameters.AddWithValue("Password", employee.Password.ToString().Trim());
            command.Parameters.AddWithValue("PhoneNumber", employee.PhoneNumber.ToString().Trim());
            command.Parameters.AddWithValue("Email", employee.Email.ToString().Trim());
            command.Parameters.AddWithValue("ID_Shift", employee.ID_Shift);
            command.Parameters.AddWithValue("ID_Permission", employee.ID_Permission);
            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static void DeleteEmployee(string username)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec DeleteEmployee @username";
            command.Parameters.AddWithValue("username", username);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }


}
