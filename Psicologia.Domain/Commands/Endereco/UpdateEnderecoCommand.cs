using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Commands.Endereco;

public class UpdateEnderecoCommand
{
    public UpdateEnderecoCommand()
    {
        
    }

    public UpdateEnderecoCommand(
        Entities.Endereco.Logradouro logradouro,
        Entities.Endereco.NumeroEndereco numero,
        ETipoResidencia eTipoResidencia,
        Entities.Endereco.BairroCidade bairroCidade,
        Entities.Endereco.CidadeEstado cidadeEstado,
        Entities.Endereco.Pais pais)
    {
        Logradouro = logradouro.Id;
        Numero = numero.Id;
        ETipoResidencia = eTipoResidencia;
        BairroCidade = bairroCidade.Id;
        CidadeEstado = cidadeEstado.Id;
        Pais = pais.Id;
        
    }

    public Guid Logradouro { get; private set; }
    public Guid Numero { get; private set; }
    public Guid BairroCidade { get; private set; }
    public Guid CidadeEstado { get; private set; }
    public Guid Pais { get; private set; }
    public ETipoResidencia ETipoResidencia { get; private set; }
}