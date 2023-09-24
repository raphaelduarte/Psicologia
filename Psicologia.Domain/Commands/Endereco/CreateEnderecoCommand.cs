using System.Drawing;

namespace Psicologia.Domain.Commands.Endereco;

public class CreateEnderecoCommand
{
    public CreateEnderecoCommand()
    {
        
    }

    public CreateEnderecoCommand(
        Guid idLogradouro,
        Guid idNumero,
        Guid idBairroCidade,
        Guid idCidadeEstado,
        Guid idPais)
    {
        IdLogradouro = idLogradouro;
        IdNumero = idNumero;
        IdBairroCidade = idBairroCidade;
        IdCidadeEstado = idCidadeEstado;
        IdPais = idPais;
    }

    public Guid IdLogradouro { get; private set; }
    public Guid IdNumero { get; private set; }
    public Guid IdBairroCidade { get; private set; }
    public Guid IdCidadeEstado { get; private set; }
    public Guid IdPais { get; private set; }
}