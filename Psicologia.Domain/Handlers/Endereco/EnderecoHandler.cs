using System.Runtime.InteropServices;
using Psicologia.Domain.Commands;
using Psicologia.Domain.Commands.Contracts;
using Psicologia.Domain.Commands.Endereco;
using Psicologia.Domain.Commands.Endereco.Bairro;
using Psicologia.Domain.Commands.Endereco.Cidade;
using Psicologia.Domain.Commands.Endereco.Estado;
using Psicologia.Domain.Commands.Endereco.Logradouro;
using Psicologia.Domain.Commands.Endereco.NumeroEndereco;
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
    private readonly IPaisRepository _paisRepository;
    private readonly ETipoResidencia _eTipoResidencia;
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
        IPaisRepository paisRepository,
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
        _bairroCidadeRepository = bairroCidadeRepository;
        _cidadeEstadoRepository = cidadeEstadoRepository;
        _paisRepository = paisRepository;
        _eTipoResidencia = eTipoResidencia;
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
           cidadeEstado);
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