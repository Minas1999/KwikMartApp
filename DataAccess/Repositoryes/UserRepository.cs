using DataAccess.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserRepository : IUser
    {
        public Task<User> GetUser()
        {
            User user = null;
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[Get]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.HasRows)
                        {
                            user = new User();
                            if (reader.Read())
                            {
                                user.Id = reader.GetInt32(reader.GetOrdinal("user_id"));
                                user.Name = reader.GetString(reader.GetOrdinal("user_name"));
                                user.Phone_number = reader.GetString(reader.GetOrdinal("user_pNumber"));
                                user.Gmail = reader.GetString(reader.GetOrdinal("user_gmail"));
                                user.Password = reader.GetString(reader.GetOrdinal("user_password"));
                                user.Address = reader.GetString(reader.GetOrdinal("user_address"));
                            }
                        }
                    }
                }
            }
            return Task.FromResult(user);
        }

        public User LoginUser(string userGmail, string password)
        {
            User user = null;
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[UserLogin]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("usergmail", userGmail);
                    cmd.Parameters.AddWithValue("userpassword", password);

                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.HasRows)
                        {
                            user = new User();
                            if (reader.Read())
                            {
                                user.Id = reader.GetInt32(reader.GetOrdinal("user_id"));
                                user.Name = reader.GetString(reader.GetOrdinal("user_name"));
                                user.Phone_number = reader.GetString(reader.GetOrdinal("user_pNumber"));
                                user.Gmail = reader.GetString(reader.GetOrdinal("user_gmail"));
                                user.Password = reader.GetString(reader.GetOrdinal("user_password"));
                                user.Address = reader.GetString(reader.GetOrdinal("user_address"));
                            }
                        }
                    }
                }
            }
            return user;
        }

        public List<UserOrders> GetUserOrders(int userID)
        {
            List<UserOrders> userOrders = new();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "[dbo].[GetAllOrders]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("userID", userID);

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userOrders.Add(new UserOrders()
                        {
                            orderID = reader.GetInt32("ord_id"),
                            orderDate = reader.GetDateTime("ord_date"),
                            totalAmount = reader.GetInt32("ord_ttl_amount")
                        });
                    }
                }
            }
            return userOrders;
        }

        public bool Registration(string username, string userPhoneNumber, string userGmail, string useraddres, string password)
        {
            User user = null;
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new ())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[registration]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("userphone", userPhoneNumber);
                    cmd.Parameters.AddWithValue("usergmail", userGmail);
                    cmd.Parameters.AddWithValue("useraddress", useraddres);
                    cmd.Parameters.AddWithValue("userpassword", password);
                    cmd.ExecuteReader(CommandBehavior.SingleRow);
                }
            }
            return true;
        }
    }
}
