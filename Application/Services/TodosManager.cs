using AutoMapper;
using Domain.Adapters;
using Domain.Adapters.UoW;
using Domain.Entities;
using Domain.Entities.Models.DTO;
using Domain.Entities.Models.Response;
using Domain.Entities.Models.Validations;
using Domain.Services;

namespace Application.Services
{
    public class TodosManager : ServiceBase, ITodosService
    {
        private readonly INotificator _notificator;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ITodosRepository _todosRepository;
        public TodosManager(INotificator notificador, IUnitOfWork uow, IMapper mapper) : base(notificador)
        {
            _notificator = notificador;
            _uow = uow;
            _mapper = mapper;
            _todosRepository = uow.TodosRepository;
        }

        public async Task<Result> Add(TodosDTO entity)
        {
            var result = new Result();
            var todo = _mapper.Map<Todos>(entity);

            if(!ExecuteValidation(new TodosValidation(), todo))
            {
                result.Success = false;
                result.Data = _notificator.GetNotifications();

                return result;
            }

            await _todosRepository.Add(todo);

            _uow.Save();

            result.Success = true;
            result.Data = todo;

            return result;
        }

        public async Task<Result> GetAll()
        {
            return new Result
            {
                Success = true,
                Data = await _todosRepository.GetAll()
            };
        }

        public async Task<Result> GetById(int id)
        {
            var todo = await _todosRepository.Get(id);

            if(todo is null)
            {
                return new Result
                {
                    Success = false,
                    Data = "Todo not found"
                };
            }

            return new Result { Data = todo, Success = true };
        }

        public async Task<Result> Remove(int id)
        {
            var todo = await _todosRepository.Get(id);

            if (todo is null)
            {
                return new Result
                {
                    Success = false,
                    Data = "Todo not found"
                };
            }

            await _todosRepository.Delete(id);

            _uow.Save();

            return new Result { Success = true, Data="Todo has been deleted" };
        }

        public async Task<Result> Update(TodosDTO entity)
        {
            var result = new Result();
            var todo = _mapper.Map<Todos>(entity);

            if (!ExecuteValidation(new TodosValidation(), todo))
            {
                result.Success = false;
                result.Data = _notificator.GetNotifications();

                return result;
            }

            await _todosRepository.Update(todo);

            _uow.Save();

            result.Success = true;
            result.Data = todo;

            return result;
        }
    }
}
