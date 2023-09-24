using Psicologia.Domain.Commands;
using Psicologia.Domain.Commands.Contracts;
using Psicologia.Domain.Commands.Endereco.Pais;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Handlers.Contracts;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Domain.Validator.Endereco.Pais;

namespace Psicologia.Domain.Handlers.Endereco;

public class PaisHandler :
    IHandler<CreatePaisCommand>,
    IHandler<UpdatePaisCommand>,
    IHandler<RemovePaisCommand>
{
    private readonly IPaisRepository _paisRepository;

    public PaisHandler(IPaisRepository paisRepository)
    {
        _paisRepository = paisRepository;
    }
    
    public ICommandResult Handle(CreatePaisCommand command)
    {
        var validator = new CreatePaisValidator();
        var validation = validator.Validate(command);
        
        if (validation.IsValid == false)
        {
            return new GenericCommandResult(
                false,
                "Ops, it is not valid",
                command);
        }

        var pais = new Pais(command.PaisName);
        _paisRepository.Create(pais);
        
        return new GenericCommandResult(
            true,
            "País saved",
            pais);
    }

    public ICommandResult Handle(UpdatePaisCommand command)
    {
        var validator = new UpdatePaisValidator();
        var validation = validator.Validate(command);
        
        if (validation.IsValid == false)
        {
            return new GenericCommandResult(
                false,
                "Ops, it is not valid",
                command);
        }

        var pais = _paisRepository.GetById(command.IdPais);
        _paisRepository.Update(pais);
        
        return new GenericCommandResult(
            true,
            "País saved",
            pais);
    }

    public ICommandResult Handle(RemovePaisCommand command)
    {
        var validator = new RemovePaisValidator();
        var validation = validator.Validate(command);
        
        if (validation.IsValid == false)
        {
            return new GenericCommandResult(
                false,
                "Ops, it is not valid",
                command);
        }

        var pais = _paisRepository.GetById(command.IdPais);
        _paisRepository.Remove(pais);
        
        return new GenericCommandResult(
            true,
            "País saved",
            pais);
    }
}