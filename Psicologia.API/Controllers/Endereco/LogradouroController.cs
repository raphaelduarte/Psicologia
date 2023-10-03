using Microsoft.AspNetCore.Mvc;

using Psicologia.Domain.Entities.Endereco;

using Psicologia.Domain.Commands;
using Psicologia.Domain.Commands.Endereco;
using Psicologia.Domain.Commands.Endereco.Logradouro;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Handlers.Endereco;

using Psicologia.Domain.Repositories.Endereco;

namespace Psicologia.API.Controllers.Endereco;


[Route("v1/app/[controller]")]
[ApiController]
public class LogradouroController
{

    [Route("")]
    [HttpGet]
    public IEnumerable<Logradouro> GetAll(
        [FromServices] ILogradouroRepository repository
        )
    {
        return repository.GetAll();
    }

    
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
        [FromBody] CreateLogradouroCommand command,
        [FromServices] LogradouroHandler handler)
    {
        return (GenericCommandResult) handler.Handle(command);
    }

    [Route("{id:Guid}")]
    [HttpPut]
    public GenericCommandResult Update(
        [FromRoute] Guid id,
        [FromBody] UpdateLogradouroCommand command,
        [FromServices] LogradouroHandler handler)
    {
        return (GenericCommandResult) handler.Handle(command);
    }

    [Route("{id:Guid}")]
    [HttpDelete]
    public GenericCommandResult Remove(
        [FromRoute] Guid id,
        [FromBody] RemoveLogradouroCommand command,
        [FromServices] LogradouroHandler handler)
    {
        return (GenericCommandResult) handler.Handle(command);
    }
}