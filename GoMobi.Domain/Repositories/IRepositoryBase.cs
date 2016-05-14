using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace GoMobi.Domain.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Dispose();
    }
}