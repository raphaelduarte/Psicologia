namespace Psicologia.Domain.Commands.Endereco.CidadeEstado;

public class RemoveCidadeEstadoCommand
{
    public RemoveCidadeEstadoCommand()
    {
        
    }

    public RemoveCidadeEstadoCommand(Guid idCidade, Guid idEstado)
    {
        IdCidade = idCidade;
        IdEstado = idEstado;
    }

    public Guid IdCidade { get; private set; }
    public Guid IdEstado { get; private set; }
}