using System.Linq.Expressions;
using System.Security.AccessControl;
using Psicologia.Domain.Commands;
using Psicologia.Domain.Commands.Contracts;
using Psicologia.Domain.Commands.Endereco;
using Psicologia.Domain.Commands.Endereco.Bairro;
using Psicologia.Domain.Commands.Endereco.Logradouro;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Handlers.Contracts;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Domain.Entities.Endereco;

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
    private readonly ETipoResidencia _eTipoResidencia;
    private readonly IBairroRepository _bairroRepository;
    private readonly ICidadeRepository _cidadeRepository;
    private readonly IEstadoRepository _estadoRepository;
    

    public EnderecoHandler(
        IEnderecoRepository enderecoRepository,
        ILogradouroRepository logradouroRepository,
        INumeroEnderecoRepository numeroEnderecoRepository,
        ETipoResidencia eTipoResidencia,
        IBairroCidadeRepository bairroCidadeRepository,
        ICidadeEstadoRepository cidadeEstadoRepository,
        IBairroRepository bairroRepository,
        ICidadeRepository cidadeRepository,
        IEstadoRepository estadoRepository,
        IPaisRepository paisRepository
    )
    {
        _enderecoRepository = enderecoRepository;
        _logradouroRepository = logradouroRepository;
        _numeroEnderecoRepository = numeroEnderecoRepository;
        _bairroRepository = bairroRepository;
        _cidadeRepository = cidadeRepository;
        _estadoRepository = estadoRepository;
        _bairroCidadeRepository = bairroCidadeRepository;
        _cidadeEstadoRepository = cidadeEstadoRepository;
        _paisRepository = paisRepository;
        _eTipoResidencia = eTipoResidencia;
    }
    public ICommandResult Handle(CreateEnderecoCommand command)
    {
        var logradouroHandler = new LogradouroHandler(_logradouroRepository);
        var logradouroHandle = logradouroHandler.Handle(command.Logradouro);
        var logradouro = new Logradouro(logradouroHandle.ToString());
        
        var numeroHandler = new NumeroEnderecoHandler(_numeroEnderecoRepository);
        var numeroHandle = numeroHandler.Handle(command.Numero);
        var numero = new NumeroEndereco(int.Parse(numeroHandle.ToString()));
        
        var paisHandler = new PaisHandler(_paisRepository);
        var paisHandle = paisHandler.Handle(command.Pais);
        var pais = new Pais(paisHandle.ToString());

        try
        {
            Expression<Func<Bairro, bool>> GetBairro(CreateEnderecoCommand command)
            {
                return x => x.BairroName == command.Bairro.BairroName;
            }
        }
        catch
        {
            var bairroCommandResult = new GenericCommandResult(false,
                "Bairro not found",
                command.Bairro.BairroName);

            bairroCommandResult.Message.ToString();
        }
        
        
        
        var bairroHandler = new BairroHandler(_bairroRepository);
        var bairroHandle = bairroHandler.Handle(command.Bairro);
        var bairro = new Bairro(bairroHandle.ToString());
        
        

        var cidadeHandler = new CidadeHandler(_cidadeRepository);
        var cidadeHandle = cidadeHandler.Handle(command.Cidade);
        var cidade = new Cidade(cidadeHandle.ToString());

        var estadoHandler = new EstadoHandler(_estadoRepository);
        var estadoHandle = estadoHandler.Handle(command.Estado);
        var estado = new Estado(estadoHandle.ToString());
        
        var bairroCidade = new BairroCidade(
            bairro.Id,
            cidade.Id);

        var cidadeEstado = new CidadeEstado(
            cidade.Id,
            estado.Id);


        var eTipoResidencia = _eTipoResidencia;

        var endereco = new Entities.Endereco.Endereco(
           logradouro,
           numero,
           eTipoResidencia,
           bairroCidade,
           cidadeEstado,
           pais);
       
       _enderecoRepository.Create(endereco);
       
       return new GenericCommandResult(
           true,
           "Endereco saved", endereco
           );
    }

    public ICommandResult Handle(UpdateEnderecoCommand command)
    {
        var logradouro = _logradouroRepository.GetById(command.Logradouro);
        var numero = _numeroEnderecoRepository.GetById(command.Numero);
        var eTipoResidencia = _eTipoResidencia;
        var bairroCidade = _bairroCidadeRepository.GetById(command.BairroCidade);
        var cidadeEstado = _cidadeEstadoRepository.GetById(command.CidadeEstado);
        var pais = _paisRepository.GetById(command.Pais);
        
        var endereco = new Entities.Endereco.Endereco(
            logradouro,
            numero,
            eTipoResidencia,
            bairroCidade,
            cidadeEstado,
            pais);
        
        _enderecoRepository.Update(endereco);
        
        return new GenericCommandResult(
            true,
            "Endereco saved",
            endereco);
    }

    public ICommandResult Handle(RemoveEnderecoCommand command)
    {
        var logradouro = _logradouroRepository.GetById(command.Logradouro);
        var numero = _numeroEnderecoRepository.GetById(command.Numero);
        var eTipoResidencia = _eTipoResidencia;
        var bairroCidade = _bairroCidadeRepository.GetById(command.BairroCidade);
        var cidadeEstado = _cidadeEstadoRepository.GetById(command.CidadeEstado);
        var pais = _paisRepository.GetById(command.Pais);
        
        var endereco = new Entities.Endereco.Endereco(
            logradouro,
            numero,
            eTipoResidencia,
            bairroCidade,
            cidadeEstado,
            pais);
        
        _enderecoRepository.Remove(endereco);
        
        return new GenericCommandResult(
            true,
            "Endereco saved",
            endereco);
    }
}