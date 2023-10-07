namespace Psicologia.Domain.Services.Bairro;
using Psicologia.Domain.Entities.Endereco;

public class BairroService
{
    public bool BairroExiste(IEspecificacao<Bairro> especificacao, IEnumerable<Bairro> bairros)
    {
        return bairros.Any(bairro => especificacao.IsSatisfiedBy(bairro));
    }
}
