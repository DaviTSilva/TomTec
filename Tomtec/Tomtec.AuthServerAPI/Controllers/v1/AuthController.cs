using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.AuthServerAPI.Data;
using Tomtec.Lib.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Tomtec.AuthServerAPI.DTOs;

namespace Tomtec.AuthServerAPI.Controllers
{
    [Route("v1/auth")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _jwtService = new JwtService(configuration.GetValue<string>("Secret"));
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _userRepository.GetUserByUserNameOrEmail(dto.UserNameOrEmail);

            if (user == null)
                return BadRequest(new { message = "Invalid Credentials!" });
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                return BadRequest(new { message = "Invalid Credentials!" });

            string jwtToken = _jwtService.Generate(user.Id, user.UsersClaims.Select(c => c.ToSecurityClaim()));
            Response.Cookies.Append("token", jwtToken, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                messsage = "success"
            });
        }

        [HttpGet("user")]
        public IActionResult GetUser()
        {
            try
            {
                var jwtToken = Request.Cookies["token"];
                var token = _jwtService.Verify(jwtToken);
                int userId = int.Parse(token.Issuer);
                var user = _userRepository.GetUserById(userId);

                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpPost("loggout")]
        public IActionResult Loggout()
        {
            Response.Cookies.Delete("token");
            return Ok(new
            {
                message = "success"
            });

        }
    }
}
