namespace Psicologia.Domain.Services.Bairro;
using Psicologia.Domain.Entities.Endereco;

public class BairroComNomeEspecificacao : IEspecificacao<Bairro>
{
    private readonly string _nomeBairro;

    public BairroComNomeEspecificacao(string nomeBairro)
    {
        _nomeBairro = nomeBairro;
    }

    public bool IsSatisfiedBy(Bairro bairro)
    {
        return bairro.BairroName == _nomeBairro;
    }
}
