﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Tomtec.Lib.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Tomtec.Lib.AspNetCore.Filters
{
    public class Authorization : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var token = context.HttpContext.Request.Cookies["token"];
                var jwtService = new JwtService();

                if (string.IsNullOrEmpty(token))
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                var validated = jwtService.Verify(token);

                if (DateTime.UtcNow < validated.ValidFrom || DateTime.UtcNow > validated.ValidTo)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }
            catch (Exception)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
