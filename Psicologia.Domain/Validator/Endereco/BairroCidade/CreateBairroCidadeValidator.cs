using FluentValidation;
using Psicologia.Domain.Commands.Endereco.BairroCidade;

namespace Psicologia.Domain.Validator.Endereco.BairroCidade;

public class CreateBairroCidadeValidator : AbstractValidator<CreateBairroCidadeCommand>
{
    public CreateBairroCidadeValidator()
    {
        RuleFor(bairroCidade => bairroCidade.)
            .NotNull().WithMessage("Bairro's name can not be null")
            .NotEmpty().WithMessage("Bairro's name can not be empty")
            .Length(2, 100).WithMessage("Bairro's lenght have to be between 1 and 100 character");
    }
}