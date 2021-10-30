using BlazorConfigurationFromAPI.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConfigurationFromAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetConfiguration()
        {
            //HttpContext.Users => get Id => load his/her configuration
            Tenant tenant = new Tenant
            {
                Name = "Regional Bank",
                Colors = new string[] {"blue", "white"}
            };
            return new JsonResult(tenant);
        }
    }
}
