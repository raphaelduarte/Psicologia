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
        public List<Bairro> Bairros { get; private set; }
        public List<Estado> Estados { get; private set; }
        public ICollection<BairroCidade> BairroCidades { get; set; }
        public ICollection<CidadeEstado> CidadeEstados { get; set; }
    }
}
