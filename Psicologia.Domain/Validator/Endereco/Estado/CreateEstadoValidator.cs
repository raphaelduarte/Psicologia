using FluentValidation;
using Psicologia.Domain.Commands.Endereco.Estado;

namespace Psicologia.Domain.Validator.Endereco.Estado;

public class CreateEstadoValidator : 
    AbstractValidator<CreateEstadoCommand>
{
    public CreateEstadoValidator()
    {
        RuleFor(estado => estado.EstadoName)
            .NotNull().WithMessage("Estado's name can not be null")
            .NotEmpty().WithMessage("Estado's name can not be empty")
            .Length(2, 50).WithMessage("Estado's name lenght have to be between 2 and 50 charachteres");
    }
}