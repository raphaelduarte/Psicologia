using FluentValidation;
using Psicologia.Domain.Commands.Endereco.Bairro;

namespace Psicologia.Domain.Validator.Endereco.Logradouro;

public class RemoveBairroValidator : AbstractValidator<RemoveBairroCommand>
{
    public RemoveBairroValidator()
    {
        RuleFor(bairro => bairro.BairroName)
            .NotNull().WithMessage("Bairro's name can not be null")
            .NotEmpty().WithMessage("Bairro's name can not be empty")
            .Length(2, 100).WithMessage("Bairro's lenght have to be between 1 and 100 character");
    }
}