using Psicologia.Domain.Commands.Endereco.BairroCidade;
using Psicologia.Domain.Commands.Endereco.CidadeEstado;
using Psicologia.Domain.Commands.Endereco.Logradouro;
using Psicologia.Domain.Commands.Endereco.NumeroEndereco;
using Psicologia.Domain.Commands.Endereco.Pais;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Commands.Endereco;

public class RemoveEnderecoCommand
{
    public RemoveEnderecoCommand()
    {
        
    }

    public RemoveEnderecoCommand(
        Guid idEndereco,
        RemoveLogradouroCommand logradouro,
        RemoveNumeroEnderecoCommand numero,
        ETipoResidencia eTipoResidencia,
        RemoveBairroCidadeCommand bairroCidade,
        RemoveCidadeEstadoCommand cidadeEstado,
        RemovePaisCommand pais)
    {
        IdEndereco = idEndereco;
        Logradouro = logradouro;
        Numero = numero;
        ETipoResidencia = eTipoResidencia;
        BairroCidade = bairroCidade;
        CidadeEstado = cidadeEstado;
        Pais = pais;
        
    }

    public Guid IdEndereco { get; private set; }
    public RemoveLogradouroCommand Logradouro { get; private set; }
    public RemoveNumeroEnderecoCommand Numero { get; private set; }
    public RemoveBairroCidadeCommand BairroCidade { get; private set; }
    public RemoveCidadeEstadoCommand CidadeEstado { get; private set; }
    public RemovePaisCommand Pais { get; private set; }
    public ETipoResidencia ETipoResidencia { get; private set; }
}