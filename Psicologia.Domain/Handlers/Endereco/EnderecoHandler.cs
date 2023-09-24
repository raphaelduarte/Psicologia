using Psicologia.Domain.Commands.Contracts;
using Psicologia.Domain.Commands.Endereco;
using Psicologia.Domain.Commands.Endereco.NumeroEndereco;
using Psicologia.Domain.Handlers.Contracts;
using Psicologia.Domain.Repositories.Endereco;

namespace Psicologia.Domain.Handlers.Endereco;

public class EnderecoHandler :
    IHandler<CreateEnderecoCommand>,
    IHandler<UpdateEnderecoCommand>,
    IHandler<RemoveEnderecoCommand>
{
    private readonly IEnderecoRepository _enderecoRepository;
    private readonly ILogradouroRepository _logradouroRepository;
    private readonly INumeroEnderecoRepository _numeroEnderecoRepository;
    private readonly IBairroCidadeRepository _bairroCidadeRepository;
    private readonly ICidadeEstadoRepository _cidadeEstadoRepository;
    private readonly IPaisRepository _paisRepository;
    

    public EnderecoHandler(
        IEnderecoRepository enderecoRepository,
        ILogradouroRepository logradouroRepository,
        INumeroEnderecoRepository numeroEnderecoRepository,
        IBairroCidadeRepository bairroCidadeRepository,
        ICidadeEstadoRepository cidadeEstadoRepository,
        IPaisRepository paisRepository
        )
    {
        _enderecoRepository = enderecoRepository;
        _logradouroRepository = logradouroRepository;
        _numeroEnderecoRepository = numeroEnderecoRepository;
        _bairroCidadeRepository = bairroCidadeRepository;
        _cidadeEstadoRepository = cidadeEstadoRepository;
        _paisRepository = paisRepository;
    }
    public ICommandResult Handle(CreateEnderecoCommand command)
    {
        _logradouroRepository.GetById(command.IdLogradouro);
        _numeroEnderecoRepository.GetById(command.IdNumero);
        _bairroCidadeRepository.GetById(command.IdBairroCidade);
        _cidadeEstadoRepository.GetById(command.IdCidadeEstado);
        _paisRepository.GetById(command.IdPais);
    }

    public ICommandResult Handle(UpdateEnderecoCommand command)
    {
        throw new NotImplementedException();
    }

    public ICommandResult Handle(RemoveEnderecoCommand command)
    {
        throw new NotImplementedException();
    }
}