using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositoryes
{
    public class ProductRepository : IProduct
    {
        public Task<Products> GetAllProducts()
        {
            List<Products> productsList;
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
                            productsList = new();
                            if (reader.Read())
                            {
                                productsList.Add(new Products()
                                {
                                    food_id = reader.GetInt32(reader.GetOrdinal("food_id")),
                                    name = reader.GetString(reader.GetOrdinal("name")),

                                });
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
