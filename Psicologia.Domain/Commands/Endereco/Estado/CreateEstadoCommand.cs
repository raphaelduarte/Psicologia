namespace Psicologia.Domain.Commands.Endereco.Estado;

public class CreateEstadoCommand
{
    public CreateEstadoCommand()
    {
        
    }

    public CreateEstadoCommand(string estadoName)
    {
        EstadoName = estadoName;
    }

    public string EstadoName { get; private set; }
}