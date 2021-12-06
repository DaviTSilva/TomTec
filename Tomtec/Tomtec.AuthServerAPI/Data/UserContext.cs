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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoles>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<User>().HasIndex( u => new { 
                u.Email,
                u.UserName,
            }).IsUnique();
            modelBuilder.Entity<Role>().HasIndex(r => r.Name).IsUnique();
            modelBuilder.Entity<UserType>().HasIndex(ut => ut.Name).IsUnique();
        }

        public DbSet<User> User { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<UserType> UserType { get; set; }

    }
}
