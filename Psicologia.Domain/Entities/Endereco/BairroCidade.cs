using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psicologia.Domain.Entities.Endereco
{
    public class BairroCidade : Entity
    {
        public BairroCidade(Guid bairro, Guid cidade)
        {
            Bairro = bairro;
            Cidade = cidade;
        }
        public Guid Bairro { get; private set; }
        public Guid Cidade { get; private set; }
    }
}
