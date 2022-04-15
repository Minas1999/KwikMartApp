using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartment department;
        public DepartmentController(IDepartment department)
        {
            this.department = department;
        }


        [HttpGet("Departments")]
        public async Task<List<Department>> GetAllProducts()
        {
            return await department.GetDepartments();
        }


        [HttpGet("Category/id")]
        public async Task<List<Category>> GetCategoryesByDepartmentId(int id)
        {
            return await department.GetCategoryesByDepartmentId(id);
        }

    }
}
