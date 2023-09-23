using Psicologia.Domain.Commands;
using Psicologia.Domain.Commands.Contracts;
using Psicologia.Domain.Commands.Endereco.Estado;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Handlers.Contracts;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Domain.Validator.Endereco.Estado;

namespace Psicologia.Domain.Handlers.Endereco;

public class EstadoHandler :
    IHandler<CreateEstadoCommand>,
    IHandler<UpdateEstadoCommand>,
    IHandler<RemoveEstadoCommand>
{
    private readonly IEstadoRepository _estadoRepository;

    public EstadoHandler(IEstadoRepository estadoRepository)
    {
        _estadoRepository = estadoRepository;
    }
    public ICommandResult Handle(CreateEstadoCommand command)
    {
        var validator = new CreateEstadoValidator();
        var validation = validator.Validate(command);
        
        if (validation.IsValid == false)
        {
            return new GenericCommandResult(false, "Ops, it is not valid", command);
        }

        var estado = new Estado(command.EstadoName);
        _estadoRepository.Create(estado);
        
        return new GenericCommandResult(true, "Estado saved", estado);
    }

    public ICommandResult Handle(UpdateEstadoCommand command)
    {
        var validator = new UpdateEstadoValidator();
        var validation = validator.Validate(command);
        
        if (validation.IsValid == false)
        {
            return new GenericCommandResult(false, "Ops, it is not valid", command);
        }

        var estado = _estadoRepository.GetById(command.IdEstado);
        _estadoRepository.Update(estado);
        
        return new GenericCommandResult(true, "Estado saved", estado);
    }

    public ICommandResult Handle(RemoveEstadoCommand command)
    {
        var validator = new RemoveEstadoValidator();
        var validation = validator.Validate(command);
        
        if (validation.IsValid == false)
        {
            return new GenericCommandResult(false, "Ops, it is not valid", command);
        }

        var estado = _estadoRepository.GetById(command.IdEstado);
        _estadoRepository.Remove(estado);
        
        return new GenericCommandResult(true, "Estado saved", estado);
    }
}