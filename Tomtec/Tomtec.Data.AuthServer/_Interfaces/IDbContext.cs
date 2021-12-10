using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tomtec.Data.AuthServer
{
    public interface IDbContext 
    {
        /// <summary>
        /// Implement this like: DbContext context {get {return this}}
        /// </summary>
        DbContext context { get; }
    }
}
