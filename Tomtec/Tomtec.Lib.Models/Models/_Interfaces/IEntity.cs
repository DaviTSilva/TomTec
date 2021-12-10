using System;
using System.Collections.Generic;
using System.Text;

namespace Tomtec.Lib.Models
{
    public interface IEntity<T> : IEntity { }

    public interface IEntity
    {
        public int Id { get; set; }
    }
}
