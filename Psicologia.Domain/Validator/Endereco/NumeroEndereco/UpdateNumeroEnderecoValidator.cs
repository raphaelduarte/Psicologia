using FluentValidation;
using Psicologia.Domain.Commands.Endereco.NumeroEndereco;

namespace Psicologia.Domain.Validator.Endereco.NumeroEndereco;

public class UpdateNumeroEnderecoValidator : AbstractValidator<UpdateNumeroEnderecoCommand>
{
    public UpdateNumeroEnderecoValidator()
    {
        RuleFor(numero => numero.NumeroEndereco)
            .NotNull().WithMessage("Number can not be null")
            .NotEmpty().WithMessage("Number can not be empty");
    }
}