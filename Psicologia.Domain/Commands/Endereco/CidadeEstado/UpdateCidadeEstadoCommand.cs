namespace Psicologia.Domain.Commands.Endereco.CidadeEstado;

public class UpdateCidadeEstadoCommand
{
    public UpdateCidadeEstadoCommand()
    {
        
    }

    public UpdateCidadeEstadoCommand(Guid idCidade, Guid idEstado)
    {
        IdCidade = idCidade;
        IdEstado = idEstado;
    }

    public Guid IdCidade { get; private set; }
    public Guid IdEstado { get; private set; }
}