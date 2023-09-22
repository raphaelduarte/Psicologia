using Psicologia.Domain.Commands;
using Psicologia.Domain.Commands.Contracts;
using Psicologia.Domain.Commands.Endereco.NumeroEndereco;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Handlers.Contracts;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Domain.Validator.Endereco.NumeroEndereco;

namespace Psicologia.Domain.Handlers.Endereco;
    
    public class NumeroEnderecoHandler : 
        IHandler<CreateNumeroEnderecoCommand>, 
        IHandler<UpdateNumeroEnderecoCommand>, 
        IHandler<RemoveNumeroEnderecoCommand>
    {
        private readonly INumeroEnderecoRepository _numeroEnderecoRepository;
        
        public ICommandResult Handle(RemoveNumeroEnderecoCommand command)
        {
            var validator = new RemoveNumeroEnderecoValidator();
            var validation = validator.Validate(command);

            if (validation.IsValid == false)
            {
                return new GenericCommandResult(false, "Ops, it is not valid", command);
            };

            var numeroEndereco = _numeroEnderecoRepository.GetById(command.Id);
            _numeroEnderecoRepository.Remove(numeroEndereco);

            return new GenericCommandResult(true, "Number saved", numeroEndereco);
        }

        public NumeroEnderecoHandler(INumeroEnderecoRepository numeroEnderecoRepository)
        {
            _numeroEnderecoRepository = numeroEnderecoRepository;
        }
        public ICommandResult Handle(CreateNumeroEnderecoCommand command)
        {
            var validator = new CreateNumeroEnderecoValidator();
            var validation = validator.Validate(command);

            if (validation.IsValid == false)
            {
                return new GenericCommandResult(false, "Ops, it is not valid", command);
            };

            var numeroEndereco = new NumeroEndereco(command.NumeroEndereco);
            _numeroEnderecoRepository.Create(numeroEndereco);

            return new GenericCommandResult(true, "Number saved", numeroEndereco);
        }

        public ICommandResult Handle(UpdateNumeroEnderecoCommand command)
        {
            var validator = new UpdateNumeroEnderecoValidator();
            var validation = validator.Validate(command);

            if (validation.IsValid == false)
            {
                return new GenericCommandResult(false, "Ops, it is not valid", command);
            }

            var numeroEnderecoCommand = _numeroEnderecoRepository.GetById(command.Id);
            _numeroEnderecoRepository.Update(numeroEnderecoCommand);

            return new GenericCommandResult(true, "Number saved", numeroEnderecoCommand);
        }
    }
