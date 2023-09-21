namespace Psicologia.Domain.Commands.Endereco.Bairro;

public class CreateBairroCommand
{
    public CreateBairroCommand() { }

    public CreateBairroCommand(string bairroName )
    {
        BairroName = bairroName;
    }
    public string BairroName { get; private set; }
}