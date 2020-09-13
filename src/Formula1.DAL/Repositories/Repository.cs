using BLL.Contracts.Repository;
using BLL.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly DataContext _context;

        public Repository(DataContext context) => _context = context;

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var e = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Remove(e);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var e = await _context.Set<TEntity>().FindAsync(entity.Id);
            _context.Entry(e).CurrentValues.SetValues(entity);
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().AsQueryable<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
