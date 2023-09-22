using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psicologia.Domain.Entities.Value_Objects
{
    public class Usuario : Entity
    {
        public Usuario(
            Guid nomeCompletoId,
            Guid cpfId,
            Guid enderecoCompletoId,
            Guid telefoneId,
            Guid emailId,
            ETipoUsuario eTipodUsuario,
            Guid dataNascimentoId
        )
        {
            NomeCompletoId = nomeCompletoId;
            CpfId = cpfId;
            EnderecoCompletoId = enderecoCompletoId;
            TelefoneId = telefoneId;
            EmailId = emailId;
            ETipoUsuario = eTipodUsuario;
            DataNascimentoId = dataNascimentoId;

        }
        public Guid NomeCompletoId { get; private set; }
        public Guid CpfId { get; private set; }
        public Guid EnderecoCompletoId { get; private set; }
        public Guid TelefoneId { get; private set; }
        public Guid EmailId { get; private set; }
        public Guid DataNascimentoId { get; private set; }
        public ETipoUsuario ETipoUsuario { get; private set; }
    }
}
