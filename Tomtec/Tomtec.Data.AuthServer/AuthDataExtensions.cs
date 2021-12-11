using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.Lib.Models;

namespace Tomtec.Data.AuthServer
{
    public static class AuthDataExtensions
    {
        public static IEnumerable<User> GetCompleteUsers(this IAuthDbContext context)
        {
            return context.Users
                .Include(nameof(User.Address))
                .Include(nameof(User.UserType))
                .Include($"{nameof(User.UsersClaims)}.{nameof(UsersClaims.UserClaim)}");
        }

        public static IEnumerable<User> GetCompleteUsers(this IAuthDbContext context, Func<User, bool> query)
        {
            return context.Users
                .Include(nameof(User.Address))
                .Include(nameof(User.UserType))
                .Include($"{nameof(User.UsersClaims)}.{nameof(UsersClaims.UserClaim)}")
                .Where(query);
        }

        public static User GetCompleteUserByEmail(this IAuthDbContext context, string email)
        {
            return context.Users
                .Include(nameof(User.Address))
                .Include(nameof(User.UserType))
                .Include($"{nameof(User.UsersClaims)}.{nameof(UsersClaims.UserClaim)}")
                .FirstOrDefault(u => u.Email.Equals(email));
        }

        public static User GetCompleteUserByUserName(this IAuthDbContext context, string userName)
        {
            return context.Users
                .Include(nameof(User.Address))
                .Include(nameof(User.UserType))
                .Include($"{nameof(User.UsersClaims)}.{nameof(UsersClaims.UserClaim)}")
                .FirstOrDefault(u => u.UserName.Equals(userName));
        }

        public static User GetCompleteUserById(this AuthServerDBContext context, int Id)
        {
            return context.Users
                .Include(nameof(User.Address))
                .Include(nameof(User.UserType))
                .Include($"{nameof(User.UsersClaims)}.{nameof(UsersClaims.UserClaim)}")
                .FirstOrDefault(u => u.Id == Id);
        }

        public static UserClaim GetCompleteUserClaim(this AuthServerDBContext context, int Id)
        {
            return context.UserClaim
                .Include(nameof(UserClaim.UsersClaims))
                .Include($"{nameof(UserClaim.UsersClaims)}.{nameof(UsersClaims.User)}")
                .FirstOrDefault(ut => ut.Id == Id);
        }

        public static IEnumerable<UserClaim> GetCompleteUserClaims(this AuthServerDBContext context, Func<UserClaim, bool> query)
        {
            return context.UserClaim
                .Include(nameof(UserClaim.UsersClaims))
                .Include($"{nameof(UserClaim.UsersClaims)}.{nameof(UsersClaims.User)}")
                .Where(query);
        }

        public static IEnumerable<UserClaim> GetCompleteUserClaims(this AuthServerDBContext context)
        {
            return context.UserClaim
                .Include(nameof(UserClaim.UsersClaims))
                .Include($"{nameof(UserClaim.UsersClaims)}.{nameof(UsersClaims.User)}");
        }
    }
}
