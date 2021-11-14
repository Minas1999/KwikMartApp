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
    public class UserController : ControllerBase
    {
        private readonly IUser v;

        public UserController(IUser v)
        {
            this.v = v;
        }

        [HttpGet]
        public async Task<User> GetUsers()
        {
            return await v.GetUser();
        }
    }
}
