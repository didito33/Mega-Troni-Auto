    using Mega_Troni_Auto.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    namespace Mega_Troni_Auto.Controllers
    {
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class AuthController : ControllerBase
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly SignInManager<ApplicationUser> _signInManager;
            private readonly IConfiguration _config;

            public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration config)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _config = config;
            }

            [HttpPost]
            public async Task<IActionResult> Register(RegisterDto model)
            {
                var user = new ApplicationUser
                   {
                       UserName = model.Email,
                       Email = model.Email,
                       PhoneNumber = model.PhoneNumber,
                       FirstName = model.FirstName,
                       LastName = model.LastName
                   };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded) return BadRequest(result.Errors);

                await _userManager.AddToRoleAsync(user, "Customer");

                return Ok("Registration successful.");
            }

            [HttpPost]
            public async Task<IActionResult> Login(LoginDto model)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                    return Unauthorized();

                var roles = await _userManager.GetRolesAsync(user);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName!),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: creds
                );

                return Ok(new AuthResponseDto
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpiresAt = token.ValidTo
                });
            }
        }
    }
