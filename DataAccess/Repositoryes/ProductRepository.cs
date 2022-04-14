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
        public void AddProductsToBasket(Products product, int count)
        {
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "[dbo].[StoreProductsToUserBasket1]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("user_id", 1);
                cmd.Parameters.AddWithValue("food_id", product.food_id);
                cmd.Parameters.AddWithValue("food_name", product.name);
                cmd.Parameters.AddWithValue("food_price", product.price);
                cmd.Parameters.AddWithValue("food_desc", product.description);
                cmd.Parameters.AddWithValue("food_ctg_id", 1);
                cmd.Parameters.AddWithValue("food_cmp_id", 2);
                cmd.Parameters.AddWithValue("food_img", product.img_url);
                cmd.Parameters.AddWithValue("product_count", count);

                cmd.ExecuteReader();
            }
        }

        public List<Products> GetAllProducts()
        {
            List<Products> productsList = new();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "[dbo].[GetAllProducts]";
                cmd.CommandType = CommandType.StoredProcedure;

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productsList.Add(new Products()
                        {
                            food_id = reader.GetInt32(reader.GetOrdinal("food_id")),
                            name = reader.GetString(reader.GetOrdinal("food_name")),
                            price = reader.GetInt32(reader.GetOrdinal("food_price")),
                            description = reader.GetString(reader.GetOrdinal("food_desc")),
                            img_url = reader.GetString(reader.GetOrdinal("food_img_url"))
                        });
                    }
                }
            }
            return productsList;
        }


        public Products GetProductByID(int food_ID)
        {
            Products product = new();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "[dbo].[GetFoodByFoodID]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("food_id", food_ID);

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        product.food_id = reader.GetInt32(reader.GetOrdinal("food_id"));
                        product.name = reader.GetString(reader.GetOrdinal("food_name"));
                        product.price = reader.GetInt32(reader.GetOrdinal("food_price"));
                        product.description = reader.GetString(reader.GetOrdinal("food_desc"));
                        product.img_url = reader.GetString(reader.GetOrdinal("food_img_url"));

                    }
                }
            }
            return product;
        }

        public List<Products> GetProductsToBasket()
        {
            List<Products> productsList = new();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "[dbo].[GetUserProductsFromBasket]";
                cmd.CommandType = CommandType.StoredProcedure;

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productsList.Add(new Products()
                        {
                            food_id = reader.GetInt32(reader.GetOrdinal("food_id")),
                            name = reader.GetString(reader.GetOrdinal("food_name")),
                            price = reader.GetInt32(reader.GetOrdinal("food_price")),
                            description = reader.GetString(reader.GetOrdinal("food_desc")),
                            img_url = reader.GetString(reader.GetOrdinal("food_img_url")),
                            count = reader.GetInt32(reader.GetOrdinal("product_count")),
                        });
                    }
                }
            }
            return productsList;
        }

        public void ClearProductsFromBasket()
        {
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "TRUNCATE TABLE UserBasket";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();
            }
        }

        public List<Products> GetProductsByCategoryes(int id)
        {
            List<Products> productsList = new();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "[dbo].[GetProductsByCategoryes]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", id);

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productsList.Add(new Products { 
                            food_id = reader.GetInt32("food_id"),
                            name = reader.GetString("food_name"),
                            price = reader.GetInt32("food_price"),
                            img_url = reader.GetString("food_img_url")
                        });
                    }
                }
            }
            return productsList;
        }
    }
}
