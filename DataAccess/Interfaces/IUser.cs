using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IUser
    {
        public Task<User> GetUser();

        public List<UserOrders> GetUserOrders();
    }
}
