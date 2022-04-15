using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccess.Repositoryes
{
    public class OrderRepository : IOrder
    {
        public int CreaetOrder()
        {
            using var conn = ConnectionManager.CreateConnection();
            conn.Open();
            using var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "[dbo].[CreateOrder]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ord_date", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            cmd.Parameters.AddWithValue("order_time", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            cmd.Parameters.AddWithValue("summa", 2200);
            cmd.Parameters.AddWithValue("order_userID", 1);

            var returnParameter = cmd.Parameters.Add("@orderID", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteReader();

            return (int)returnParameter.Value;
        }

        public void CreateUserOrderFoodsTable(int order, int food_id, int count)
        {
            using var conn = ConnectionManager.CreateConnection();
            conn.Open();
            using var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "[dbo].[CreateUserOrderFoodsTable]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("order_id", order);
            cmd.Parameters.AddWithValue("food_id", food_id);
            cmd.Parameters.AddWithValue("products_count", count);
            cmd.ExecuteReader();
        }
    }
}
