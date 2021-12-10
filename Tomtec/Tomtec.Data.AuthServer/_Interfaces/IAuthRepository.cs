using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.Lib.Models;

namespace Tomtec.Data.AuthServer
{
    public interface IAuthRepository
    {
        //User
        User CreateUser(User user);
        User GetUserByUserNameOrEmail(string userNameOrEmail);
        User GetUserByEmail(string email);
        User GetUserByUserName(string username);
        User GetUser(int Id);
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsers(Func<User, bool> query);
        void UpdateUser(User user);
        void DeleteUser(int id);
        //UserClaim
        UserClaim CreateUserClaim(UserClaim userClaim);
        UserClaim GetUserClaim(int id);
        IEnumerable<UserClaim> GetUserClaims();
        IEnumerable<UserClaim> GetUserClaims(Func<UserClaim, bool> query);
        void UpdateUserClaim(UserClaim userClaim);
        void DeleteUserClaim(int id);
        //UserType
        UserType CreateUserType(UserType userType);
        UserType GetUserType(int id);
        IEnumerable<UserType> GetUserTypes();
        IEnumerable<UserType> GetUserTypes(Func<UserType, bool> query);
        void UpdateUserType(UserType userType);
        void DeleteUserType(int id);
        //Address
        Address GetAddress(int id);
        IEnumerable<Address> GetAddresses();
        IEnumerable<Address> GetAddresses(Func<Address, bool> query);
        void UpdateAddress(Address address);

    }
}
