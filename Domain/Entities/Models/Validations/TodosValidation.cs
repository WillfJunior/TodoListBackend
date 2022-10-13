using Domain.Entities.Models.DTO;
using FluentValidation;

namespace Domain.Entities.Models.Validations
{
    public class TodosValidation : AbstractValidator<Todos>
    {
        public TodosValidation()
        {
            RuleFor(t => t.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("The {PropertyName} field  must be provided")
                .MinimumLength(5)
                .WithMessage("The {PropertyName} field must be at least 5 characters long");
        }
    }
}
