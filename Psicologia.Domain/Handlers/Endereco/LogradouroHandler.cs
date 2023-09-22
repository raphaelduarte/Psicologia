using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psicologia.Domain.Commands;
using Psicologia.Domain.Commands.Contracts;
using Psicologia.Domain.Commands.Endereco.Logradouro;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Handlers.Contracts;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Domain.Validator.Endereco.Logradouro;

namespace Psicologia.Domain.Handlers.Endereco
{
    public class LogradouroHandler : 
        IHandler<CreateLogradouroCommand>, 
        IHandler<UpdateLogradouroCommand>, 
        IHandler<RemoveLogradouroCommand>
    {
        private readonly ILogradouroRepository _logradouroRepository;
        
        public LogradouroHandler(ILogradouroRepository logradouroRepository)
        {
            _logradouroRepository = logradouroRepository;
        }
        
        public ICommandResult Handle(RemoveLogradouroCommand command)
        {
            var validator = new RemoveLogradouroValidator();
            var validation = validator.Validate(command);

            if (validation.IsValid == false)
            {
                return new GenericCommandResult(false, "Ops, it is not valid", command);
            };

            var logradouro = _logradouroRepository.GetById(command.Id);
            _logradouroRepository.Remove(logradouro);

            return new GenericCommandResult(true, "Product saved", logradouro);
        }
        
        public ICommandResult Handle(CreateLogradouroCommand command)
        {
            var validator = new CreateLogradouroValidator();
            var validation = validator.Validate(command);

            if (validation.IsValid == false)
            {
                return new GenericCommandResult(false, "Ops, it is not valid", command);
            };

            var logradouroName = new Logradouro(command.LogradouroName);
            _logradouroRepository.Create(logradouroName);

            return new GenericCommandResult(true, "Product saved", logradouroName);
        }

        public ICommandResult Handle(UpdateLogradouroCommand command)
        {
            var validator = new UpdateLogradouroValidator();
            var validation = validator.Validate(command);

            if (validation.IsValid == false)
            {
                return new GenericCommandResult(false, "Ops, it is not valid", command);
            }

            var logradouroCommand = _logradouroRepository.GetById(command.Id);
            _logradouroRepository.Update(logradouroCommand);

            return new GenericCommandResult(true, "Product saved", logradouroCommand);
        }
    }
}
