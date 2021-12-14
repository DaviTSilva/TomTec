using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.Lib.Models;

namespace Tomtec.AuthServerAPI.DTOs
{
    public class UserClaimDto
    {
        public string Name { get; set; }

        public UserClaim ToModel()
        {
            return new UserClaim
            {
                Name = this.Name
            };
        }
    }

}
