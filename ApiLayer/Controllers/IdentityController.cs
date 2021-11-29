using DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLayer.Controllers
{
    public class IdentityController : Controller
    {
        private readonly UserManager<User> userManager;

        public IdentityController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(User user)
        {
            /*if (await userManager.FindByNameAsync(user.Name) == null)
            {
                await userManager.CreateAsync(user, user.Password);
            }
            return Ok();*/

            IdentityResult result = await userManager.CreateAsync(user, user.Password);
            if (result.Succeeded)
            {
                return Ok();
            }

            ModelState.AddModelError("", result.Errors.SelectMany(i => i.Description).ToString());
            return BadRequest();
        }

        [HttpPost("Auth")]
        public async Task<ActionResult> Auth(User user)
        {
            if (await userManager.CheckPasswordAsync(user, user.Password))
            {
                return Ok();
            }
            return Unauthorized();
        }
    }
}
