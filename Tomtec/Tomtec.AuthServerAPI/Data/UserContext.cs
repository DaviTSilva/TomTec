using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.Lib.Models;

namespace Tomtec.AuthServerAPI.Data
{
    public class UserContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public UserContext(IConfiguration configuration)
        {
            Configuration = configuration;
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("AuthServerDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersClaims>().HasKey(ur => new { ur.UserId, ur.UserClaimId });
            modelBuilder.Entity<User>().HasIndex( u => new { 
                u.Email,
                u.UserName,
            }).IsUnique();
            modelBuilder.Entity<UserClaim>().HasIndex(r => r.Name).IsUnique();
            modelBuilder.Entity<UserType>().HasIndex(ut => ut.Name).IsUnique();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserClaim> UserClaim { get; set; }
        public DbSet<UsersClaims> UsersClaims { get; set; }
        public DbSet<UserType> UserType { get; set; }

    }
}
