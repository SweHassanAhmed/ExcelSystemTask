using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.DTO;
using Service.Contracts;
using Service.Services;

namespace WebAPI.Controllers
{
    [Route("api/Security")]
    [ApiController]
    public class SecurityController : BaseController
    {
        private readonly IUserService userService;
        private readonly IConfiguration configuration;

        public SecurityController(IUserService _userService,IConfiguration _configuration)
        {
            userService = _userService;
            configuration = _configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult PostLogin([FromBody]UserDTO user)
        {
            var loggedUser = userService.GetUserByName(user.UserName);
            if(loggedUser != null)
            {

                var claims = new[]
                {
                    new Claim("UserId", user.UserID.ToString())
                };

                var token = new JwtSecurityToken
                (
                    issuer: configuration["Issuer"],
                    audience: configuration["Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(60),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SigningKey"])),
                         SecurityAlgorithms.HmacSha256)
                );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            else
            {
                return BadRequest(new { Message = "Wrong Data." });
            }
        }
    }
}
