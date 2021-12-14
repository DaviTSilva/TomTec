using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.AuthServerAPI.DTOs;
using Tomtec.Data.AuthServer;
using Tomtec.Lib.AspNetCore;
using Tomtec.Lib.AspNetCore.Filters;
using Tomtec.Lib.Models;

namespace Tomtec.AuthServerAPI.Controllers.v1
{
    [Authorization]
    [Route("v1/user-claims")]
    public class UserClaimsController : Controller
    {
        private readonly IAuthRepository _authRepository;

        public UserClaimsController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("")]
        public IActionResult CreateUserClaim([FromBody]UserClaimDto dto)
        {
            var userClaim = _authRepository.CreateUserClaim(dto.ToModel());

            return Created(ResponseMessage.Success, userClaim);
        }

        [HttpGet("")]
        public IActionResult GetUserClaims()
        {
            var userClaims = _authRepository.GetUserClaims();

            return Ok(new { 
                message = ResponseMessage.Success,
                value = userClaims
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetUserClaim(int id)
        {
            var userClaim = _authRepository.GetUserClaim(id);

            return Ok(new { 
                message = ResponseMessage.Success,
                value = userClaim,
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUserClaim([FromBody] UserClaimDto dto, int id)
        {
            var userClaim = dto.ToModel();
            userClaim.Id = id;
            _authRepository.UpdateUserClaim(dto.ToModel());

            return Ok(new { 
                message = ResponseMessage.Success,
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserClaim(int id)
        {
            _authRepository.DeleteUser(id);

            return Ok(new { 
                message = ResponseMessage.Success,
            });
        }
    }
}
