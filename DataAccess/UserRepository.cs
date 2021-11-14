using System;
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
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.HasRows)
                        {
                            user = new User();
                            if (reader.Read())
                            {
                                user.id = reader.GetInt32(reader.GetOrdinal("user_id"));
                                user.name = reader.GetString(reader.GetOrdinal("user_name"));
                                user.phone_number = reader.GetString(reader.GetOrdinal("user_pNumber"));
                                user.gmail = reader.GetString(reader.GetOrdinal("user_gmail"));
                                user.password = reader.GetString(reader.GetOrdinal("user_password"));
                                user.address = reader.GetString(reader.GetOrdinal("user_address"));
                            }
                        }
                    }
                }
            }
            return Task.FromResult(user);
        }
    }
}
