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
    public BairroCidadeHandler(
        IBairroCidadeRepository bairroCidadeRepository,
        IBairroRepository bairroRepository,
        ICidadeRepository cidadeRepository
    )
    {
        _bairroCidadeRepository = bairroCidadeRepository;
        _bairroRepository = bairroRepository;
        _cidadeRepository = cidadeRepository;
        ;
    }
    
    
    public ICommandResult Handle(
        CreateBairroCidadeCommand command)
    { 
        var bairro = _bairroRepository.GetById(command.IdBairro);
        var cidade = _cidadeRepository.GetById(command.IdCidade);
       
        var bairroCidade = new BairroCidade(
            bairro.Id,
            cidade.Id);
        
        _bairroCidadeRepository.Create(bairroCidade);
        
        return new GenericCommandResult(
            true,
            "BairroCidade saved",
            bairroCidade);
    }

    public ICommandResult Handle(UpdateBairroCidadeCommand command)
    {

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

        var bairroCidade = _bairroCidadeRepository.GetById(
            command.IdBairroCidade);
        
        _bairroCidadeRepository.Remove(bairroCidade);
        
        return new GenericCommandResult(
            true,
            "BairroCidade saved",
            bairroCidade);
    }
}