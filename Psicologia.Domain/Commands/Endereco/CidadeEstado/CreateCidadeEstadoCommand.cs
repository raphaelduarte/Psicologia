namespace Psicologia.Domain.Commands.Endereco.CidadeEstado;
using Psicologia.Domain.Entities.Endereco;
public class CreateCidadeEstadoCommand
{
    public CreateCidadeEstadoCommand()
    {
        
    }

    public CreateCidadeEstadoCommand(
        Cidade cidade,
        Estado estado)
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