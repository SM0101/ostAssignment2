using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OstadAssignment2.Models
{
    public class LoginUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool ValidateUser(string userName, string password)
        {
            string conn = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@UserName", userName);
            sqlCommand.Parameters.AddWithValue("@Password", password);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UserName = reader["UserName"].ToString();
                    Password = reader["Password"].ToString();
                }
              
                return true;
            }
            return false;
        }

        public bool ValidateUserExist(string userName)
        {
            string conn = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Users WHERE UserName = @UserName", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@UserName", userName);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                UserName = reader["UserName"].ToString();
                            }

                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void UpdatePassword(string userName, string newPassword)
        {
            string conn = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Users SET PASSWORD = @Password WHERE UserName = @UserName", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@UserName", userName);
                    sqlCommand.Parameters.AddWithValue("@Password", newPassword);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

    }
}