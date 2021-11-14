using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUser v;

        public ValuesController(IUser v)
        {
            this.v = v;
        }

/*        [HttpGet]
        public IActionResult GetUsers()
        {
             return Ok(v.GetUser());
        }*/

        [HttpGet]
        public async Task<User> GetUsers()
        {
            return await v.GetUser();
        }
    }
}
