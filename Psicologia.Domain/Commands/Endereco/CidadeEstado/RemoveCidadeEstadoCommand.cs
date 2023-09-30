namespace Psicologia.Domain.Commands.Endereco.CidadeEstado;
using Psicologia.Domain.Entities.Endereco;
public class RemoveCidadeEstadoCommand
{
    public RemoveCidadeEstadoCommand()
    {
        
    }

    public RemoveCidadeEstadoCommand(
        Guid idCidadeEstado,
        Cidade cidade,
        Estado estado)
    {
        IdCidadeEstado = idCidadeEstado;
        IdCidade = cidade.Id;
        IdEstado = estado.Id;
        Cidade = cidade.CidadeName;
        Estado = estado.EstadoName;
    }

    public Guid IdCidadeEstado { get; private set; }
    public Guid IdCidade { get; private set; }
    public Guid IdEstado { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }
}