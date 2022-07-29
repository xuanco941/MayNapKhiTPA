﻿using System.Collections.Generic;
using System.Data.SqlClient;
using MayNapKhiTPA;
namespace MayNapKhiTPA.Models
{

    public class UserBusiness
    {
        public static User AuthLogin(string username, string password)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            //Dung procedure co san tren db
            string sql = $"exec FindUserByUsername '{username.ToString().Trim()}'";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();

            if (sqlDataReader.Read() && ((string)sqlDataReader["Password"]).Trim() == password.ToString().Trim())
            {
                User user = new User((int)sqlDataReader["ID_User"], (string)sqlDataReader["FullName"],
                    (string)sqlDataReader["Username"], (string)sqlDataReader["Password"], (string)sqlDataReader["PhoneNumber"],
                    (string)sqlDataReader["Email"], (string)sqlDataReader["NameShift"], (int)sqlDataReader["ID_Group"]);
                sqlConnection.Close();
                return user;
            }
            else
            {
                sqlConnection.Close();
                return null;
            }
        }

        public static List<User> GetAllUsers()
        {
            List<User> list = new List<User>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = "select * from [User]";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                User user = new User((int)sqlDataReader["ID_User"], (string)sqlDataReader["FullName"],
                   (string)sqlDataReader["Username"], (string)sqlDataReader["Password"], (string)sqlDataReader["PhoneNumber"],
                   (string)sqlDataReader["Email"], (string)sqlDataReader["NameShift"], (int)sqlDataReader["ID_Group"]);
                list.Add(user);
            }
            sqlConnection.Close();
            return list;
        }

        public static List<User> FindUserByFullNameOrUsername(string name)
        {
            List<User> list = new List<User>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"FindUserByFullNameOrUsername '{name}'";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                User user = new User((int)sqlDataReader["ID_User"], (string)sqlDataReader["FullName"],
                    (string)sqlDataReader["Username"], (string)sqlDataReader["Password"], (string)sqlDataReader["PhoneNumber"],
                    (string)sqlDataReader["Email"], (string)sqlDataReader["NameShift"], (int)sqlDataReader["ID_Group"]);
                list.Add(user);
            }
            sqlConnection.Close();
            return list;
        }


        public static User GetUserFromID(int ID_User)
        {
            User user = null;
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"GetUserFromID {ID_User}";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                user = new User((int)sqlDataReader["ID_User"], (string)sqlDataReader["FullName"],
                        (string)sqlDataReader["Username"], (string)sqlDataReader["Password"], (string)sqlDataReader["PhoneNumber"],
                        (string)sqlDataReader["Email"], (string)sqlDataReader["NameShift"], (int)sqlDataReader["ID_Group"]);
            }
            sqlConnection.Close();
            return user;
        }

        public static User GetUserFromFullName(string fullname)
        {
            User user = null;
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"GetUserFromFullName N'{fullname}'";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                user = new User((int)sqlDataReader["ID_User"], (string)sqlDataReader["FullName"],
                        (string)sqlDataReader["Username"], (string)sqlDataReader["Password"], (string)sqlDataReader["PhoneNumber"],
                        (string)sqlDataReader["Email"], (string)sqlDataReader["NameShift"], (int)sqlDataReader["ID_Group"]);
            }
            sqlConnection.Close();
            return user;
        }

        public static User GetUserFromUserName(string username)
        {
            User user = null;
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"GetUserFromUserName N'{username}'";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                user = new User((int)sqlDataReader["ID_User"], (string)sqlDataReader["FullName"],
                        (string)sqlDataReader["Username"], (string)sqlDataReader["Password"], (string)sqlDataReader["PhoneNumber"],
                        (string)sqlDataReader["Email"], (string)sqlDataReader["NameShift"], (int)sqlDataReader["ID_Group"]);
            }
            sqlConnection.Close();
            return user;
        }





        // Them TK
        public static void AddUser(User user)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec AddUser @FullName, @Username, @Password,@PhoneNumber, @Email, @NameShift, @ID_Group";
            command.Parameters.AddWithValue("FullName", user.FullName);
            command.Parameters.AddWithValue("Username", user.Username.ToString().Trim());
            command.Parameters.AddWithValue("Password", user.Password.ToString().Trim());
            command.Parameters.AddWithValue("PhoneNumber", user.PhoneNumber.ToString().Trim());
            command.Parameters.AddWithValue("Email", user.Email.ToString().Trim());
            command.Parameters.AddWithValue("NameShift", user.NameShift);
            command.Parameters.AddWithValue("ID_Group", user.ID_Group);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        // Sua TK
        public static void UpdateUser(string UsernameOld, User user)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = "exec UpdateUser @UsernameOld, @FullName, @Username, @Password, @PhoneNumber, @Email, @NameShift, @ID_Group";
            command.Parameters.AddWithValue("UsernameOld", UsernameOld);
            command.Parameters.AddWithValue("FullName", user.FullName);
            command.Parameters.AddWithValue("Username", user.Username.ToString().Trim());
            command.Parameters.AddWithValue("Password", user.Password.ToString().Trim());
            command.Parameters.AddWithValue("PhoneNumber", user.PhoneNumber.ToString().Trim());
            command.Parameters.AddWithValue("Email", user.Email.ToString().Trim());
            command.Parameters.AddWithValue("NameShift", user.NameShift);
            command.Parameters.AddWithValue("ID_Group", user.ID_Group);
            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static void DeleteUser(string username)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec DeleteUser @username";
            command.Parameters.AddWithValue("username", username);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }


}
