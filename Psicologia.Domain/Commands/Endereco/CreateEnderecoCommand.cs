using System.Drawing;
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

public class CreateEnderecoCommand
{
    public CreateEnderecoCommand()
    {
        
    }

    public CreateEnderecoCommand(
        CreateNumeroEnderecoCommand numeroCommand,
        CreateLogradouroCommand logradouroCommand,
        CreateBairroCommand bairroCommand,
        CreateCidadeCommand cidadeCommand,
        CreateEstadoCommand estadoCommand,
        CreatePaisCommand paisCommand,
        ETipoResidencia eTipoResidencia)
    {
        Logradouro = logradouroCommand;
        Numero = numeroCommand;
        Bairro = bairroCommand;
        Cidade = cidadeCommand;
        Estado = estadoCommand;
        ETipoResidencia = eTipoResidencia;
        Pais = paisCommand;
        
    }
    public CreateLogradouroCommand Logradouro { get; private set; }
    public CreateNumeroEnderecoCommand Numero { get; private set; }
    public CreateBairroCommand Bairro { get; private set; }
    public CreateCidadeCommand Cidade { get; private set; }
    public CreateEstadoCommand Estado { get; private set; }
    public CreatePaisCommand Pais { get; private set; }
    public ETipoResidencia ETipoResidencia { get; private set; }
}