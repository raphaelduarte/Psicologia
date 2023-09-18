using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psicologia.Domain.Entities.Endereco
{
    public class Cidade : Entity
    {
        public Cidade(string cidade)
        {
            CidadeName = cidade;
        }
        public string CidadeName { get; private set; }
    }
}
