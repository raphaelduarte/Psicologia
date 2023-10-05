using Psicologia.Domain.Commands;
using Psicologia.Domain.Commands.Contracts;
using Psicologia.Domain.Commands.Endereco.Cidade;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Handlers.Contracts;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Domain.Validator.Endereco.Cidade;

namespace Psicologia.Domain.Handlers.Endereco;

public class CidadeHandler :
    IHandler<CreateCidadeCommand>,
    IHandler<RemoveCidadeCommand>,
    IHandler<UpdateCidadeCommand>
{
    private readonly ICidadeRepository _cidadeRepository;

    public CidadeHandler(ICidadeRepository cidadeRepository)
    {
        _cidadeRepository = cidadeRepository;
    }
    public ICommandResult Handle(CreateCidadeCommand command)
    {
        var validator = new CreateCidadeValidator();
        var validation = validator.Validate(command);
        
        if (!validation.IsValid)
        {
            return new GenericCommandResult(false, "Ops, it is not valid", command);
        }

        var cidadeName = new Cidade(command.CidadeName);
        _cidadeRepository.Create(cidadeName);
        return new GenericCommandResult(true, "Cidade saved", cidadeName);
    }

    public ICommandResult Handle(RemoveCidadeCommand command)
    {
        var validator = new RemoveCidadeValidator();
        var validation = validator.Validate(command);
        
        if (!validation.IsValid)
        {
            return new GenericCommandResult(false, "Ops, it is not valid", command);
        }

        var cidade = _cidadeRepository.GetById(command.Id);
        _cidadeRepository.Remove(cidade);
        
        return new GenericCommandResult(true, "Cidade saved", cidade);

    }

    public ICommandResult Handle(UpdateCidadeCommand command)
    {
        var validator = new UpdateCidadeValidator();
        var validation = validator.Validate(command);
        
        if (!validation.IsValid)
        {
            return new GenericCommandResult(false, "Ops, it is not valid", command);
        }

        var cidade = _cidadeRepository.GetById(command.Id);
        _cidadeRepository.Update(cidade);
        
        return new GenericCommandResult(true, "Cidade saved", cidade);
    }
}