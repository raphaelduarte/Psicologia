using Psicologia.Domain.Commands;
using Psicologia.Domain.Commands.Contracts;
using Psicologia.Domain.Commands.Endereco.Bairro;
using Psicologia.Domain.Commands.Endereco.Cidade;
using Psicologia.Domain.Commands.Endereco.CidadeEstado;
using Psicologia.Domain.Commands.Endereco.Estado;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Handlers.Contracts;
using Psicologia.Domain.Repositories.Endereco;

namespace Psicologia.Domain.Handlers.Endereco;

public class CidadeEstadoHandler :
    IHandler<CreateCidadeEstadoCommand>,
    IHandler<UpdateCidadeEstadoCommand>,
    IHandler<RemoveCidadeEstadoCommand>
{
    private readonly ICidadeEstadoRepository _cidadeEstadoRepository;
    private readonly ICidadeRepository _cidadeRepository;
    private readonly IEstadoRepository _estadoRepository;
    private readonly CreateEstadoCommand _createEstadoCommand;
    private readonly CreateCidadeCommand _createCidadeCommand;
    private readonly UpdateEstadoCommand _updateEstadoCommand;
    private readonly UpdateCidadeCommand _updateCidadeCommand;
    private readonly RemoveEstadoCommand _removeEstadoCommand;
    private readonly RemoveCidadeCommand _removeCidadeCommand;

    public CidadeEstadoHandler(
        ICidadeEstadoRepository cidadeEstadoRepository,
        IEstadoRepository estadoRepository,
        ICidadeRepository cidadeRepository,
        CreateEstadoCommand createEstadoCommand,
        CreateCidadeCommand createCidadeCommand,
        UpdateEstadoCommand updateEstadoCommand,
        UpdateCidadeCommand updateCidadeCommand,
        RemoveEstadoCommand removeEstadoCommand,
        RemoveCidadeCommand removeCidadeCommand)
    {
        _cidadeEstadoRepository = cidadeEstadoRepository;
        _estadoRepository = estadoRepository;
        _cidadeRepository = cidadeRepository;
        _createEstadoCommand = createEstadoCommand;
        _createCidadeCommand = createCidadeCommand;
        _updateEstadoCommand = updateEstadoCommand;
        _updateCidadeCommand = updateCidadeCommand;
        _removeEstadoCommand = removeEstadoCommand;
        _removeCidadeCommand = removeCidadeCommand;
    }
    public ICommandResult Handle(CreateCidadeEstadoCommand command)
    {
        var cidadeHandler = new CidadeHandler(_cidadeRepository);
        var estadoHandler = new EstadoHandler(_estadoRepository);

        cidadeHandler.Handle(_createCidadeCommand);
        estadoHandler.Handle(_createEstadoCommand);

        var cidade = _cidadeRepository.GetById(command.IdCidade);
        var estado = _estadoRepository.GetById(command.IdEstado);
        
        var cidadeEstado = new CidadeEstado(
            cidade,
            estado);
        
        _cidadeEstadoRepository.Create(cidadeEstado);
        
        return new GenericCommandResult(
            true,
            "CidadeEstado saved",
            cidadeEstado);
    }

    public ICommandResult Handle(UpdateCidadeEstadoCommand command)
    {
        var cidadeHandler = new CidadeHandler(_cidadeRepository);
        var estadoHandler = new EstadoHandler(_estadoRepository);

        cidadeHandler.Handle(_updateCidadeCommand);
        estadoHandler.Handle(_updateEstadoCommand);
        
        var cidadeEstado = _cidadeEstadoRepository.GetById(
            command.IdCidadeEstado);
        
        _cidadeEstadoRepository.Update(cidadeEstado);
        
        return new GenericCommandResult(
            true,
            "CidadeEstado saved",
            cidadeEstado);
    }

    public ICommandResult Handle(RemoveCidadeEstadoCommand command)
    {
        var cidadeHandler = new CidadeHandler(_cidadeRepository);
        var estadoHandler = new EstadoHandler(_estadoRepository);

        cidadeHandler.Handle(_updateCidadeCommand);
        estadoHandler.Handle(_updateEstadoCommand);
        
        var cidadeEstado = _cidadeEstadoRepository.GetById(
            command.IdCidadeEstado);
        
        _cidadeEstadoRepository.Remove(cidadeEstado);
        
        return new GenericCommandResult(
            true,
            "CidadeEstado saved",
            cidadeEstado);
    }
}