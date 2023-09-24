using Psicologia.Domain.Commands;
using Psicologia.Domain.Commands.Contracts;
using Psicologia.Domain.Commands.Endereco.Bairro;
using Psicologia.Domain.Commands.Endereco.BairroCidade;
using Psicologia.Domain.Commands.Endereco.Cidade;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Handlers.Contracts;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Domain.Validator.Endereco.Logradouro;

namespace Psicologia.Domain.Handlers.Endereco;

public class BairroCidadeHandler :
    IHandler<CreateBairroCidadeCommand>,
    IHandler<UpdateBairroCidadeCommand>,
    IHandler<RemoveBairroCidadeCommand>
{
    private readonly IBairroCidadeRepository _bairroCidadeRepository;
    private readonly IBairroRepository _bairroRepository;
    private readonly ICidadeRepository _cidadeRepository;
    private readonly CreateBairroCommand _createBairroCommand;
    private readonly CreateCidadeCommand _createCidadeCommand;
    private readonly UpdateBairroCommand _updateBairroCommand;
    private readonly UpdateCidadeCommand _updateCidadeCommand;
    private readonly RemoveBairroCommand _removeBairroCommand;
    private readonly RemoveCidadeCommand _removeCidadeCommand;
    
    public BairroCidadeHandler(
        IBairroCidadeRepository bairroCidadeRepository,
        IBairroRepository bairroRepository,
        ICidadeRepository cidadeRepository,
        CreateBairroCommand createBairroCommand,
        CreateCidadeCommand createCidadeCommand,
        UpdateBairroCommand updateBairroCommand,
        UpdateCidadeCommand updateCidadeCommand,
        RemoveBairroCommand removeBairroCommand,
        RemoveCidadeCommand removeCidadeCommand)
    {
        _bairroCidadeRepository = bairroCidadeRepository;
        _bairroRepository = bairroRepository;
        _cidadeRepository = cidadeRepository;
        _createBairroCommand = createBairroCommand;
        _createCidadeCommand = createCidadeCommand;
        _updateBairroCommand = updateBairroCommand;
        _updateCidadeCommand = updateCidadeCommand;
        _removeBairroCommand = removeBairroCommand;
        _removeCidadeCommand = removeCidadeCommand;
    }
    
    
    public ICommandResult Handle(
        CreateBairroCidadeCommand command)
    {
        var bairroHandler = new BairroHandler(_bairroRepository);
        var cidadeHandler = new CidadeHandler(_cidadeRepository);

        bairroHandler.Handle(_createBairroCommand);
        cidadeHandler.Handle(_createCidadeCommand);
        
       var bairro = _bairroRepository.GetById(command.IdBairro);
       var cidade = _cidadeRepository.GetById(command.IdCidade);
       
        var bairroCidade = new BairroCidade(
            bairro,
            cidade);
        
        _bairroCidadeRepository.Create(bairroCidade);
        
        return new GenericCommandResult(
            true,
            "BairroCidade saved",
            bairroCidade);
    }

    public ICommandResult Handle(UpdateBairroCidadeCommand command)
    {
        var bairroHandler = new BairroHandler(_bairroRepository);
        var cidadeHandler = new CidadeHandler(_cidadeRepository);

        bairroHandler.Handle(_updateBairroCommand);
        cidadeHandler.Handle(_updateCidadeCommand);
        
        var bairroCidade = _bairroCidadeRepository.GetById(
            command.IdBairroCidade);
        
        _bairroCidadeRepository.Update(bairroCidade);
        
        return new GenericCommandResult(
            true,
            "BairroCidade saved",
            bairroCidade);
    }

    public ICommandResult Handle(RemoveBairroCidadeCommand command)
    {
        var bairroHandler = new BairroHandler(_bairroRepository);
        var cidadeHandler = new CidadeHandler(_cidadeRepository);

        bairroHandler.Handle(_removeBairroCommand);
        cidadeHandler.Handle(_removeCidadeCommand);
        
        var bairroCidade = _bairroCidadeRepository.GetById(
            command.IdBairroCidade);
        
        _bairroCidadeRepository.Remove(bairroCidade);
        
        return new GenericCommandResult(
            true,
            "BairroCidade saved",
            bairroCidade);
    }
}