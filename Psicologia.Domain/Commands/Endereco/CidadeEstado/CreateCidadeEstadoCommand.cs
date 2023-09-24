namespace Psicologia.Domain.Commands.Endereco.CidadeEstado;

public class CreateCidadeEstadoCommand
{
    public CreateCidadeEstadoCommand()
    {
        
    }

    public CreateCidadeEstadoCommand(
        Entities.Endereco.Cidade cidade,
        Entities.Endereco.Estado estado)
    {
        IdCidade = cidade.Id;
        IdEstado = estado.Id;
        Cidade = cidade.CidadeName;
        Estado = estado.EstadoName;

    }

    public Guid IdCidade { get; private set; }
    public Guid IdEstado { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }
}