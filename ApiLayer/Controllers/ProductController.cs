using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace ApiLayer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct product;

        public ProductController(IProduct product)
        {
            this.product = product;
        }

        [HttpGet("GetAllProducts")]
        public List<Products> GetAllProducts()
        {
            return product.GetAllProducts();
        }


        [HttpGet("ID")]
        public Products GetProdyctByID(int productID)
        {
            return product.GetProductByID(productID);
        }

        [HttpGet("User/Basket")]
        public List<Products> GetProductsFromUserBasket()
        {
            return product.GetProductsToBasket(1);
        }
    }
}
