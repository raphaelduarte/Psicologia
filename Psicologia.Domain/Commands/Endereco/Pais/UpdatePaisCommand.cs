namespace Psicologia.Domain.Commands.Endereco.Pais;

public class UpdatePaisCommand
{
    public UpdatePaisCommand()
    {
        
    }

    public UpdatePaisCommand(Guid idPais, string paisName)
    {
        IdPais = idPais;
        PaisName = paisName;
    }

    public Guid IdPais { get; private set; }
    public string PaisName { get; private set; }
}