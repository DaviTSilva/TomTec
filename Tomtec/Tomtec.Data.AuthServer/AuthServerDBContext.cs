using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Tomtec.Lib.Models;

namespace Tomtec.Data.AuthServer
{
    public class AuthServerDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AuthServerDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            // construct the DB using the project Tomtec.AuthServerAPI as startup
            options.UseSqlServer(Configuration.GetConnectionString("AuthServerDB"), b => b.MigrationsAssembly("Tomtec.AuthServerAPI"));
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
