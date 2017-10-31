using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DojoAspNetCore;
using DojoAspNetCore.Auth;
using DojoLive.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DojoLive.Controllers
{
    [Route("token")]
    [AllowAnonymous]
    public class TokenController : Controller
    {
        [HttpPost]
        public IActionResult Create([FromBody]LoginInputModel loginInput)
        {
            if (loginInput.Username != "cwi.teste" || loginInput.Password != "password")
            {
                return Unauthorized();
            }

            var token = new JwtTokenBuilder(
                JwtSecurityKey.Create("!@#$%&*()SecretKey!WebApi!@#$%&*()"),
                new Dictionary<string, string>(),
                3).Build();

            return Ok(token.Value);
        }
    }
}
