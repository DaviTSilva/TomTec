using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.Lib.Models;

namespace Tomtec.Data.AuthServer
{
    public static class UserDataExtensions
    {
        public static IQueryable<User> GetAllCompleteUsers(this AuthServerDBContext context)
        {
            return context.Users
                .Include(nameof(Address))
                .Include(nameof(UserType))
                .Include($"{nameof(UsersClaims)}.{nameof(UsersClaims.UserClaim)}");
        }

        public static IEnumerable<User> GetCompleteUsers(this AuthServerDBContext context, Func<User, bool> query)
        {
            return context.Users
                .Include(nameof(Address))
                .Include(nameof(UserType))
                .Include($"{nameof(UsersClaims)}.{nameof(UsersClaims.UserClaim)}")
                .Where(query);
        }

        public static User GetCompleteUserByEmail(this AuthServerDBContext context, string email)
        {
            return context.Users
                .Include(nameof(Address))
                .Include(nameof(UserType))
                .Include($"{nameof(UsersClaims)}.{nameof(UsersClaims.UserClaim)}")
                .FirstOrDefault(u => u.Email.Equals(email));
        }

        public static User GetCompleteUserByUserName(this AuthServerDBContext context, string userName)
        {
            return context.Users
                .Include(nameof(Address))
                .Include(nameof(UserType))
                .Include($"{nameof(UsersClaims)}.{nameof(UsersClaims.UserClaim)}")
                .FirstOrDefault(u => u.UserName.Equals(userName));
        }

        public static User GetCompleteUserById(this AuthServerDBContext context, int Id)
        {
            return context.Users
                .Include(nameof(Address))
                .Include(nameof(UserType))
                .Include($"{nameof(UsersClaims)}.{nameof(UsersClaims.UserClaim)}")
                .FirstOrDefault(u => u.Id == Id);
        }
    }
}
