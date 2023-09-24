namespace Psicologia.Domain.Commands.Endereco.BairroCidade;

public class CreateBairroCidadeCommand
{
    public CreateBairroCidadeCommand()
    {

    }

    public CreateBairroCidadeCommand(
        Entities.Endereco.Bairro bairro,
        Entities.Endereco.Cidade cidade)
    {
        IdBairro = bairro.Id;
        IdCidade = cidade.Id;
        Bairro = bairro.BairroName;
        Cidade = cidade.CidadeName;
    }

    public Guid IdBairro { get; private set; }
    public Guid IdCidade { get; private set; }
    public string Bairro { get; private set; }
    public string Cidade { get; private set; }
}