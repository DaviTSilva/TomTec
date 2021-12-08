using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomtec.Lib.Models;

namespace Tomtec.AuthServerAPI.Records
{
    public class UserListRecord
    {
        public UserListRecord(IEnumerable<User> users)
        {
            Users = users;
        }

        public IEnumerable<User> Users { get; set; }
    }
}
