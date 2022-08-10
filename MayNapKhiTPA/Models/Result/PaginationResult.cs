using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayNapKhiTPA.Models
{
    public class PaginationResult
    {
        //Không chọn tên Machine, không chọn ngày, không chọn chỉ số
        public static int Count_NoName_NoDate_NoParameter()
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = "exec Count_NoName_NoDate_NoParameter";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_NoName_NoDate_NoParameter(int page, int NUM_ELM)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_NoName_NoDate_NoParameter {page}, {NUM_ELM}";

            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                        sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13),sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }


        //--Chọn tên, chọn ngày, chọn chỉ số (3 chỉ số) (NAME_DATE_PARAMETER)
        public static int Count_YesName_YesDate_YesParameter_ApSuat_TheTich_LuuLuong
            (string nameMachine, string time1, string time2, double apsuat1, double apsuat2, double thetich1, double thetich2, double luuluong1, double luuluong2 )
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_YesName_YesDate_YesParameter_ApSuat_TheTich_LuuLuong " +
                $"N'{nameMachine}', '{time1}', '{time2}', {apsuat1}, {apsuat2}, {thetich1}, {thetich2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_YesName_YesDate_YesParameter_ApSuat_TheTich_LuuLuong
            (int page, int NUM_ELM ,string nameMachine, string time1, string time2, double apsuat1, double apsuat2, double thetich1, double thetich2, double luuluong1, double luuluong2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_YesName_YesDate_YesParameter_ApSuat_TheTich_LuuLuong {page}, {NUM_ELM}, " +
                $"N'{nameMachine}', '{time1}', '{time2}', {apsuat1}, {apsuat2}, {thetich1}, {thetich2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                        sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Chọn tên Machine,có chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Thể tích)
        public static int Count_YesName_YesDate_YesParameter_ApSuat_TheTich
    (string nameMachine, string time1, string time2, double apsuat1, double apsuat2, double thetich1, double thetich2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_YesName_YesDate_YesParameter_ApSuat_TheTich " +
                $"N'{nameMachine}', '{time1}', '{time2}', {apsuat1}, {apsuat2}, {thetich1}, {thetich2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_YesName_YesDate_YesParameter_ApSuat_TheTich
    (int page, int NUM_ELM, string nameMachine, string time1, string time2, double apsuat1, double apsuat2, double thetich1, double thetich2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_YesName_YesDate_YesParameter_ApSuat_TheTich {page}, {NUM_ELM}, " +
                $"N'{nameMachine}', '{time1}', '{time2}', {apsuat1}, {apsuat2}, {thetich1}, {thetich2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                       sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                       sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Có chọn tên Machine, có chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Lưu Lượng)
        public static int Count_YesName_YesDate_YesParameter_ApSuat_LuuLuong
            (string nameMachine, string time1, string time2, double apsuat1, double apsuat2, double luuluong1, double luuluong2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_YesName_YesDate_YesParameter_ApSuat_LuuLuong " +
                $"N'{nameMachine}', '{time1}', '{time2}', {apsuat1}, {apsuat2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_YesName_YesDate_YesParameter_ApSuat_LuuLuong
            (int page, int NUM_ELM, string nameMachine, string time1, string time2, double apsuat1, double apsuat2, double luuluong1, double luuluong2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_YesName_YesDate_YesParameter_ApSuat_LuuLuong {page}, {NUM_ELM}, " +
                $"N'{nameMachine}', '{time1}', '{time2}', {apsuat1}, {apsuat2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                       sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                       sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }
        //--Có chọn tên Machine, có chọn ngày, có chọn chỉ số (2 chỉ số (thể tích - lưu lượng))
        public static int Count_YesName_YesDate_YesParameter_TheTich_LuuLuong
            (string nameMachine, string time1, string time2, double thetich1, double thetich2, double luuluong1, double luuluong2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_YesName_YesDate_YesParameter_TheTich_LuuLuong " +
                $"N'{nameMachine}', '{time1}', '{time2}', {thetich1}, {thetich2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_YesName_YesDate_YesParameter_TheTich_LuuLuong
            (int page, int NUM_ELM, string nameMachine, string time1, string time2, double thetich1, double thetich2, double luuluong1, double luuluong2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_YesName_YesDate_YesParameter_TheTich_LuuLuong {page}, {NUM_ELM}, " +
                $"N'{nameMachine}', '{time1}', '{time2}', {thetich1}, {thetich2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                        sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }
        //--Có chọn tên Machine, có chọn ngày, có chọn chỉ số (1 thể tích)
        public static int Count_YesName_YesDate_YesParameter_TheTich
            (string nameMachine, string time1, string time2, double thetich1, double thetich2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_YesName_YesDate_YesParameter_TheTich " +
                $"N'{nameMachine}', '{time1}', '{time2}', {thetich1}, {thetich2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_YesName_YesDate_YesParameter_TheTich
            (int page, int NUM_ELM, string nameMachine, string time1, string time2, double thetich1, double thetich2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_YesName_YesDate_YesParameter_TheTich {page}, {NUM_ELM}, " +
                $"N'{nameMachine}', '{time1}', '{time2}', {thetich1}, {thetich2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                       sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                       sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Có chọn tên Machine, có chọn ngày, có chọn chỉ số (1 - lưu lượng)
        public static int Count_YesName_YesDate_YesParameter_LuuLuong
            (string nameMachine, string time1, string time2, double luuluong1, double luuluong2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_YesName_YesDate_YesParameter_LuuLuong " +
                $"N'{nameMachine}', '{time1}', '{time2}', {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_YesName_YesDate_YesParameter_LuuLuong
            (int page, int NUM_ELM, string nameMachine, string time1, string time2, double luuluong1, double luuluong2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_YesName_YesDate_YesParameter_LuuLuong {page}, {NUM_ELM}, " +
                $"N'{nameMachine}', '{time1}', '{time2}', {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                       sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                       sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //---Có chọn tên Machine, có chọn ngày, có chọn chỉ số (1 chỉ số - Áp suất)
        public static int Count_YesName_YesDate_YesParameter_ApSuat
            (string nameMachine, string time1, string time2, double apsuat1, double apsuat2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_YesName_YesDate_YesParameter_ApSuat " +
                $"N'{nameMachine}', '{time1}', '{time2}', {apsuat1}, {apsuat2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_YesName_YesDate_YesParameter_ApSuat
            (int page, int NUM_ELM, string nameMachine, string time1, string time2, double apsuat1, double apsuat2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_YesName_YesDate_YesParameter_ApSuat {page}, {NUM_ELM}, " +
                $"N'{nameMachine}', '{time1}', '{time2}', {apsuat1}, {apsuat2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                        sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Không chọn tên Machine, có chọn ngày, không chọn chỉ số (DATE)

        public static int Count_NoName_YesDate_NoParameter
            (string time1, string time2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_NoName_YesDate_NoParameter " +
                $"'{time1}', '{time2}'";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_NoName_YesDate_NoParameter
            (int page, int NUM_ELM, string time1, string time2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_NoName_YesDate_NoParameter {page}, {NUM_ELM}, " +
                $"'{time1}', '{time2}'";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                       sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                       sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //---Chọn tên Machine, không chọn ngày, không chọn chỉ số (NAME)
        public static int Count_YesName_NoDate_NoParameter(string nameMachine)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_YesName_NoDate_NoParameter " +
                $"N'{nameMachine}'";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_YesName_NoDate_NoParameter
            (int page, int NUM_ELM, string nameMachine)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_YesName_NoDate_NoParameter {page}, {NUM_ELM}, " +
                $"N'{nameMachine}'";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                        sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (3 chỉ số) 
        public static int Count_NoName_NoDate_YesParameter_ApSuat_TheTich_LuuLuong
            (double apsuat1, double apsuat2, double thetich1, double thetich2, double luuluong1, double luuluong2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_NoName_NoDate_YesParameter_ApSuat_TheTich_LuuLuong " +
                $"{apsuat1}, {apsuat2}, {thetich1}, {thetich2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_NoName_NoDate_YesParameter_ApSuat_TheTich_LuuLuong
            (int page, int NUM_ELM, double apsuat1, double apsuat2, double thetich1, double thetich2, double luuluong1, double luuluong2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_NoName_NoDate_YesParameter_ApSuat_TheTich_LuuLuong {page}, {NUM_ELM}, " +
                $"{apsuat1}, {apsuat2}, {thetich1}, {thetich2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                        sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }


        //---Không chọn tên Machine, không chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Thể tích)
        public static int Count_NoName_NoDate_YesParameter_ApSuat_TheTich
            (double apsuat1, double apsuat2, double thetich1, double thetich2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_NoName_NoDate_YesParameter_ApSuat_TheTich " +
                $"{apsuat1}, {apsuat2}, {thetich1}, {thetich2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_NoName_NoDate_YesParameter_ApSuat_TheTich
            (int page, int NUM_ELM, double apsuat1, double apsuat2, double thetich1, double thetich2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_NoName_NoDate_YesParameter_ApSuat_TheTich {page}, {NUM_ELM}, " +
                $"{apsuat1}, {apsuat2}, {thetich1}, {thetich2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                       sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                       sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Lưu Lượng)

        public static int Count_NoName_NoDate_YesParameter_ApSuat_LuuLuong
            (double apsuat1, double apsuat2, double luuluong1, double luuluong2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_NoName_NoDate_YesParameter_ApSuat_LuuLuong " +
                $"{apsuat1}, {apsuat2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_NoName_NoDate_YesParameter_ApSuat_LuuLuong
            (int page, int NUM_ELM, double apsuat1, double apsuat2, double luuluong1, double luuluong2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_NoName_NoDate_YesParameter_ApSuat_LuuLuong {page}, {NUM_ELM}, " +
                $"{apsuat1}, {apsuat2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                        sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (2 chỉ số (thể tích - lưu lượng))

        public static int Count_NoName_NoDate_YesParameter_TheTich_LuuLuong
            (double thetich1, double thetich2, double luuluong1, double luuluong2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_NoName_NoDate_YesParameter_TheTich_LuuLuong " +
                $"{thetich1}, {thetich2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_NoName_NoDate_YesParameter_TheTich_LuuLuong
            (int page, int NUM_ELM, double thetich1, double thetich2, double luuluong1, double luuluong2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_NoName_NoDate_YesParameter_TheTich_LuuLuong {page}, {NUM_ELM}, " +
                $"{thetich1}, {thetich2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                         sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                         sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (1 thể tích)

        public static int Count_NoName_NoDate_YesParameter_TheTich
            (double thetich1, double thetich2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_NoName_NoDate_YesParameter_TheTich " +
                $"{thetich1}, {thetich2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_NoName_NoDate_YesParameter_TheTich
            (int page, int NUM_ELM, double thetich1, double thetich2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_NoName_NoDate_YesParameter_TheTich {page}, {NUM_ELM}, " +
                $"{thetich1}, {thetich2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                        sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (1 - lưu lượng)

        public static int Count_NoName_NoDate_YesParameter_LuuLuong
            (double luuluong1, double luuluong2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_NoName_NoDate_YesParameter_LuuLuong " +
                $"{luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_NoName_NoDate_YesParameter_LuuLuong
            (int page, int NUM_ELM, double luuluong1, double luuluong2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_NoName_NoDate_YesParameter_LuuLuong {page}, {NUM_ELM}, " +
                $"{luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                         sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                         sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (1 chỉ số - Áp suất)

        public static int Count_NoName_NoDate_YesParameter_ApSuat
            (double apsuat1, double apsuat2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_NoName_NoDate_YesParameter_ApSuat " +
                $"{apsuat1}, {apsuat2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_NoName_NoDate_YesParameter_ApSuat
            (int page, int NUM_ELM, double apsuat1, double apsuat2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_NoName_NoDate_YesParameter_ApSuat {page}, {NUM_ELM}, " +
                $"{apsuat1}, {apsuat2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                        sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Chọn tên, chọn ngày, không chọn chỉ số (NAME_DATE)

        public static int Count_YesName_YesDate_NoParameter
            (string nameMachine, string time1, string time2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_YesName_YesDate_NoParameter " +
                $"N'{nameMachine}', '{time1}', '{time2}'";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_YesName_YesDate_NoParameter
            (int page, int NUM_ELM, string nameMachine, string time1, string time2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_YesName_YesDate_NoParameter {page}, {NUM_ELM}, " +
                $"N'{nameMachine}', '{time1}', '{time2}'";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                          sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                          sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Chọn tên, không chọn ngày, chọn chỉ số (3 chỉ số) (NAME_DATE_PARAMETER)

        public static int Count_YesName_NoDate_YesParameter_ApSuat_TheTich_LuuLuong
            (string nameMachine, double apsuat1, double apsuat2, double thetich1, double thetich2, double luuluong1, double luuluong2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_YesName_NoDate_YesParameter_ApSuat_TheTich_LuuLuong " +
                $"N'{nameMachine}', {apsuat1}, {apsuat2}, {thetich1}, {thetich2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_YesName_NoDate_YesParameter_ApSuat_TheTich_LuuLuong
            (int page, int NUM_ELM, string nameMachine, double apsuat1, double apsuat2, double thetich1, double thetich2, double luuluong1, double luuluong2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_YesName_NoDate_YesParameter_ApSuat_TheTich_LuuLuong {page}, {NUM_ELM}, " +
                $"N'{nameMachine}', {apsuat1}, {apsuat2}, {thetich1}, {thetich2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                       sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                       sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Chọn tên Machine,không chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Thể tích)
        public static int Count_YesName_NoDate_YesParameter_ApSuat_TheTich
           (string nameMachine, double apsuat1, double apsuat2, double thetich1, double thetich2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_YesName_NoDate_YesParameter_ApSuat_TheTich " +
                $"N'{nameMachine}', {apsuat1}, {apsuat2}, {thetich1}, {thetich2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_YesName_NoDate_YesParameter_ApSuat_TheTich
            (int page, int NUM_ELM, string nameMachine, double apsuat1, double apsuat2, double thetich1, double thetich2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_YesName_NoDate_YesParameter_ApSuat_TheTich {page}, {NUM_ELM}, " +
                $"N'{nameMachine}', {apsuat1}, {apsuat2}, {thetich1}, {thetich2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                       sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                       sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Có chọn tên Machine, không chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Lưu Lượng)
        public static int Count_YesName_NoDate_YesParameter_ApSuat_LuuLuong
            (string nameMachine, double apsuat1, double apsuat2, double luuluong1, double luuluong2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_YesName_NoDate_YesParameter_ApSuat_LuuLuong " +
                $"N'{nameMachine}', {apsuat1}, {apsuat2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_YesName_NoDate_YesParameter_ApSuat_LuuLuong
            (int page, int NUM_ELM, string nameMachine, double apsuat1, double apsuat2, double luuluong1, double luuluong2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_YesName_NoDate_YesParameter_ApSuat_LuuLuong {page}, {NUM_ELM}, " +
                $"N'{nameMachine}', {apsuat1}, {apsuat2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                        sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Có chọn tên Machine, không chọn ngày, có chọn chỉ số (2 chỉ số (thể tích - lưu lượng))
        public static int Count_YesName_NoDate_YesParameter_TheTich_LuuLuong
            (string nameMachine, double thetich1, double thetich2, double luuluong1, double luuluong2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_YesName_NoDate_YesParameter_TheTich_LuuLuong " +
                $"N'{nameMachine}',{thetich1}, {thetich2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_YesName_NoDate_YesParameter_TheTich_LuuLuong
            (int page, int NUM_ELM, string nameMachine, double thetich1, double thetich2, double luuluong1, double luuluong2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_YesName_YesDate_YesParameter_ApSuat_TheTich_LuuLuong {page}, {NUM_ELM}, " +
                $"N'{nameMachine}',{thetich1}, {thetich2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                       sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                       sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }


        //--Có chọn tên Machine, không chọn ngày, có chọn chỉ số (1 thể tích)

        public static int Count_YesName_NoDate_YesParameter_TheTich
    (string nameMachine, double thetich1, double thetich2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_YesName_NoDate_YesParameter_TheTich " +
                $"N'{nameMachine}', {thetich1}, {thetich2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_YesName_NoDate_YesParameter_TheTich
            (int page, int NUM_ELM, string nameMachine, double thetich1, double thetich2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_YesName_NoDate_YesParameter_TheTich {page}, {NUM_ELM}, " +
                $"N'{nameMachine}', {thetich1}, {thetich2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                       sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                       sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Có chọn tên Machine, không chọn ngày, có chọn chỉ số (1 - lưu lượng)
        public static int Count_YesName_NoDate_YesParameter_LuuLuong
(string nameMachine, double luuluong1, double luuluong2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_YesName_NoDate_YesParameter_LuuLuong " +
                $"N'{nameMachine}', {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_YesName_NoDate_YesParameter_LuuLuong
            (int page, int NUM_ELM, string nameMachine, double luuluong1, double luuluong2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_YesName_NoDate_YesParameter_LuuLuong {page}, {NUM_ELM}, " +
                $"N'{nameMachine}', {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                      sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                      sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }


        //--Có chọn tên Machine, có chọn ngày, có chọn chỉ số (1 chỉ số - Áp suất)

        public static int Count_YesName_NoDate_YesParameter_ApSuat
(string nameMachine, double apsuat1, double apsuat2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_YesName_NoDate_YesParameter_ApSuat " +
                $"N'{nameMachine}', {apsuat1}, {apsuat2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_YesName_NoDate_YesParameter_ApSuat
            (int page, int NUM_ELM, string nameMachine, double apsuat1, double apsuat2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_YesName_NoDate_YesParameter_ApSuat {page}, {NUM_ELM}, " +
                $"N'{nameMachine}', {apsuat1}, {apsuat2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                      sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                      sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--không chọn tên, chọn ngày, chọn chỉ số (3 chỉ số) (NAME_DATE_PARAMETER)
        public static int Count_NoName_YesDate_YesParameter_ApSuat_TheTich_LuuLuong
            (string time1, string time2, double apsuat1, double apsuat2, double thetich1, double thetich2, double luuluong1, double luuluong2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_NoName_YesDate_YesParameter_ApSuat_TheTich_LuuLuong " +
                $"'{time1}', '{time2}', {apsuat1}, {apsuat2}, {thetich1}, {thetich2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_NoName_YesDate_YesParameter_ApSuat_TheTich_LuuLuong
            (int page, int NUM_ELM, string time1, string time2, double apsuat1, double apsuat2, double thetich1, double thetich2, double luuluong1, double luuluong2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_NoName_YesDate_YesParameter_ApSuat_TheTich_LuuLuong {page}, {NUM_ELM}, " +
                $"'{time1}', '{time2}', {apsuat1}, {apsuat2}, {thetich1}, {thetich2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                       sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                       sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Không chọn tên Machine,có chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Thể tích)

        public static int Count_NoName_YesDate_YesParameter_ApSuat_TheTich
           (string time1, string time2, double apsuat1, double apsuat2, double thetich1, double thetich2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_NoName_YesDate_YesParameter_ApSuat_TheTich " +
                $"'{time1}', '{time2}', {apsuat1}, {apsuat2}, {thetich1}, {thetich2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_NoName_YesDate_YesParameter_ApSuat_TheTich
            (int page, int NUM_ELM, string time1, string time2, double apsuat1, double apsuat2, double thetich1, double thetich2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_NoName_YesDate_YesParameter_ApSuat_TheTich {page}, {NUM_ELM}, " +
                $"'{time1}', '{time2}', {apsuat1}, {apsuat2}, {thetich1}, {thetich2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                      sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                      sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }


        //--Không chọn tên Machine, có chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Lưu Lượng)

        public static int Count_NoName_YesDate_YesParameter_ApSuat_LuuLuong
           (string time1, string time2, double apsuat1, double apsuat2, double luuluong1, double luuluong2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_NoName_YesDate_YesParameter_ApSuat_LuuLuong " +
                $"'{time1}', '{time2}', {apsuat1}, {apsuat2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_NoName_YesDate_YesParameter_ApSuat_LuuLuong
            (int page, int NUM_ELM, string time1, string time2, double apsuat1, double apsuat2, double luuluong1, double luuluong2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_NoName_YesDate_YesParameter_ApSuat_LuuLuong {page}, {NUM_ELM}, " +
                $"'{time1}', '{time2}', {apsuat1}, {apsuat2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                       sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                       sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Không chọn tên Machine, có chọn ngày, có chọn chỉ số (2 chỉ số (thể tích - lưu lượng))

        public static int Count_NoName_YesDate_YesParameter_TheTich_LuuLuong
           (string time1, string time2, double thetich1, double thetich2, double luuluong1, double luuluong2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_NoName_YesDate_YesParameter_TheTich_LuuLuong " +
                $"'{time1}', '{time2}', {thetich1}, {thetich2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_NoName_YesDate_YesParameter_TheTich_LuuLuong
            (int page, int NUM_ELM, string time1, string time2, double thetich1, double thetich2, double luuluong1, double luuluong2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_NoName_YesDate_YesParameter_TheTich_LuuLuong {page}, {NUM_ELM}, " +
                $"'{time1}', '{time2}', {thetich1}, {thetich2}, {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                       sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                       sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Không chọn tên Machine, có chọn ngày, có chọn chỉ số (1 thể tích)

        public static int Count_NoName_YesDate_YesParameter_TheTich
           (string time1, string time2, double thetich1, double thetich2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_NoName_YesDate_YesParameter_TheTich " +
                $"'{time1}', '{time2}', {thetich1}, {thetich2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_NoName_YesDate_YesParameter_TheTich
            (int page, int NUM_ELM, string time1, string time2, double thetich1, double thetich2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_NoName_YesDate_YesParameter_TheTich {page}, {NUM_ELM}, " +
                $"'{time1}', '{time2}', {thetich1}, {thetich2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                        sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Không chọn tên Machine, có chọn ngày, có chọn chỉ số (1 - lưu lượng)
        public static int Count_NoName_YesDate_YesParameter_LuuLuong
    (string time1, string time2, double luuluong1, double luuluong2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_NoName_YesDate_YesParameter_LuuLuong " +
                $"'{time1}', '{time2}', {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_NoName_YesDate_YesParameter_LuuLuong
            (int page, int NUM_ELM, string time1, string time2, double luuluong1, double luuluong2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_NoName_YesDate_YesParameter_LuuLuong {page}, {NUM_ELM}, " +
                $"'{time1}', '{time2}', {luuluong1}, {luuluong2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                       sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                       sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        //--Không chọn tên Machine, có chọn ngày, có chọn chỉ số (1 chỉ số - Áp suất)
        public static int Count_NoName_YesDate_YesParameter_ApSuat
(string time1, string time2, double apsuat1, double apsuat2)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec Count_NoName_YesDate_YesParameter_ApSuat " +
                $"'{time1}', '{time2}', {apsuat1}, {apsuat2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Result> Pagination_NoName_YesDate_YesParameter_ApSuat
            (int page, int NUM_ELM, string time1, string time2, double apsuat1, double apsuat2)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_NoName_YesDate_YesParameter_ApSuat {page}, {NUM_ELM}, " +
                $"'{time1}', '{time2}', {apsuat1}, {apsuat2}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetDouble(1), sqlDataReader.GetDouble(2),
                       sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetDouble(6), sqlDataReader.GetDouble(7),
                       sqlDataReader.GetDouble(8), sqlDataReader.GetDouble(9), sqlDataReader.GetDateTime(10), sqlDataReader.GetDateTime(11), sqlDataReader.GetString(12), sqlDataReader.GetString(13), sqlDataReader.GetBoolean(14));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

    }
}
