using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IOrder
    {
        public int CreaetOrder(int userID);

        public void CreateUserOrderFoodsTable(int order, int food_id, int count);
    }
}
