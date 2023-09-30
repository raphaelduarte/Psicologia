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
        Bairro = bairro;
        Cidade = cidade;
    }
    
    public Bairro Bairro { get; private set; }
    public Cidade Cidade { get; private set; }
}