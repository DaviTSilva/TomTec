using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.AuthServerAPI.DTOs;
using Tomtec.AuthServerAPI.Records;
using Tomtec.Data.AuthServer;
using Tomtec.Lib.AspNetCore;
using Tomtec.Lib.AspNetCore.Filters;
using Tomtec.Lib.Models;

namespace Tomtec.AuthServerAPI.Controllers.v1
{
    [Route("v1/profiles")]
    public class ProfilesController : Controller
    {     
        private readonly IAuthRepository _authRepository;
        public ProfilesController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [AllowAnonymous]
        [HttpPost("")]
        public IActionResult Register([FromBody] UserRegisterDto dto)
        {
            var user = _authRepository.CreateUser(dto.ToModel());
            return Created(ResponseMessage.Success, new UserRegisterRecord(user));
        }

        [Authorization]
        [HttpGet("")]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _authRepository.GetUsers();
                return Ok(new
                {
                    message = ResponseMessage.Success,
                    value = new UserListRecord(users)
                });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [Authorization]
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                var user = _authRepository.GetUser(id);
                return Ok(new
                {
                    message = ResponseMessage.Success,
                    value = user
                });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [Authorization]
        [HttpGet("username/{userName}")]
        public IActionResult GetUserByUserName(string userName)
        {
            try
            {
                var user = _authRepository.GetUserByUserName(userName);
                return Ok(new
                {
                    message = ResponseMessage.Success,
                    value = user
                });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [Authorization]
        [HttpGet("email/{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            try
            {
                var user = _authRepository.GetUserByEmail(email);
                return Ok(new
                {
                    message = ResponseMessage.Success,
                    value = user
                });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromBody] UserRegisterDto dto, int id)
        {
            User user = dto.ToModel();
            user.Id = id;
            _authRepository.UpdateUser(user);

            return Ok(new { 
                message = ResponseMessage.Success,
            });
        }
    }
}
