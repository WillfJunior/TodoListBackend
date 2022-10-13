using Domain.Adapters;
using Domain.Entities;
using Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infra.Database.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        protected readonly TodosContext Context;
        private DbSet<TEntity> _entities;

        public RepositoryBase(TodosContext context)
        {
            Context = context;
            _entities = Context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _entities.FirstOrDefaultAsync(e => e.Id == id);

            if (entity != null)
                _entities.Remove(entity);

        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await _entities.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.SingleOrDefaultAsync(predicate);
        }

        public async Task Update(TEntity entity)
        {
           await Task.FromResult(_entities.Update(entity));
        }


    }
}
