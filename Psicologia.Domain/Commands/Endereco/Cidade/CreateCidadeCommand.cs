namespace Psicologia.Domain.Commands.Endereco.Cidade;

public class CreateCidadeCommand
{
    public CreateCidadeCommand()
    {
        
    }

    public CreateCidadeCommand(string cidadeName)
    {
        CidadeName = cidadeName;
    }
    public string CidadeName { get; private set; }
}