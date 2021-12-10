using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Tomtec.Lib.Utils;
using Microsoft.AspNetCore.Http;
using Tomtec.AuthServerAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Tomtec.Data.AuthServer;

namespace Tomtec.AuthServerAPI.Controllers
{
    [Route("v1/auth")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _userRepository;
        private readonly JwtService _jwtService;

        public AuthController(IAuthRepository userRepository)
        {
            _userRepository = userRepository;
            _jwtService = new JwtService();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            try
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
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpGet("user")]
        public IActionResult GetUser()
        {
            try
            {
                var jwtToken = Request.Cookies["token"];
                var token = _jwtService.Verify(jwtToken);
                int userId = int.Parse(token.Issuer);
                var user = _userRepository.GetUser(userId);

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
