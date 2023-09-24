using Psicologia.Domain.Commands;
using Psicologia.Domain.Commands.Contracts;
using Psicologia.Domain.Commands.Endereco.Bairro;
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

    public CidadeEstadoHandler(ICidadeEstadoRepository cidadeEstadoRepository)
    {
        _cidadeEstadoRepository = cidadeEstadoRepository;
    }
    public ICommandResult Handle(CreateCidadeEstadoCommand command)
    {
        var cidadeEstado = new CidadeEstado(
            command.IdCidade,
            command.IdEstado);
        
        _cidadeEstadoRepository.Create(cidadeEstado);
        
        return new GenericCommandResult(
            true,
            "Bairro saved",
            cidadeEstado);
    }

    public ICommandResult Handle(UpdateCidadeEstadoCommand command)
    {
        var cidadeEstado = _cidadeEstadoRepository.GetById(
            command.IdCidade,
            command.IdEstado);
        
        _cidadeEstadoRepository.Update(cidadeEstado);
        
        return new GenericCommandResult(
            true,
            "CidadeEstado saved",
            cidadeEstado);
    }

    public ICommandResult Handle(RemoveCidadeEstadoCommand command)
    {
        var cidadeEstado = _cidadeEstadoRepository.GetById(
            command.IdCidade,
            command.IdEstado);
        
        _cidadeEstadoRepository.Remove(cidadeEstado);
        
        return new GenericCommandResult(
            true,
            "Bairro saved",
            cidadeEstado);
    }
}