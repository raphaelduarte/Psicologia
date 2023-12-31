namespace Psicologia.Domain.Entities.Endereco;

public class Bairro : Entity
{
    public Bairro(string bairro)
    {
        BairroName = bairro;
    }

    public string BairroName { get; private set; }
    public List<Logradouro> Logradouros { get; private set; }
    public List<Cidade> Cidades { get; private set; }
    public List<Estado> Estados { get; private set; }
    public List<Endereco> Enderecos { get; private set; }
}