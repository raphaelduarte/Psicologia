using Psicologia.Domain.Commands.Endereco.Logradouro;

namespace Psicologia.Domain.Commands.Endereco.NumeroEndereco;

public class UpdateNumeroEnderecoCommand
{
    public UpdateNumeroEnderecoCommand(){}

    public UpdateNumeroEnderecoCommand(Guid id, int numeroEndereco)
    {
        Id = id;
        NumeroEndereco = numeroEndereco;
    }

    public Guid Id { get; private set; }
    public int NumeroEndereco { get; private set; }
}