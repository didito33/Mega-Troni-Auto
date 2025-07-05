    using MegaTroniAuto.API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    namespace MegaTroniAuto.API.Controllers
    {
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("secret")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Secret()
        {
            var name = User.Identity?.Name;
            return Ok($"You're authenticated as {name}");
        }

        [HttpGet("public")]
        public IActionResult Public() => Ok("No auth needed");

        [Authorize]
        [HttpGet("testclaims")]
        public IActionResult TestClaims()
        {
            var claims = User.Claims.Select(c => new { c.Type, c.Value });
            return Ok(claims);
        }

        [Authorize]
        [HttpGet("debug")]
        public IActionResult Debug()
        {
            var identity = User.Identity;
            var claims = User.Claims.Select(c => new { c.Type, c.Value });
            return Ok(new
            {
                IsAuthenticated = identity.IsAuthenticated,
                Name = identity.Name,
                Claims = claims
            });
        }
    }
}
