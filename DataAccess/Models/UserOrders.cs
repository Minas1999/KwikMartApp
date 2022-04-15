using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class UserOrders
    {
        public int orderID { get; set; }
        public DateTime orderDate { get; set; }
        public int totalAmount {get; set; }

        public UserOrders()
        {

        }
    }
}
