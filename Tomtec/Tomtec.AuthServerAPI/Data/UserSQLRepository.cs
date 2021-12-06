using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.Lib.Models;

namespace Tomtec.AuthServerAPI.Data
{
    public class UserSQLRepository : IUserRepository
    {
        private readonly UserContext _userContext;
        public UserSQLRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public User Create(User user)
        {
            _userContext.User.Add(user);
            user.Id = _userContext.SaveChanges();

            return user;
        }
    }
}
