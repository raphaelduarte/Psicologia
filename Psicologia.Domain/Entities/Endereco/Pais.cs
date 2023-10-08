using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psicologia.Domain.Entities.Endereco
{
    public class Pais : Entity
    {
        public Pais(string paisName)
        {
            PaisName = paisName;
        }
        public string PaisName { get; private set; }
        public List<Estado> Estados { get; private set; }
        public List<Endereco> Enderecos { get; private set; }
    }
}
