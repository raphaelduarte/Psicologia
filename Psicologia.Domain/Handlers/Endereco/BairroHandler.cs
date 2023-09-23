using Psicologia.Domain.Commands;
using Psicologia.Domain.Commands.Contracts;
using Psicologia.Domain.Commands.Endereco.Bairro;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Handlers.Contracts;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Domain.Validator.Endereco.Logradouro;

namespace Psicologia.Domain.Handlers.Endereco;

public class BairroHandler :
    IHandler<CreateBairroCommand>,
    IHandler<RemoveBairroCommand>,
    IHandler<UpdateBairroCommand>
{
    private readonly IBairroRepository _bairroRepository;

    public BairroHandler(IBairroRepository bairroRepository)
    {
        _bairroRepository = _bairroRepository;
    }

    public ICommandResult Handle(CreateBairroCommand command)
    {
        var validator = new CreateBairroValidator();
        var validation = validator.Validate(command);

        if (validation.IsValid == false)
        {
            return new GenericCommandResult(false, "Ops, it is not valid", command);
        }

        var bairroName = new Bairro(command.BairroName);
        _bairroRepository.Create(bairroName);
        
        return new GenericCommandResult(true, "Bairro saved", bairroName);
    }

    public ICommandResult Handle(RemoveBairroCommand command)
    {
        var validator = new RemoveBairroValidator();
        var validation = validator.Validate(command);

        if (validation.IsValid == false)
        {
            return new GenericCommandResult(false, "Ops, it is not valid", command);
        }

        var bairro = _bairroRepository.GetById(command.Id);
        _bairroRepository.Remove(bairro);
        
        return new GenericCommandResult(true, "Bairro saved", bairro);
    }

    public ICommandResult Handle(UpdateBairroCommand command)
    {
        var validator = new UpdateBairroValidator();
        var validation = validator.Validate(command);
        
        if (validation.IsValid == false)
        {
            return new GenericCommandResult(false, "Ops, it is not valid", command);
        }
        
        var bairro = _bairroRepository.GetById(command.Id);
        
        _bairroRepository.Update(bairro);
        
        return new GenericCommandResult(true, "Bairro saved", bairro);
    }
}