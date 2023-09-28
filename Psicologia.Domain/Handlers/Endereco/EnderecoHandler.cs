using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Psicologia.Domain.Commands;
using Psicologia.Domain.Commands.Contracts;
using Psicologia.Domain.Commands.Endereco;
using Psicologia.Domain.Commands.Endereco.Bairro;
using Psicologia.Domain.Commands.Endereco.Cidade;
using Psicologia.Domain.Commands.Endereco.Estado;
using Psicologia.Domain.Commands.Endereco.Logradouro;
using Psicologia.Domain.Commands.Endereco.NumeroEndereco;
using Psicologia.Domain.Commands.Endereco.Pais;
using Psicologia.Domain.Entities.Endereco;
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
    private readonly IBairroRepository _bairroRepository;
    private readonly ICidadeRepository _cidadeRepository;
    private readonly IEstadoRepository _estadoRepository;
    private readonly IPaisRepository _paisRepository;
    private readonly ETipoResidencia _eTipoResidencia;
    private readonly CreatePaisCommand _createPaisCommand;
    private readonly UpdatePaisCommand _updatePaisCommand;
    private readonly RemovePaisCommand _removePaisCommand;
    private readonly CreateEstadoCommand _createEstadoCommand;
    private readonly CreateCidadeCommand _createCidadeCommand;
    private readonly UpdateEstadoCommand _updateEstadoCommand;
    private readonly UpdateCidadeCommand _updateCidadeCommand;
    private readonly RemoveEstadoCommand _removeEstadoCommand;
    private readonly RemoveCidadeCommand _removeCidadeCommand;
    private readonly CreateBairroCommand _createBairroCommand;
    private readonly CreateLogradouroCommand _createLogradouroCommand;
    private readonly UpdateBairroCommand _updateBairroCommand;
    private readonly UpdateLogradouroCommand _updateLogradouroCommand;
    private readonly RemoveBairroCommand _removeBairroCommand;
    private readonly RemoveLogradouroCommand _removeLogradouroCommand;
    private readonly CreateNumeroEnderecoCommand _createNumeroEnderecoCommand;
    private readonly UpdateNumeroEnderecoCommand _updateNumeroEnderecoCommand;
    private readonly RemoveNumeroEnderecoCommand _removeNumeroEnderecoCommand;
    



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
        IPaisRepository paisRepository,
        CreatePaisCommand createPaisCommand,
        UpdatePaisCommand updatePaisCommand,
        RemovePaisCommand removePaisCommand,
        CreateEstadoCommand createEstadoCommand,
        CreateCidadeCommand createCidadeCommand,
        UpdateEstadoCommand updateEstadoCommand,
        UpdateCidadeCommand updateCidadeCommand,
        RemoveEstadoCommand removeEstadoCommand,
        RemoveCidadeCommand removeCidadeCommand,
        CreateBairroCommand createBairroCommand,
        CreateLogradouroCommand createLogradouroCommand,
        UpdateBairroCommand updateBairroCommand,
        UpdateLogradouroCommand updateLogradouroCommand,
        RemoveBairroCommand removeBairroCommand,
        RemoveLogradouroCommand removeLogradouroCommand,
        CreateNumeroEnderecoCommand createNumeroEnderecoCommand,
        UpdateNumeroEnderecoCommand updateNumeroEnderecoCommand,
        RemoveNumeroEnderecoCommand removeNumeroEnderecoCommand
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
        _createPaisCommand = createPaisCommand;
        _updatePaisCommand = updatePaisCommand;
        _removePaisCommand = removePaisCommand;
        _createEstadoCommand = createEstadoCommand;
        _createCidadeCommand = createCidadeCommand;
        _updateEstadoCommand = updateEstadoCommand;
        _updateCidadeCommand = updateCidadeCommand;
        _removeEstadoCommand = removeEstadoCommand;
        _removeCidadeCommand = removeCidadeCommand;
        _createBairroCommand = createBairroCommand;
        _updateBairroCommand = updateBairroCommand;
        _removeBairroCommand = removeBairroCommand;
        _createLogradouroCommand = createLogradouroCommand;
        _updateLogradouroCommand = updateLogradouroCommand;
        _removeLogradouroCommand = removeLogradouroCommand;
        _createNumeroEnderecoCommand = createNumeroEnderecoCommand;
        _updateNumeroEnderecoCommand = updateNumeroEnderecoCommand;
        _removeNumeroEnderecoCommand = removeNumeroEnderecoCommand;
    }
    public ICommandResult Handle(CreateEnderecoCommand command)
    {
        var logradouroHandler = new LogradouroHandler(_logradouroRepository);
        var numeroHandler = new NumeroEnderecoHandler(_numeroEnderecoRepository);
        var bairroHandler = new BairroHandler(_bairroRepository);
        var cidadeHandler = new CidadeHandler(_cidadeRepository);
        var estadoHandler = new EstadoHandler(_estadoRepository);
        var paisHandler = new PaisHandler(_paisRepository);

        logradouroHandler.Handle(_createLogradouroCommand);
        numeroHandler.Handle(_createNumeroEnderecoCommand);
        bairroHandler.Handle(_createBairroCommand);
        cidadeHandler.Handle(_createCidadeCommand);
        estadoHandler.Handle(_createEstadoCommand);
        paisHandler.Handle(_createPaisCommand);
        
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
       
       _enderecoRepository.Create(endereco);
       
       return new GenericCommandResult(
           true,
           "Endereco saved",
           endereco);
    }

    public ICommandResult Handle(UpdateEnderecoCommand command)
    {
        var logradouroHandler = new LogradouroHandler(_logradouroRepository);
        var numeroHandler = new NumeroEnderecoHandler(_numeroEnderecoRepository);
        var bairroHandler = new BairroHandler(_bairroRepository);
        var cidadeHandler = new CidadeHandler(_cidadeRepository);
        var estadoHandler = new EstadoHandler(_estadoRepository);
        var paisHandler = new PaisHandler(_paisRepository);

        logradouroHandler.Handle(_updateLogradouroCommand);
        numeroHandler.Handle(_updateNumeroEnderecoCommand);
        bairroHandler.Handle(_updateBairroCommand);
        cidadeHandler.Handle(_updateCidadeCommand);
        estadoHandler.Handle(_updateEstadoCommand);
        paisHandler.Handle(_updatePaisCommand);
        
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
        var logradouroHandler = new LogradouroHandler(_logradouroRepository);
        var numeroHandler = new NumeroEnderecoHandler(_numeroEnderecoRepository);
        var bairroHandler = new BairroHandler(_bairroRepository);
        var cidadeHandler = new CidadeHandler(_cidadeRepository);
        var estadoHandler = new EstadoHandler(_estadoRepository);
        var paisHandler = new PaisHandler(_paisRepository);

        logradouroHandler.Handle(_removeLogradouroCommand);
        numeroHandler.Handle(_removeNumeroEnderecoCommand);
        bairroHandler.Handle(_removeBairroCommand);
        cidadeHandler.Handle(_removeCidadeCommand);
        estadoHandler.Handle(_removeEstadoCommand);
        paisHandler.Handle(_removePaisCommand);
        
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