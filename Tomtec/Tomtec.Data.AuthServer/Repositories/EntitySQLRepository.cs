using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tomtec.Lib.Models;

namespace Tomtec.Data.AuthServer
{
    public class EntitySQLRepository : IEntityRepository
    {
        private readonly DbContext _dbContext;
        public EntitySQLRepository(DbContext userContext)
        {
            _dbContext = userContext;
        }

        public IEntity Create(IEntity entity)
        {
            _dbContext.Add(entity);
            entity.Id = _dbContext.SaveChanges();
            return entity;
        }

        public void Delete<TEntity>(int id)
        {
            _dbContext.Remove(Get<IEntity<TEntity>>(id));
            _dbContext.SaveChanges();
        }

        public TEntity Get<TEntity>(int id) where TEntity : class
        {
            return (TEntity)_dbContext.Set<IEntity<TEntity>>().FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<TEntity> Get<TEntity>() where TEntity : class
        {
            return (IEnumerable<TEntity>)_dbContext.Set<IEntity<TEntity>>();
        }

        public IEnumerable<TEntity> Get<TEntity>(Func<IEntity<TEntity>, bool> query) where TEntity : class
        {
            return (IEnumerable<TEntity>)_dbContext.Set<IEntity<TEntity>>().Where(query);
        }

        public void Update(IEntity entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
