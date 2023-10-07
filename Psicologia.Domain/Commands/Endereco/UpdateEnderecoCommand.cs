using Psicologia.Domain.Commands.Endereco.Bairro;
using Psicologia.Domain.Commands.Endereco.BairroCidade;
using Psicologia.Domain.Commands.Endereco.Cidade;
using Psicologia.Domain.Commands.Endereco.CidadeEstado;
using Psicologia.Domain.Commands.Endereco.Estado;
using Psicologia.Domain.Commands.Endereco.Logradouro;
using Psicologia.Domain.Commands.Endereco.NumeroEndereco;
using Psicologia.Domain.Commands.Endereco.Pais;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Commands.Endereco;

public class UpdateEnderecoCommand
{
    public UpdateEnderecoCommand()
    {
        
    }

    public UpdateEnderecoCommand(
        Guid idEndereco,
        UpdateLogradouroCommand logradouro,
        UpdateNumeroEnderecoCommand numero,
        ETipoResidencia eTipoResidencia,
        UpdateBairroCommand bairro,
        UpdateCidadeCommand cidade,
        UpdateEstadoCommand estado,
    UpdateBairroCidadeCommand bairroCidade,
        UpdateCidadeEstadoCommand cidadeEstado,
        UpdatePaisCommand pais)
    {
        IdEndereco = idEndereco;
        Logradouro = logradouro;
        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
        ETipoResidencia = eTipoResidencia;
        BairroCidade = bairroCidade;
        CidadeEstado = cidadeEstado;
        Pais = pais;
        
    }

    public Guid IdEndereco { get; private set; }
    public UpdateLogradouroCommand Logradouro { get; private set; }
    public UpdateNumeroEnderecoCommand Numero { get; private set; }
    public UpdateBairroCommand Bairro { get; private set; }
    public UpdateCidadeCommand Cidade { get; private set; }
    public UpdateEstadoCommand Estado { get; private set; }
    public UpdateBairroCidadeCommand BairroCidade { get; private set; }
    public UpdateCidadeEstadoCommand CidadeEstado { get; private set; }
    public UpdatePaisCommand Pais { get; private set; }
    public ETipoResidencia ETipoResidencia { get; private set; }
}