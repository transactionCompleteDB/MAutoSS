namespace MAutoSS.Data.Repositories.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IGenericRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();

        IEnumerable<T1> GetAll<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> selectExpression);

        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        int SaveChanges();

        void Dispose();
    }
}
