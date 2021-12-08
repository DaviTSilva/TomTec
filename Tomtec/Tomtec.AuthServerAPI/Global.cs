using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tomtec.AuthServerAPI
{
    public static class Global
    {
        private static IConfiguration _configuration;

        public static IConfiguration configuration { 
            get 
            {
                return _configuration;
            } 
            set 
            {
                _configuration = value;
            } 
        }
    }
}
