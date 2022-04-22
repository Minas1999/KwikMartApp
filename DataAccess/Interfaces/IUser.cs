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
        public User LoginUser(string userGmail, string password);
        public bool Registration(string username, string userPhoneNumber, string userGmail, string useraddres, string password);

        public List<UserOrders> GetUserOrders(int userID);
    }
}
