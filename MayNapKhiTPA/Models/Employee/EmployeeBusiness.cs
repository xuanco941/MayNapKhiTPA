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
            if (sqlDataReader.Read() && sqlDataReader.GetString(3).Trim() == password.ToString().Trim())
            {
                int _ID = sqlDataReader.GetInt32(0);
                string _FullName = sqlDataReader.GetString(1);
                //employee.ID = _ID;
                //employee.FullName = _FullName;
                //bool _IsAdmin = sqlDataReader.GetBoolean(4);
                //employee.IsAdmin = _IsAdmin;
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
                Employee employee = new Employee((int)sqlDataReader["Employee_ID"], (string)sqlDataReader["Employee_FullName"],
                    (string)sqlDataReader["Employee_Username"], (string)sqlDataReader["Employee_Password"], (string)sqlDataReader["Employee_Department"], (bool)sqlDataReader["Employee_IsAdmin"]);
                list.Add(employee);
            }
            sqlConnection.Close();
            return list;
        }



        // Them TK
        public static bool AddEmployee(Employee employee)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec AddEmployee @FullName, @Username, @Password,@Department, @IsAdmin";
            var FullName = command.Parameters.AddWithValue("FullName", employee.FullName);
            var Username = command.Parameters.AddWithValue("Username", employee.Username.ToString().Trim());
            var Password = command.Parameters.AddWithValue("Password", employee.Password.ToString().Trim());
            var Department = command.Parameters.AddWithValue("Department", employee.Department);
            var IsAdmin = command.Parameters.AddWithValue("IsAdmin", employee.IsAdmin);
            command.Connection = sqlConnection;

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        // Sua TK
        public static bool UpdateEmployee(string UsernameOld, Employee employee)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = "exec UpdateEmployee @UsernameOld, @FullName, @Username, @Password, @Department, @IsAdmin";
            command.Parameters.AddWithValue("UsernameOld", UsernameOld);
            command.Parameters.AddWithValue("FullName", employee.FullName);
            command.Parameters.AddWithValue("Username", employee.Username.ToString().Trim());
            command.Parameters.AddWithValue("Password", employee.Password.ToString().Trim());
            command.Parameters.AddWithValue("Department", employee.Department);
            command.Parameters.AddWithValue("IsAdmin", employee.IsAdmin);
            command.Connection = sqlConnection;

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static bool DeleteEmployee(string username)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec DeleteEmployee @username";
            command.Parameters.AddWithValue("username", username);

            command.Connection = sqlConnection;

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }


}
