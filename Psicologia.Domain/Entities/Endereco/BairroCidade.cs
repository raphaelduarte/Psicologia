using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psicologia.Domain.Entities.Endereco
{
    public class BairroCidade : Entity
    {
        public BairroCidade(
            Bairro bairro,
            Cidade cidade)
        {
            Bairro = bairro;
            Cidade = cidade;
        }
        public Bairro Bairro { get; private set; }
        public Cidade Cidade { get; private set; }
    }
}
