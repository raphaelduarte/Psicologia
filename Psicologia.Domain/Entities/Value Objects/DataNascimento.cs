using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psicologia.Domain.Entities.Value_Objects
{
    public class DataNascimento : Entity
    {
        public DataNascimento(DateTime nascimento)
        {
            Nascimento = nascimento;
        }
        public DateTime Nascimento { get; private set; }
    }
}
