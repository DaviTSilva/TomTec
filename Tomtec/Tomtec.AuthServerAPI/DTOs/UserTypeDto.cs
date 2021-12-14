using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.Lib.Models;

namespace Tomtec.AuthServerAPI.DTOs
{
    public class UserTypeDto
    {
        public string Name { get; set; }

        public UserType ToModel()
        {
            return new UserType()
            {
                Name = this.Name
            };
        }
    }
}
