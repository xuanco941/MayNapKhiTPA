using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayNapKhiTPA.Models
{
    internal class GroupBusiness
    {
        public static List<Group> GetAllGroups()
        {
            List<Group> list = new List<Group>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = "select * from [Group]";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Group group = new Group(sqlDataReader.GetInt32(0),sqlDataReader.GetString(1),sqlDataReader.GetBoolean(2),sqlDataReader.GetBoolean(3));
                list.Add(group);
            }
            sqlConnection.Close();
            return list;
        }


        public static Group GetGroupFromID(int ID_Group)
        {
            Group group = new Group();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"GetGroupFromID {ID_Group}";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                group.ID_Group = sqlDataReader.GetInt32(0);
                group.Name = sqlDataReader.GetString(1);
                group.IsManagementSetting = sqlDataReader.GetBoolean(2);
                group.IsManagementUser = sqlDataReader.GetBoolean(3);
            }
            sqlConnection.Close();
            return group;
        }
        //Tìm kiếm group bằng tên
        public static List<Group> FindGroupByName(string name)
        {
            List<Group> list = new List<Group>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"FindGroupByName '{name}'";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Group group = new Group(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetBoolean(2), sqlDataReader.GetBoolean(3));
                list.Add(group);
            }
            sqlConnection.Close();
            return list;
        }

        public static Group GetGroupByName(string name)
        {
            Group group = null;
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"GetGroupByName '{name}'";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                group = new Group(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetBoolean(2), sqlDataReader.GetBoolean(3));
            }
            sqlConnection.Close();
            return group;
        }



        // Them Ca làm
        public static void AddGroup(Group group)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec AddGroup @Name, @IsManagementSetting, @IsManagementUser";
            command.Parameters.AddWithValue("Name", group.Name);
            command.Parameters.AddWithValue("IsManagementSetting", group.IsManagementSetting);
            command.Parameters.AddWithValue("IsManagementUser", group.IsManagementUser);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        // Sua TK
        public static void UpdateGroup(int ID_Group, string Name, bool IsManagementSetting, bool IsManagementUser)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = "exec UpdateGroup @ID_Group, @Name, @IsManagementSetting, @IsManagementUser";

            command.Parameters.AddWithValue("ID_Group", ID_Group);
            command.Parameters.AddWithValue("Name", Name);
            command.Parameters.AddWithValue("IsManagementSetting", IsManagementSetting);
            command.Parameters.AddWithValue("IsManagementUser", IsManagementUser);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static void DeleteGroup(int ID_Group)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec DeleteGroup @ID_Group";
            command.Parameters.AddWithValue("ID_Group", ID_Group);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
