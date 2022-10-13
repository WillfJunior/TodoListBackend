namespace Domain.Adapters.UoW
{
    public interface IUnitOfWork
    {
        ITodosRepository TodosRepository {get;}
        bool Save();
        void Dispose();
    }
}
