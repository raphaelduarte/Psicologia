using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psicologia.Domain.Entities.Endereco
{
    public class CidadeEstado : Entity
    {
        public CidadeEstado(Guid cidade, Guid estado)
        {
            Cidade = cidade;
            Estado = estado;
        }
        public Guid Cidade { get; private set; }
        public Guid Estado { get; private set; }
    }
}
