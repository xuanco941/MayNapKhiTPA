using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayNapKhiTPA.Models
{
    internal class PermissionBusiness
    {
        public static List<Permission> GetAllPermissions()
        {
            List<Permission> list = new List<Permission>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = "select * from Permission";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Permission permission = new Permission(sqlDataReader.GetInt32(0),sqlDataReader.GetBoolean(1),sqlDataReader.GetBoolean(2));
                list.Add(permission);
            }
            sqlConnection.Close();
            return list;
        }



        // Them Ca làm
        public static void AddPermission(Permission permission)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec AddPermission @Name, @IsManagementSetting, @IsManagementEmployee";
            command.Parameters.AddWithValue("Name", permission.Name);
            command.Parameters.AddWithValue("IsManagementSetting", permission.IsManagementSetting);
            command.Parameters.AddWithValue("IsManagementEmployee", permission.IsManagementEmployee);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        // Sua TK
        public static void UpdatePermission(int ID_Permission, string Name, bool IsManagementSetting, bool IsManagementEmployee)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = "exec UpdatePermission @ID_Permission, @Name, @IsManagementSetting, @IsManagementEmployee";

            command.Parameters.AddWithValue("ID_Permission", ID_Permission);
            command.Parameters.AddWithValue("Name", Name);
            command.Parameters.AddWithValue("IsManagementSetting", IsManagementSetting);
            command.Parameters.AddWithValue("IsManagementEmployee", IsManagementEmployee);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static void DeleteShift(int ID_Permission)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec DeletePermission @ID_Permission";
            command.Parameters.AddWithValue("ID_Permission", ID_Permission);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
