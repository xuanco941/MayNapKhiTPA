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
                Group group = new Group(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetBoolean(2), sqlDataReader.GetBoolean(3), sqlDataReader.GetBoolean(4), sqlDataReader.GetBoolean(5), sqlDataReader.GetBoolean(6), sqlDataReader.GetBoolean(7), sqlDataReader.GetBoolean(8), sqlDataReader.GetBoolean(9), sqlDataReader.GetBoolean(10), sqlDataReader.GetBoolean(11));
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
            string sql = $"exec GetGroupFromID {ID_Group}";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                group = new Group(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetBoolean(2), sqlDataReader.GetBoolean(3), sqlDataReader.GetBoolean(4), sqlDataReader.GetBoolean(5), sqlDataReader.GetBoolean(6), sqlDataReader.GetBoolean(7), sqlDataReader.GetBoolean(8), sqlDataReader.GetBoolean(9), sqlDataReader.GetBoolean(10), sqlDataReader.GetBoolean(11));

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
            string sql = $"exec FindGroupByName N'{name}'";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Group group = new Group(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetBoolean(2), sqlDataReader.GetBoolean(3), sqlDataReader.GetBoolean(4), sqlDataReader.GetBoolean(5), sqlDataReader.GetBoolean(6), sqlDataReader.GetBoolean(7), sqlDataReader.GetBoolean(8), sqlDataReader.GetBoolean(9), sqlDataReader.GetBoolean(10), sqlDataReader.GetBoolean(11));
                list.Add(group);
            }
            sqlConnection.Close();
            return list;
        }

        public static Group GetGroupFromName(string name)
        {
            Group group = null;
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec GetGroupFromName N'{name}'";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                group = new Group(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetBoolean(2), sqlDataReader.GetBoolean(3), sqlDataReader.GetBoolean(4), sqlDataReader.GetBoolean(5), sqlDataReader.GetBoolean(6), sqlDataReader.GetBoolean(7), sqlDataReader.GetBoolean(8), sqlDataReader.GetBoolean(9), sqlDataReader.GetBoolean(10), sqlDataReader.GetBoolean(11));
            }
            sqlConnection.Close();
            return group;
        }

        // Them nhóm quyền
        public static void AddGroup(Group group)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec AddGroup @Name, @IsManagementUser, @IsManagementGroup, @IsControlMachine,@IsSettingMachine,@IsSettingShift,@IsSettingTemplateMachine,@IsViewResult,@IsViewActivity,@IsDeleteResult,@IsDeleteActivity";
            command.Parameters.AddWithValue("Name", group.Name);
            command.Parameters.AddWithValue("IsManagementUser", group.IsManagementUser);
            command.Parameters.AddWithValue("IsManagementGroup", group.IsManagementGroup);
            command.Parameters.AddWithValue("IsControlMachine", group.IsControlMachine);
            command.Parameters.AddWithValue("IsSettingMachine", group.IsSettingMachine);
            command.Parameters.AddWithValue("IsSettingShift", group.IsSettingShift);
            command.Parameters.AddWithValue("IsSettingTemplateMachine", group.IsSettingTemplateMachine);
            command.Parameters.AddWithValue("IsViewResult", group.IsViewResult);
            command.Parameters.AddWithValue("IsViewActivity", group.IsViewActivity);
            command.Parameters.AddWithValue("IsDeleteResult", group.IsDeleteResult);
            command.Parameters.AddWithValue("IsDeleteActivity", group.IsDeleteActivity);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        // Sua group
        public static void UpdateGroup(int ID_Group, string Name, bool IsManagementUser, bool IsManagementGroup, bool IsControlMachine, bool IsSettingMachine,
            bool IsSettingShift, bool IsSettingTemplateMachine, bool IsViewResult, bool IsViewActivity, bool IsDeleteResult, bool IsDeleteActivity)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = "exec UpdateGroup @ID_Group, @Name, @IsManagementUser, @IsManagementGroup, @IsControlMachine,@IsSettingMachine,@IsSettingShift,@IsSettingTemplateMachine,@IsViewResult,@IsViewActivity,@IsDeleteResult,@IsDeleteActivity";

            command.Parameters.AddWithValue("ID_Group", ID_Group);
            command.Parameters.AddWithValue("Name", Name);
            command.Parameters.AddWithValue("IsManagementUser", IsManagementUser);
            command.Parameters.AddWithValue("IsManagementGroup", IsManagementGroup);
            command.Parameters.AddWithValue("IsControlMachine", IsControlMachine);
            command.Parameters.AddWithValue("IsSettingMachine", IsSettingMachine);
            command.Parameters.AddWithValue("IsSettingShift", IsSettingShift);
            command.Parameters.AddWithValue("IsSettingTemplateMachine", IsSettingTemplateMachine);
            command.Parameters.AddWithValue("IsViewResult", IsViewResult);
            command.Parameters.AddWithValue("IsViewActivity", IsViewActivity);
            command.Parameters.AddWithValue("IsDeleteResult", IsDeleteResult);
            command.Parameters.AddWithValue("IsDeleteActivity", IsDeleteActivity);

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
