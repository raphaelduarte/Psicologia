namespace Psicologia.Domain.Commands.Endereco.Pais;

public class CreatePaisCommand
{
    public CreatePaisCommand()
    {
        
    }

    public CreatePaisCommand(string paisName)
    {
        PaisName = paisName;
    }

    public string PaisName { get; private set; }
}