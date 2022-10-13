using Domain.Adapters;
using Domain.Entities;
using Infra.Database.Context;

namespace Infra.Database.Repositories
{
    public class TodosRepository : RepositoryBase<Todos>, ITodosRepository
    {
        public TodosRepository(TodosContext context) : base(context)
        {
        }
    }
}
