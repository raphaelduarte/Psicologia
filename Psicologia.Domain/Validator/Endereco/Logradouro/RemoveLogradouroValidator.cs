using FluentValidation;
using Psicologia.Domain.Commands.Endereco.Logradouro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psicologia.Domain.Validator.Endereco.Logradouro
{
    public class RemoveLogradouroValidator : AbstractValidator<RemoveLogradouroCommand>
    {
        public RemoveLogradouroValidator()
        {
            RuleFor(logradouro => logradouro.LogradouroName)
                .NotNull().WithMessage("Product's name can not be null")
                .NotEmpty().WithMessage("Product's name can not be empty")
                .Length(2, 25).WithMessage("Product's lenght have to be between 1 and 25 character");
        }
    }
}
