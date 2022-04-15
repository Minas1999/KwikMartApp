using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IDepartment
    {
        public Task<List<Department>> GetDepartments();
        public Task<List<Category>> GetCategoryesByDepartmentId(int id);
    }
}
