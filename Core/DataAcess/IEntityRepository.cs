using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAcess
{
    //
    // Generic constraint
    // class : referans tip
    // IEntity : IEntity olabilir veya I Entity implemente eden nesne olabilir
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //
        // Delegeler
        // LİNQ
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
       
    }
}
