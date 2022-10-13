using Domain.Adapters;
using Domain.Adapters.UoW;
using Infra.Database.Context;

namespace Infra.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodosContext _context;

        public UnitOfWork(TodosContext context, ITodosRepository todosRepository)
        {
            _context = context;
            TodosRepository = todosRepository;
        }

        public ITodosRepository TodosRepository {get; private set;}

        public void Dispose() => _context.Dispose();
        public bool Save() => _context.SaveChanges() >= 0;
    }
}
