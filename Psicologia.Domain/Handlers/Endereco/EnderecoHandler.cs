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
using Psicologia.Domain.Queries.Endereco;

namespace Psicologia.Domain.Handlers.Endereco;

public class EnderecoHandler :
    IHandler<CreateEnderecoCommand>,
    IHandler<UpdateEnderecoCommand>,
    IHandler<RemoveEnderecoCommand>
{
    private Bairro _bairro { get; set; }
    private Cidade _cidade { get; set; }
    private Estado _estado { get; set; }
    private readonly IEnderecoRepository _enderecoRepository;
    private readonly ILogradouroRepository _logradouroRepository;
    private readonly INumeroEnderecoRepository _numeroEnderecoRepository;
    private readonly IPaisRepository _paisRepository;
    private readonly IBairroRepository _bairroRepository;
    private readonly ICidadeRepository _cidadeRepository;
    private readonly IEstadoRepository _estadoRepository;
    

    public EnderecoHandler(
        IEnderecoRepository enderecoRepository,
        ILogradouroRepository logradouroRepository,
        INumeroEnderecoRepository numeroEnderecoRepository,
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
        _paisRepository = paisRepository;
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
            var bairroCommand = BairroQueries
                .Get(command.Bairro.BairroName)
                .ToString();
            
            _bairro = _bairroRepository.GetByName(bairroCommand);


        }
        catch 
        {
            var bairroHandler = new BairroHandler(_bairroRepository);
            var bairroHandle = bairroHandler.Handle(command.Bairro);
            var bairro = new Bairro(bairroHandle.ToString());
            _bairro = bairro;
        }

        try
        {
            var cidadeCommand = CidadeQueries
                .Get(command.Cidade.CidadeName)
                .ToString();
            
            _cidade = _cidadeRepository
                .GetByName(cidadeCommand);
        }
        catch 
        {
            var cidadeHandler = new CidadeHandler(_cidadeRepository);
            var cidadeHandle = cidadeHandler.Handle(command.Cidade);
            var cidade = new Cidade(cidadeHandle.ToString());
            _cidade = cidade;
        }

        try
        {
            var estadoCommand = EstadoQueries
                .Get(command.Estado.EstadoName)
                .ToString();

            _estado = _estadoRepository
                .GetByName(estadoCommand);

        }
        catch 
        {
            var estadoHandler = new EstadoHandler(_estadoRepository);
            var estadoHandle = estadoHandler.Handle(command.Estado);
            var estado = new Estado(estadoHandle.ToString());
            _estado = estado;
        }
        


        var eTipoResidencia = command.ETipoResidencia;

        var endereco = new Entities.Endereco.Endereco(
           logradouro,
           numero,
           eTipoResidencia,
           pais);
       
       _enderecoRepository.Create(endereco);
       
       return new GenericCommandResult(
           true,
           "Endereco saved", endereco
           );
    }

    public ICommandResult Handle(UpdateEnderecoCommand command)
    {
        var logradouroHandler = new LogradouroHandler(_logradouroRepository);
        var logradouroHandle = logradouroHandler.Handle(command.Logradouro);
        var logradouro = _logradouroRepository.GetById(command.Logradouro.Id);
        _logradouroRepository.UpdateLogradouroName(logradouroHandle.ToString());
        _logradouroRepository.Update(logradouro);
        
        var numeroHandler = new NumeroEnderecoHandler(_numeroEnderecoRepository);
        var numeroHandle = numeroHandler.Handle(command.Numero);
        var numero = _numeroEnderecoRepository.GetById(command.Numero.Id);
        _numeroEnderecoRepository.UpdateNumero(int.Parse(numeroHandle.ToString()));
        _numeroEnderecoRepository.Update(numero);
        
        var paisHandler = new PaisHandler(_paisRepository);
        var paisHandle = paisHandler.Handle(command.Pais);
        var pais = _paisRepository.GetById(command.Pais.IdPais);
        _paisRepository.UpdatePaisName(paisHandle.ToString());
        _paisRepository.Update(pais);

        var eTipoResidencia = command.ETipoResidencia;
        
        var bairroHandler = new BairroHandler(_bairroRepository);
        var bairroHandle = bairroHandler.Handle(command.Bairro);
        var bairro = _bairroRepository.GetById(command.Bairro.Id);
        _bairroRepository.UpdateBairroName(bairroHandle.ToString());
        _bairroRepository.Update(bairro);
        
        var cidadeHandler = new CidadeHandler(_cidadeRepository);
        var cidadeHandle = cidadeHandler.Handle(command.Cidade);
        var cidade = _cidadeRepository.GetById(command.Cidade.Id);
        _cidadeRepository.UpdateCidadeName(cidadeHandle.ToString());
        _cidadeRepository.Update(cidade);
        
        var estadoHandler = new EstadoHandler(_estadoRepository);
        var estadoHandle = estadoHandler.Handle(command.Estado);
        var estado = _estadoRepository.GetById(command.Estado.IdEstado);
        _estadoRepository.UpdateEstadoName(estadoHandle.ToString());
        _estadoRepository.Update(estado);


        var endereco = _enderecoRepository.GetById(command.IdEndereco);
        _enderecoRepository.Update(endereco);
        
        return new GenericCommandResult(
            true,
            "Endereco saved",
            endereco);
    }

    public ICommandResult Handle(RemoveEnderecoCommand command)
    {
        var logradouro = _logradouroRepository.GetById(command.Logradouro.Id);
        _logradouroRepository.Remove(logradouro);
        
        var numero = _numeroEnderecoRepository.GetById(command.Numero.Id);
        _numeroEnderecoRepository.Remove(numero);
        
        var eTipoResidencia = command.ETipoResidencia;
        
        var bairro = _bairroRepository.GetById(command.Bairro.Id);
        _bairroRepository.Remove(bairro);
        
        var cidade = _cidadeRepository.GetById(command.Cidade.Id);
        _cidadeRepository.Remove(cidade);
        
        var estado = _estadoRepository.GetById(command.Estado.IdEstado);
        _estadoRepository.Remove(estado);
        
        var pais = _paisRepository.GetById(command.Pais.IdPais);
        _paisRepository.Remove(pais);

        var endereco = _enderecoRepository.GetById(command.IdEndereco);

        _enderecoRepository.Remove(endereco);
        
        return new GenericCommandResult(
            true,
            "Endereco saved",
            endereco);
    }
}