using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserStore : IUserStore<User>, IUserPasswordStore<User>
    {
        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[AddUsers]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = user.Name.Trim();
                    cmd.Parameters.Add("@normName", SqlDbType.VarChar).Value = user.NormalizedName.Trim();
                    cmd.Parameters.Add("@phone_number", SqlDbType.VarChar).Value = user.Phone_number.Trim();
                    cmd.Parameters.Add("@gmail", SqlDbType.VarChar).Value = user.Gmail.Trim();
                    cmd.Parameters.Add("@normGmail", SqlDbType.VarChar).Value = user.NormalizedGmail.Trim();
                    cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = user.Address.Trim();
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = user.Password;
                    cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = user.Status;

                    await cmd.ExecuteNonQueryAsync();
                    return IdentityResult.Success;
                }
            }
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[GetUserById]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Convert.ToInt32(userId);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.SingleRow))
                    {
                        if (await reader.ReadAsync())
                        {

                            if (reader.Read())
                            {
                                return new User(){
                                    Id = reader.GetInt32(reader.GetOrdinal("user_id")),
                                    Name = reader.GetString(reader.GetOrdinal("user_name")),
                                    NormalizedName = reader.GetString(reader.GetOrdinal("user_norm_name")),
                                    Phone_number = reader.GetString(reader.GetOrdinal("user_pNumber")),
                                    Gmail = reader.GetString(reader.GetOrdinal("user_gmail")),
                                    NormalizedGmail = reader.GetString(reader.GetOrdinal("user_norm_gmail")),
                                    Password = reader.GetString(reader.GetOrdinal("user_password")),
                                    Address = reader.GetString(reader.GetOrdinal("user_address"))
                                };
                            }
                        }
                    }
                }
            }
            return null;
        }

        public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[sp_GetUserByName]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NORM_NAME", SqlDbType.VarChar).Value = normalizedUserName;

                    using SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.SingleRow);

                    if (await reader.ReadAsync())
                    {
                        return new User()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("user_id")),
                            Name = reader.GetString(reader.GetOrdinal("user_name")),
                            NormalizedName = reader.GetString(reader.GetOrdinal("user_norm_name")),
                            Phone_number = reader.GetString(reader.GetOrdinal("user_pNumber")),
                            Gmail = reader.GetString(reader.GetOrdinal("user_gmail")),
                            NormalizedGmail = reader.GetString(reader.GetOrdinal("user_norm_gmail")),
                            Password = reader.GetString(reader.GetOrdinal("user_password")),
                            Address = reader.GetString(reader.GetOrdinal("user_address"))
                        };

                    }

                }
            }
            return null;
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedName);
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password);
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Name);
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.Password));
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            user.Password = passwordHash;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            user.Name = userName;
            return Task.CompletedTask;
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
