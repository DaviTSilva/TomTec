﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tomtec.AuthServerAPI.DTOs
{
    public class LoginDto
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
