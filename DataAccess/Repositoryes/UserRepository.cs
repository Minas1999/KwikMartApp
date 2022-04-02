﻿using System;
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
    }
}