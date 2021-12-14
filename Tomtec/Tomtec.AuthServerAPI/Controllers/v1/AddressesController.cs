using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.Data.AuthServer;
using Tomtec.AuthServerAPI.DTOs;
using Tomtec.Lib.Utils;
using Tomtec.Lib.Models;
using Tomtec.Lib.AspNetCore.Filters;
using Tomtec.Lib.AspNetCore;

namespace Tomtec.AuthServerAPI.Controllers.v1
{
    [Authorization]
    [Route("v1/addresses")]
    public class AddressesController : Controller
    {
        private readonly IAuthRepository _authRepository;

        public AddressesController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpGet("")]
        public IActionResult GetAddresses()
        {
            var adresses = _authRepository.GetAddresses();
            return Ok(new
            {
                message = ResponseMessage.Success,
                value = adresses
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetAddress(int id)
        {
            var address = _authRepository.GetAddress(id);
            return Ok(new 
            {
                message = ResponseMessage.Success,
                value = address
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAdress([FromBody]AddressDto dto, int id)
        {
            var address = dto.ToModel();
            address.Id = id;
            _authRepository.UpdateAddress(address);
            return Ok(new
            {
                message = ResponseMessage.Success,
            });
        }
    }
}
