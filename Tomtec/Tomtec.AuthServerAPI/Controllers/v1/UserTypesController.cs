using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.AuthServerAPI.DTOs;
using Tomtec.Data.AuthServer;
using Tomtec.Lib.AspNetCore;
using Tomtec.Lib.AspNetCore.Filters;

namespace Tomtec.AuthServerAPI.Controllers.v1
{
    [Authorization]
    [Route("v1/user-types")]
    public class UserTypesController : Controller
    {
        private readonly IAuthRepository _authRepository;

        public UserTypesController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("")]
        public IActionResult CreateUserType([FromBody] UserTypeDto dto)
        {
            var userType = _authRepository.CreateUserType(dto.ToModel());

            return Created(ResponseMessage.Success, userType);
        }

        [HttpGet("")]
        public IActionResult GetUserTypes()
        {
            var userTypes = _authRepository.GetUserTypes();

            return Ok(new { 
                message = ResponseMessage.Success,
                value = userTypes,
            });;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserType(int id)
        {
            var userType = _authRepository.GetUserType(id);
            return Ok(new { 
                message = ResponseMessage.Success,
                value = userType
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUserType([FromBody] UserTypeDto dto, int id)
        {
            var userType = dto.ToModel();
            userType.Id = id;
            _authRepository.UpdateUserType(userType);

            return Ok(new { 
                message = ResponseMessage.Success,
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserType(int id)
        {
            _authRepository.DeleteUserType(id);

            return Ok(new { 
                message = ResponseMessage.Success
            });
        }
    }
}
