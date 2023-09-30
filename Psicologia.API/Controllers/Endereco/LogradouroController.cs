using Microsoft.AspNetCore.Mvc;
using Psicologia.Domain.Entities.Endereco;
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
}