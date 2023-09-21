namespace Psicologia.Domain.Commands.Endereco.BairroCidade;

public class CreateBairroCidadeCommand
{
    public CreateBairroCidadeCommand()
    {
        
    }

    public CreateBairroCidadeCommand(Guid idBairro, Guid idCidade)
    {
        IdBairro = idBairro;
        IdCidade = idCidade;
    }

    public Guid IdBairro { get; private set; }
    public Guid IdCidade { get; private set; }
}