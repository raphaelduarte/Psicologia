using FluentValidation;
using Psicologia.Domain.Commands.Endereco.NumeroEndereco;

namespace Psicologia.Domain.Validator.Endereco.NumeroEndereco;

public class RemoveNumeroEnderecoValidator : AbstractValidator<RemoveNumeroEnderecoCommand>
{
    public RemoveNumeroEnderecoValidator()
    {
        RuleFor(numero => numero.NumeroEndereco)
            .NotNull().WithMessage("Number can not be null")
            .NotEmpty().WithMessage("Number can not be empty");
    }
}