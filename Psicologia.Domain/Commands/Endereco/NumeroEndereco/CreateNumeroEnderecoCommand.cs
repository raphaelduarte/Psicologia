namespace Psicologia.Domain.Commands.Endereco.NumeroEndereco;

public class CreateNumeroEnderecoCommand
{
    public CreateNumeroEnderecoCommand() { }

    public CreateNumeroEnderecoCommand(int numeroEndereco)
    {
        NumeroEndereco = numeroEndereco;
    }
    
    public int NumeroEndereco { get; private set; }
}