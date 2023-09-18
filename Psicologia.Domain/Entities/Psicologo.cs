using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psicologia.Domain.Entities
{
    public class Psicologo : Entity
    {
        public Psicologo(Guid usuarioId)
        {
            UsuarioId = usuarioId;
        }
        Guid UsuarioId { get; set; }
    }
}
