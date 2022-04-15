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
    public class DepartmentRepository : IDepartment
    {
        public async Task<List<Department>> GetDepartments()
        {
            List<Department> productsList = new();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "[dbo].[getAllDepartment]";
                cmd.CommandType = CommandType.StoredProcedure;

                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productsList.Add(new Department()
                        {
                            departmentID = reader.GetInt32("department_id"),
                            departmentName = reader.GetString("department_name"),
                            departmentImage = reader.GetString("department_img")
                        });
                    }
                }
            }
            return productsList;
        }


        public async Task<List<Category>> GetCategoryesByDepartmentId(int departmentID)
        {
            List<Category> categoryesList = new();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using SqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = "[dbo].[GetCategoryesByDepartmentID]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", departmentID);

                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        categoryesList.Add(new Category()
                        {
                            deparmtentID = reader.GetInt32("department_id"),
                            categoryName = reader.GetString("category_name"),
                            departmentName = reader.GetString("department_name"),
                            departmentImage = reader.GetString("department_img")
                        });
                    }
                }
            }
            return categoryesList;
        }
    }
}
