using System.Linq.Expressions;

namespace Domain.Adapters
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);


    }
}
