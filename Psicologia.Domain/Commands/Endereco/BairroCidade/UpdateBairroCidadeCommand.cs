namespace Psicologia.Domain.Commands.Endereco.BairroCidade;

public class UpdateBairroCidadeCommand
{
    public UpdateBairroCidadeCommand()
    {
        
    }

    public UpdateBairroCidadeCommand(
        Guid idBairroCidade,
        Entities.Endereco.Bairro bairro,
        Entities.Endereco.Cidade cidade
    )
    {
        IdBairroCidade = idBairroCidade;
        IdBairro = bairro.Id;
        IdCidade = cidade.Id;
        BairroName = bairro.BairroName;
        CidadeName = cidade.CidadeName;
    }

    public Guid IdBairroCidade { get; private set; }
    public Guid IdBairro { get; private set; }
    public Guid IdCidade { get; private set; }
    public string BairroName { get; private set; }
    public string CidadeName { get; private set; }
}