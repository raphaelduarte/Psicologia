using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Psicologia.Domain.Entities.Endereco;
=======
using Psicologia.Domain.Commands;
using Psicologia.Domain.Commands.Endereco;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Handlers.Endereco;
>>>>>>> 2a61a32 (Criação dos controllers de Endereco e Logradouro)
using Psicologia.Domain.Repositories.Endereco;

namespace Psicologia.API.Controllers.Endereco;


[Route("v1/app/[controller]")]
[ApiController]
public class LogradouroController
{
<<<<<<< HEAD
    [Route("")]
=======
    [Route("get")]
>>>>>>> 2a61a32 (Criação dos controllers de Endereco e Logradouro)
    [HttpGet]

    public IEnumerable<Logradouro> GetAll(
        [FromServices] ILogradouroRepository repository
        )
    {
        return repository.GetAll();
    }
<<<<<<< HEAD
=======
    
    [Route("{id:Guid}")]
    [HttpGet]
    public Logradouro GetById(
        [FromRoute] Guid id,
        [FromServices] ILogradouroRepository repository)
    {
        return repository.GetById(id);
    }
    
    [Route("")]
    [HttpPost]
    public GenericCommandResult Create(
        [FromBody] CreateEnderecoCommand command,
        [FromServices] EnderecoHandler handler)
    {
        return (GenericCommandResult) handler.Handle(command);
    }

    [Route("")]
    [HttpPut]
    public GenericCommandResult Update(
        [FromBody] UpdateEnderecoCommand command,
        [FromServices] EnderecoHandler handler)
    {
        return (GenericCommandResult) handler.Handle(command);
    }

    [Route("")]
    [HttpDelete]
    public GenericCommandResult Remove(
        [FromBody] RemoveEnderecoCommand command,
        [FromServices] EnderecoHandler handler)
    {
        return (GenericCommandResult) handler.Handle(command);
    }
>>>>>>> 2a61a32 (Criação dos controllers de Endereco e Logradouro)
}