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
            Guid idBairro,
            Guid idCidade)
        {
            IdBairro = idBairro;
            IdCidade = idCidade;
        }

        public Guid IdBairro { get; private set; }
        public Guid IdCidade { get; private set; }
    }
}
