using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Psicologia.Domain.Commands;
using Psicologia.Domain.Commands.Endereco;
using Psicologia.Domain.Handlers.Endereco;
using Psicologia.Domain.Repositories.Endereco;

namespace Psicologia.API.Controllers.Endereco;

[Route("v1/api[controller]")]
[ApiController]
public class EnderecoController : ControllerBase
{
    [Route("")]
    [HttpGet]
    public IEnumerable<Domain.Entities.Endereco.Endereco> GetAll(
        [FromServices] IEnderecoRepository repository
    )
    {
        return repository.GetAll();
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

}