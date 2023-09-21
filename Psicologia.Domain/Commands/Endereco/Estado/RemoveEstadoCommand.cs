namespace Psicologia.Domain.Commands.Endereco.Estado;

public class RemoveEstadoCommand
{
    public RemoveEstadoCommand()
    {
        
    }

    public RemoveEstadoCommand(Guid idEstado, string estadoName)
    {
        IdEstado = idEstado;
        EstadoName = estadoName;
    }

    public Guid IdEstado { get; private set; }
    public string EstadoName { get; private set; }
}