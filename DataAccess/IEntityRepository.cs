using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using Entities.Concrete;

namespace DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        public List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        public List<T> GetById(int id);

    }
}
