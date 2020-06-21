using BLL.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BLL.Contracts.Repository
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task Create(TEntity entity);
        Task Delete(Guid id);
        Task Update(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate);

        Task SaveChangesAsync();
    }
}
