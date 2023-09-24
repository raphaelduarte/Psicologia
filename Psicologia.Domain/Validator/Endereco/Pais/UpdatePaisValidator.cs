using FluentValidation;
using Psicologia.Domain.Commands.Endereco.Pais;

namespace Psicologia.Domain.Validator.Endereco.Pais;

public class UpdatePaisValidator :
    AbstractValidator<UpdatePaisCommand>
{
    public UpdatePaisValidator()
    {
        RuleFor(pais => pais.PaisName)
            .NotNull().WithMessage("Pais's name can not be null")
            .NotEmpty().WithMessage("Pais's name can not be empty")
            .Length(2, 50).WithMessage("Pais's name lenght have to be between 2 and 50 charachteres");
    }
}