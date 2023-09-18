using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psicologia.Domain.Entities.Value_Objects
{
    public class Telefone : Entity
    {
        public Telefone(int ddd, long telefoneNumero)
        {
            Ddd = ddd;
            TelefoneNumero = telefoneNumero;
        }

        public int Ddd { get; private set; }
        public long TelefoneNumero { get; private set; }
    }
}
