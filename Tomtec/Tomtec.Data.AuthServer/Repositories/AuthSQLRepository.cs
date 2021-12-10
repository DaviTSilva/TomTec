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

        public User GetUser(int Id)
        {
            return _userContext.GetCompleteUserById(Id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _userContext.GetCompleteUsers();
        }

        public IEnumerable<User> GetUsers(Func<User, bool> query)
        {
            return _userContext.GetCompleteUsers(query);
        }

        public void UpdateUser(User user)
        {
            _userContext.Users.Update(user);
            _userContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _userContext.Users.FirstOrDefault(u => u.Id == id);
            _userContext.Users.Remove(user);
            _userContext.SaveChanges();
        }

        public UserClaim CreateUserClaim(UserClaim userClaim)
        {
            _userContext.UserClaim.Add(userClaim);
            userClaim.Id = _userContext.SaveChanges();
            return userClaim;
        }

        public UserClaim GetUserClaim(int id)
        {
            return _userContext.GetCompleteUserClaim(id);
        }

        public IEnumerable<UserClaim> GetUserClaims()
        {
            return _userContext.GetCompleteUserClaims();
        }

        public IEnumerable<UserClaim> GetUserClaims(Func<UserClaim, bool> query)
        {
            return _userContext.GetCompleteUserClaims(query);
        }

        public void UpdateUserClaim(UserClaim userClaim)
        {
            _userContext.UserClaim.Update(userClaim);
            _userContext.SaveChanges();
        }

        public void DeleteUserClaim(int id)
        {
            var userClaim = _userContext.UserClaim.FirstOrDefault(uc => uc.Id == id);
            _userContext.UserClaim.Remove(userClaim);
            _userContext.SaveChanges();
        }

        public UserType CreateUserType(UserType userType)
        {
            _userContext.UserType.Add(userType);
            userType.Id = _userContext.SaveChanges();
            return userType;
        }

        public UserType GetUserType(int id)
        {
            return _userContext.UserType.FirstOrDefault(ut => ut.Id == id);
        }

        public IEnumerable<UserType> GetUserTypes()
        {
            return _userContext.UserType;
        }

        public IEnumerable<UserType> GetUserTypes(Func<UserType, bool> query)
        {
            return _userContext.UserType.Where(query);
        }

        public void UpdateUserType(UserType userType)
        {
            _userContext.UserType.Update(userType);
            _userContext.SaveChanges();
        }

        public void DeleteUserType(int id)
        {
            var userType = _userContext.UserType.FirstOrDefault(uc => uc.Id == id);
            _userContext.UserType.Remove(userType);
            _userContext.SaveChanges();
        }

        public Address GetAddress(int id)
        {
            return _userContext.Addresses.FirstOrDefault(ut => ut.Id == id);
        }

        public IEnumerable<Address> GetAddresses()
        {
            return _userContext.Addresses;
        }

        public IEnumerable<Address> GetAddresses(Func<Address, bool> query)
        {
            return _userContext.Addresses.Where(query);
        }

        public void UpdateAddress(Address address)
        {
            _userContext.Addresses.Update(address);
            _userContext.SaveChanges();
        }

    }
}
