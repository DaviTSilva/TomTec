using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tomtec.Lib.Models;

namespace Tomtec.Data.AuthServer
{
    public interface IAuthDbContext : IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<UserClaim> UserClaim { get; set; }
        DbSet<UsersClaims> UsersClaims { get; set; }
        DbSet<UserType> UserType { get; set; }
    }
}
