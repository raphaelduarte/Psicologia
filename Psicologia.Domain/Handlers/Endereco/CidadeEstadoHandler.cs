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

    public CidadeEstadoHandler(
        ICidadeEstadoRepository cidadeEstadoRepository,
        ICidadeRepository cidadeRepository,
        IEstadoRepository estadoRepository
        )
    {
        _cidadeEstadoRepository = cidadeEstadoRepository;
        _cidadeRepository = cidadeRepository;
        _estadoRepository = estadoRepository;
    }
    public ICommandResult Handle(CreateCidadeEstadoCommand command)
    {
        var cidade = _cidadeRepository.GetById(command.IdCidade);
        var estado = _estadoRepository.GetById(command.IdEstado);
        
        var cidadeEstado = new CidadeEstado(
            cidade.Id,
            estado.Id);
        
        _cidadeEstadoRepository.Create(cidadeEstado);
        
        return new GenericCommandResult(
            true,
            "CidadeEstado saved",
            cidadeEstado);
    }

    public ICommandResult Handle(UpdateCidadeEstadoCommand command)
    {
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
        var cidadeEstado = _cidadeEstadoRepository.GetById(
            command.IdCidadeEstado);
        
        _cidadeEstadoRepository.Remove(cidadeEstado);
        
        return new GenericCommandResult(
            true,
            "CidadeEstado saved",
            cidadeEstado);
    }
}