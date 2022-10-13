using Domain.Entities;
using Domain.Entities.Notifications;
using Domain.Services;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Services
{
    public class ServiceBase
    {
        private readonly INotificator _notificador;

        protected ServiceBase(INotificator notificador)
        {
            _notificador = notificador;
        }

        protected void Notificate(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificate(error.ErrorMessage);
            }
        }

        protected void Notificate(string message)
        {
            _notificador.Handle(new Notification(message));
        }

        protected bool ExecuteValidation<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : BaseEntity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificate(validator);

            return false;
        }
    }
}
