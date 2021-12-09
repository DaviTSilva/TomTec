using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.Lib.Models;

namespace Tomtec.Data.AuthServer
{
    public interface IAuthRepository
    {
        User CreateUser(User entity);
        User GetUserByUserNameOrEmail(string userNameOrEmail);
        User GetUserByEmail(string email);
        User GetUserByUserName(string username);
        User GetUserById(int Id);
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsers(Func<User, bool> quey);
    }
}
