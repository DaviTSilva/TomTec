using System;
using System.Collections.Generic;
using System.Text;
using Tomtec.Lib.Models;

namespace Tomtec.Data.AuthServer
{
    public interface IEntityRepository
    {
        IEntity Create(IEntity entity);
        public void Delete<TEntity>(int id);
        TEntity Get<TEntity>(int id) where TEntity : class;
        IEnumerable<TEntity> Get<TEntity>() where TEntity : class;
        IEnumerable<TEntity> Get<TEntity>(Func<IEntity<TEntity>, bool> query) where TEntity : class;
        void Update(IEntity entity);

    }
}
