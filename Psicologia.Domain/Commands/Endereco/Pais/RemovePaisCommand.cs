namespace Psicologia.Domain.Commands.Endereco.Pais;

public class RemovePaisCommand
{
    public RemovePaisCommand()
    {
        
    }

    public RemovePaisCommand(Guid idPais, string paisName)
    {
        IdPais = idPais;
        PaisName = paisName;
    }

    public Guid IdPais { get; private set; }
    public string PaisName { get; private set; }
}