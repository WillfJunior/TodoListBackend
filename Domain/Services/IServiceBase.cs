using Domain.Entities.Models.Response;

namespace Domain.Services
{
    public interface IServiceBase<T>
    {
        Task<Result> Add(T entity);
        Task<Result> GetAll();
        Task<Result> GetById(int id);
        Task<Result> Update(T entity);
        Task<Result> Remove(int id);
    }
}