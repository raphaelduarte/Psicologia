namespace Psicologia.Domain.Commands.Endereco.Cidade;

public class RemoveCidadeCommand
{
    public RemoveCidadeCommand()
    {
        
    }

    public RemoveCidadeCommand(Guid id, string cidadeName)
    {
        Id = id;
        CidadeName = cidadeName;
    }

    public Guid Id { get; private set; }
    public string CidadeName { get; private set; }
}