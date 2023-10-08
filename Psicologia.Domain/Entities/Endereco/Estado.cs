using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psicologia.Domain.Entities.Endereco
{
    public class Estado : Entity
    {
        public Estado(string estado)
        {
            EstadoName = estado;
        }
        public string EstadoName { get; private set; }
        public List<Cidade> Cidades { get; private set; }
        public List<Endereco> Enderecos { get; private set; }
    }
}
