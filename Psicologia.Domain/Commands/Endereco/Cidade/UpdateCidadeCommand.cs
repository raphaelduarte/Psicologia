using System.Data.Common;

namespace Psicologia.Domain.Commands.Endereco.Cidade;

public class UpdateCidadeCommand
{
    public UpdateCidadeCommand()
    {
        
    }

    public UpdateCidadeCommand(Guid id, string cidadeName)
    {
        Id = id;
        CidadeName = cidadeName;
    }

    public Guid Id { get; private set; }
    public string CidadeName { get; private set; }
}