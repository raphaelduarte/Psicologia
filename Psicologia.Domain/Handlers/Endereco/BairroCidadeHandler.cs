using Psicologia.Domain.Commands;
using Psicologia.Domain.Commands.Contracts;
using Psicologia.Domain.Commands.Endereco.BairroCidade;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Handlers.Contracts;
using Psicologia.Domain.Repositories.Endereco;

namespace Psicologia.Domain.Handlers.Endereco;

public class BairroCidadeHandler :
    IHandler<CreateBairroCidadeCommand>,
    IHandler<UpdateBairroCidadeCommand>,
    IHandler<RemoveBairroCidadeCommand>
{
    private readonly IBairroCidadeRepository _bairroCidadeRepository;

    public BairroCidadeHandler(IBairroCidadeRepository bairroCidadeRepository)
    {
        _bairroCidadeRepository = bairroCidadeRepository;
    }
    
    
    public ICommandResult Handle(CreateBairroCidadeCommand command)
    {
        var bairroCidade = new BairroCidade(
            command.IdBairro,
            command.IdCidade);
        
        _bairroCidadeRepository.Create(bairroCidade);
        
        return new GenericCommandResult(
            true,
            "Bairro saved",
            bairroCidade);
    }

    public ICommandResult Handle(UpdateBairroCidadeCommand command)
    {
        var bairroCidade = _bairroCidadeRepository.GetById(
            command.IdBairro,
            command.IdCidade);
        
        _bairroCidadeRepository.Update(bairroCidade);
        
        return new GenericCommandResult(
            true,
            "BairroCidade saved",
            bairroCidade);
    }

    public ICommandResult Handle(RemoveBairroCidadeCommand command)
    {
        var bairroCidade = _bairroCidadeRepository.GetById(
            command.IdBairro,
            command.IdCidade);
        
        _bairroCidadeRepository.Remove(bairroCidade);
        
        return new GenericCommandResult(
            true,
            "Bairro saved",
            bairroCidade);
    }
}