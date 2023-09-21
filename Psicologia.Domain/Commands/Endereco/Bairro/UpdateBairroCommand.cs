namespace Psicologia.Domain.Commands.Endereco.Bairro;

public class UpdateBairroCommand
{
    public UpdateBairroCommand()
    {
        
    }

    public UpdateBairroCommand(Guid id, string bairroName)
    {
        Id = id;
        BairroName = bairroName;
    }

    public Guid Id { get; private set; }
    public string BairroName { get; private set; }
}