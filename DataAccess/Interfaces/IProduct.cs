using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    interface IProduct
    {
        public List<Products> GetAllProducts();
        public Products GetProductByID(int foodID);
        public void AddProductsToBasket(Products basketProducts, int count);
        public List<Products> GetProductsToBasket();
    }
}
