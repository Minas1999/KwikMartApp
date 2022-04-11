using DataAccess.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Repositoryes
{
    public class OrderRepository : IOrder
    {
        public void CreaetOrder()
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
            cmd.Parameters.Add("@order_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

            cmd.ExecuteReader();

            int a = (int)cmd.Parameters["@order_id"].Value;
            
        }
    }
}
