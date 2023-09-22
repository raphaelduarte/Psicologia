namespace Psicologia.Domain.Commands.Endereco.CidadeEstado;

public class CreateCidadeEstadoCommand
{
    public CreateCidadeEstadoCommand()
    {
        
    }

    public CreateCidadeEstadoCommand(Guid idCidade, Guid idEstado)
    {
        IdCidade = idCidade;
        IdEstado = idEstado;
    }

    public Guid IdCidade { get; private set; }
    public Guid IdEstado { get; private set; }
}