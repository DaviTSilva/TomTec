using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tomtec.Lib.Models;
using Tomtec.Lib.Utils;

namespace Tomtec.Data.AuthServer
{
    public class AuthSQLRepository : IAuthRepository
    {
        private readonly AuthServerDBContext _userContext;
        public AuthSQLRepository(AuthServerDBContext userContext)
        {
            _userContext = userContext;
        }

        public User CreateUser(User user)
        {
            _userContext.Users.Add(user);
            user.Id = _userContext.SaveChanges();

            return user;
        }

        public User GetUserByUserNameOrEmail(string userNameOrEmail)
        {
            if (EmailHelper.IsValidEmail(userNameOrEmail))
                return GetUserByEmail(userNameOrEmail);
            else
                return GetUserByUserName(userNameOrEmail);
        }

        public User GetUserByEmail(string email)
        {
            return _userContext.GetCompleteUserByEmail(email);
        }

        public User GetUserByUserName(string username)
        {
            return _userContext.GetCompleteUserByUserName(username);
        }

        public User GetUserById(int Id)
        {
            return _userContext.GetCompleteUserById(Id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _userContext.GetAllCompleteUsers();
        }

        public IEnumerable<User> GetUsers(Func<User, bool> quey)
        {
            return _userContext.GetCompleteUsers(quey);
        }
    }
}
