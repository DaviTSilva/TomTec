using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.Lib.Models;

namespace Tomtec.Lib.Models.Data
{
    public class AuthServerContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AuthServerContext(IConfiguration configuration)
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
            modelBuilder.Entity<UserRoles>().HasKey(sc => new { sc.UserId, sc.RoleId });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
