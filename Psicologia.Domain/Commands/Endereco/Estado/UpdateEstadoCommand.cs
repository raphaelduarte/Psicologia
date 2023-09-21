namespace Psicologia.Domain.Commands.Endereco.Estado;

public class UpdateEstadoCommand
{
    public UpdateEstadoCommand()
    {
        
    }

    public UpdateEstadoCommand(Guid idEstado, string estadoName)
    {
        IdEstado = idEstado;
        EstadoName = estadoName;
    }

    public Guid IdEstado { get; private set; }
    public string EstadoName { get; private set; }
}