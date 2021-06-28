using Common.EntityRequest;
using Common.EntityResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }


        /// <summary>
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        /// <response code="204">User already exists</response>
        /// <response code="200">User created successfully</response>
        /// <response code="400">User details is not valid</response>
        // POST: api/<UserController>/register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if (await _userManager.FindByEmailAsync(registerRequest.Email) != null || await _userManager.FindByNameAsync(registerRequest.Username) != null)
                return StatusCode(StatusCodes.Status204NoContent, new Response { Status = "Error", Message = "User already exists" });

            IdentityUser user = new IdentityUser()
            {
                UserName = registerRequest.Username,
                Email = registerRequest.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, registerRequest.Password);

            if (!result.Succeeded)
            {
                var error = "";
                foreach (var item in result.Errors)
                {
                    error += item.Description.ToString();
                }
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Creation failed! Please check user details and try again\n"+error });
            }

            return Ok(new Response { Status="Success", Message="User created successfully" });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        /// <response code="200"></response>
        // POST: api/<UserController>/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.Username);
            if(user != null && await _userManager.CheckPasswordAsync(user, loginRequest.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach(var item in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, item));
                }

                //authClaims.Add(new Claim(ClaimTypes.Role, "Administrator"));

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                   issuer: _configuration["JWT:ValidIssuer"],
                   audience: _configuration["JWT:ValidAudience"],
                   //audience: "hihi",
                   expires: DateTime.UtcNow.AddMinutes(-4),
                   claims: authClaims,
                   signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                   );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });

            }
            return Unauthorized();
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
