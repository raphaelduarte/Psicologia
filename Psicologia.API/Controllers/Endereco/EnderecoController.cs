using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Psicologia.Domain.Commands;
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
}