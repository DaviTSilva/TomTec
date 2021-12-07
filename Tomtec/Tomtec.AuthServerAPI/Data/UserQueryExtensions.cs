using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.Lib.Models;

namespace Tomtec.AuthServerAPI.Data
{
    public static class UserQueryExtensions
    {
        public static IQueryable<User> GetAllCompleteUsers(this UserContext context)
        {
            return context.Users
                .Include(nameof(Address))
                .Include(nameof(UserType))
                .Include($"{nameof(UsersClaims)}.{nameof(UsersClaims.UserClaim)}");
        }

        public static IEnumerable<User> GetCompleteUsers(this UserContext context, Func<User, bool> query)
        {
            return context.Users
                .Include(nameof(Address))
                .Include(nameof(UserType))
                .Include($"{nameof(UsersClaims)}.{nameof(UsersClaims.UserClaim)}")
                .Where(query);
        }

        public static User GetCompleteUserByEmail(this UserContext context, string email)
        {
            return context.Users
                .Include(nameof(Address))
                .Include(nameof(UserType))
                .Include($"{nameof(UsersClaims)}.{nameof(UsersClaims.UserClaim)}")
                .FirstOrDefault(u => u.Email.Equals(email));
        }

        public static User GetCompleteUserByUserName(this UserContext context, string userName)
        {
            return context.Users
                .Include(nameof(Address))
                .Include(nameof(UserType))
                .Include($"{nameof(UsersClaims)}.{nameof(UsersClaims.UserClaim)}")
                .FirstOrDefault(u => u.UserName.Equals(userName));
        }

        public static User GetCompleteUserById(this UserContext context, int Id)
        {
            return context.Users
                .Include(nameof(Address))
                .Include(nameof(UserType))
                .Include($"{nameof(UsersClaims)}.{nameof(UsersClaims.UserClaim)}")
                .FirstOrDefault(u => u.Id == Id);
        }
    }
}
