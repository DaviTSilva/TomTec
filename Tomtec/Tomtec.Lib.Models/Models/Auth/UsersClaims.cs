using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Tomtec.Lib.Models
{
    /// <summary>
    /// This class is needed for the many-to-many relationship between Roles and Users
    /// </summary>
    public class UsersClaims
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int UserClaimId { get; set; }
        public UserClaim UserClaim { get; set; }

        public Claim ToSecurityClaim()
        {
            return new Claim(UserClaim.Name, UserId.ToString());
        }
    }
}
