namespace Psicologia.Domain.Commands.Endereco.BairroCidade;

public class RemoveBairroCidadeCommand
{
    public RemoveBairroCidadeCommand()
    {
        
    }

    public RemoveBairroCidadeCommand(Guid idBairro, string bairroName, Guid idCidade, string cidadeName)
    {
        IdBairro = idBairro;
        IdCidade = idCidade;
        BairroName = bairroName;
        CidadeName = cidadeName;
    }

    public Guid IdBairro { get; private set; }
    public Guid IdCidade { get; private set; }
    public string BairroName { get; private set; }
    public string CidadeName { get; private set; }
}