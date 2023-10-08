using Psicologia.Domain.Commands.Endereco.Bairro;
using Psicologia.Domain.Commands.Endereco.Cidade;
using Psicologia.Domain.Commands.Endereco.Estado;
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
        RemoveBairroCommand bairro,
        RemoveCidadeCommand cidade,
        RemoveEstadoCommand estado,
        ETipoResidencia eTipoResidencia,
        RemovePaisCommand pais)
    {
        IdEndereco = idEndereco;
        Logradouro = logradouro;
        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
        ETipoResidencia = eTipoResidencia;
        Pais = pais;
        
    }

    public Guid IdEndereco { get; private set; }
    public RemoveLogradouroCommand Logradouro { get; private set; }
    public RemoveNumeroEnderecoCommand Numero { get; private set; }
    public RemoveBairroCommand Bairro { get; private set; }
    public RemoveCidadeCommand Cidade { get; private set; }
    public RemoveEstadoCommand Estado { get; private set; }
    public RemovePaisCommand Pais { get; private set; }
    public ETipoResidencia ETipoResidencia { get; private set; }
}