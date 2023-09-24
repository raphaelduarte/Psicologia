using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psicologia.Domain.Entities.Endereco
{
    public class CidadeEstado : Entity
    {
        public CidadeEstado(
            Cidade cidade,
            Estado estado)
        {
            Cidade = cidade;
            Estado = estado;
        }

        public Cidade Cidade { get; private set; }
        public Estado Estado { get; private set; }
    }
}
