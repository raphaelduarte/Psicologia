using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psicologia.Domain.Handlers.Endereco;

namespace Psicologia.Domain.Entities.Endereco
{
    public class Cidade : Entity
    {
        public Cidade(string cidade)
        {
            CidadeName = cidade;
        }
        public string CidadeName { get; private set; }
        public List<Bairro> Bairros { get; private set; }
        public List<Estado> Estados { get; private set; }
        public List<Endereco> Enderecos { get; private set; }
    }
}
