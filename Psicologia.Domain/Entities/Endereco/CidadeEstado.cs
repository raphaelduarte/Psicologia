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
            Guid idCidade,
            Guid idEstado)
        {
            IdCidade = idCidade;
            IdEstado = idEstado;
            
        }

        public Guid IdCidade { get; private set; }
        public Guid IdEstado { get; private set; }
        
    }
}
