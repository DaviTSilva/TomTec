using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.AuthServerAPI.Data;
using Tomtec.AuthServerAPI.DTOs;
using Tomtec.AuthServerAPI.Records;
using Tomtec.Lib.AspNetCore.Filters;

namespace Tomtec.AuthServerAPI.Controllers.v1
{
    [Route("v1/profiles")]
    public class ProfilesController : Controller
    {
        private readonly IUserRepository _userRepository;
        public ProfilesController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost("")]
        public IActionResult Register([FromBody] UserRegisterDto dto)
        {
            var user = _userRepository.CreateUser(dto.ToModel());
            return Created("success", new UserRegisterRecord(user));
        }

        [Authorization]
        [HttpGet("")]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _userRepository.GetUsers();
                return Ok(new
                {
                    message = "success",
                    value = new UserListRecord(users)
                });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }
    }
}
