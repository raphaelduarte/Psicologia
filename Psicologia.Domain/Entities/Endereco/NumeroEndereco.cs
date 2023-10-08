using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psicologia.Domain.Entities.Endereco
{
    public class NumeroEndereco : Entity
    {
        public NumeroEndereco(int numeroEndereco)
        {
            Numero = numeroEndereco;
        }
        public int Numero { get; private set; }
        public List<Logradouro> Logradouros { get; private set; }
        public List<Cidade> Cidades { get; private set; }
        public List<Endereco> Enderecos { get; private set; }
        public List<Estado> Estados { get; private set; }
    }
}
