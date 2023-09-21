namespace Psicologia.Domain.Entities.Endereco;

public class Bairro : Entity
{
    public Bairro(string bairro)
    {
        BairroName = bairro;
    }

    public string BairroName { get; private set; }
}