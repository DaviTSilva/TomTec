using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.AuthServerAPI.Data;
using Tomtec.AuthServerAPI.DTOs;
using Tomtec.AuthServerAPI.Records;

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

        [HttpPost("")]
        public IActionResult Register([FromBody] UserRegisterDto dto)
        {
            var user = _userRepository.CreateUser(dto.ToModel());
            return Created("Success", new UserRegisterRecord(user));
        }
    }
}
