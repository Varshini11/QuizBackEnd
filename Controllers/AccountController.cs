using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_backend.Controllers
{   public class Credentials {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {   readonly UserManager<Microsoft.AspNet.Identity.EntityFramework.IdentityUser> userManager;
        readonly SignInManager<Microsoft.AspNet.Identity.EntityFramework.IdentityUser> signInManager;
        public AccountController(UserManager<Microsoft.AspNet.Identity.EntityFramework.IdentityUser> userManager, SignInManager<Microsoft.AspNet.Identity.EntityFramework.IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Credentials credentials)
        {
            var user = new Microsoft.AspNet.Identity.EntityFramework.IdentityUser { UserName = credentials.Email, Email = credentials.Email };
            var result = await userManager.CreateAsync(user, credentials.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);
            await signInManager.SignInAsync(user, isPersistent: false);
                
            var jwt = new JwtSecurityToken();

            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
        }
    }
}
