using System.Diagnostics;

namespace Psicologia.Domain.Commands.Endereco.Bairro;

public class RemoveBairroCommand
{
    public RemoveBairroCommand()
    {
        
    }

    public RemoveBairroCommand(Guid id, string bairroName)
    {
        Id = id;
        BairroName = bairroName;
    }

    public Guid Id { get; private set; }
    public string BairroName { get; private set; }
}