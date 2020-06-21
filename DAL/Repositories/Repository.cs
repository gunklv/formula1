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

        public async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            var e = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Remove(e);
        }

        public async Task Update(TEntity entity)
        {
            var e = await _context.Set<TEntity>().FindAsync(entity.Id);
            _context.Entry(e).CurrentValues.SetValues(entity);
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().AsQueryable<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
