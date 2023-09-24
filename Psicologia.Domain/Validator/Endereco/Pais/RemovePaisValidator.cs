using FluentValidation;
using Psicologia.Domain.Commands.Endereco.Pais;

namespace Psicologia.Domain.Validator.Endereco.Pais;

public class RemovePaisValidator :
    AbstractValidator<RemovePaisCommand>
{
    public RemovePaisValidator()
    {
        RuleFor(pais => pais.PaisName)
            .NotNull().WithMessage("Pais's name can not be null")
            .NotEmpty().WithMessage("Pais's name can not be empty")
            .Length(2, 50).WithMessage("Pais's name lenght have to be between 2 and 50 charachteres");
    }
}