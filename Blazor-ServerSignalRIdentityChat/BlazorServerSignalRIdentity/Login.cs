using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServerSignalRIdentity
{
    [Route("/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        public async Task<ActionResult> LoginMethod([FromForm] string userName)
        {
            var user = HttpContext.User;
            if(user.Claims.Count() > 0)
            {
                await HttpContext.SignOutAsync();
                OurHub.currentUser.Remove(user.Claims.First().Value);
            }
            IEnumerable<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userName)
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "auth");
            ClaimsPrincipal cp = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(cp);
            return Redirect("/");
        }
    }
}
