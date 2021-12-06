using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.Lib.Models;

namespace Tomtec.AuthServerAPI.Data
{
    public interface IUserRepository
    {
        User Create(User user);
        
    }
}
