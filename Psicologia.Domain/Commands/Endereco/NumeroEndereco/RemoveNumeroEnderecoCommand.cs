namespace Psicologia.Domain.Commands.Endereco.NumeroEndereco;

public class RemoveNumeroEnderecoCommand
{
    public RemoveNumeroEnderecoCommand(){}

    public RemoveNumeroEnderecoCommand(Guid id, int numeroEndereco)
    {
        Id = id;
        NumeroEndereco = numeroEndereco;
    }

    public Guid Id { get; private set; }
    public int NumeroEndereco { get; private set; }
}