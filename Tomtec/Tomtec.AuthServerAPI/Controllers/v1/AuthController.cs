using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.AuthServerAPI.Data;
using Tomtec.Lib.Models.DTOs;
using Tomtec.Lib.Models.Records;

namespace Tomtec.AuthServerAPI.Controllers
{
    [Route("v1/auth")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]UserRegisterDto dto)
        {
            var user = _userRepository.Create(dto.ToModel());
            return Created("Success", new UserRegisterRecord(user));
        }
    }
}
