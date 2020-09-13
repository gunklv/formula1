using BLL.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BLL.Contracts.Repository
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        void Create(TEntity entity);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate);

        Task SaveChangesAsync();
    }
}
