using Psicologia.Domain.Handlers.Endereco;

namespace Psicologia.Domain.Commands.Endereco.BairroCidade;

using Psicologia.Domain.Entities.Endereco;

public class CreateBairroCidadeCommand
{
    public CreateBairroCidadeCommand()
    {

    }

    public CreateBairroCidadeCommand(
        Bairro bairro,
        Cidade cidade)
    {
        IdBairro = Bairro.Id;
        Bairro = bairro;
        IdCidade = Cidade.Id;
        Cidade = cidade;
    }

    public Guid IdBairro { get; private set; }
    public Bairro Bairro { get; private set; }
    public Guid IdCidade { get; private set; }
    public Cidade Cidade { get; private set; }
}