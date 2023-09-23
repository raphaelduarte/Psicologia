using FluentValidation;
using Psicologia.Domain.Commands.Endereco.Cidade;

namespace Psicologia.Domain.Validator.Endereco.Cidade;

public class UpdateCidadeValidator : AbstractValidator<UpdateCidadeCommand>
{
    public UpdateCidadeValidator()
    {
        RuleFor(cidade => cidade.CidadeName)
            .NotNull().WithMessage("Cidade's name can not be null")
            .NotEmpty().WithMessage("Cidade's name can not be empty")
            .Length(2, 50).WithMessage("Cidade's name lenght have to be between 2 and 50 charachteres");
    }
}