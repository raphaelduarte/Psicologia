using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psicologia.Domain.Entities.Endereco
{
    public class Endereco : Entity
    {
        public Endereco(Guid logradouro, Guid numero, Guid bairroCidade, Guid cidadeEstado, Guid pais, Enum eTipoResidencia)
        {
            Logradouro = logradouro;
            Numero = numero;
            BairroCidade = bairroCidade;
            CidadeEstado = cidadeEstado;
            Pais = pais;
            ETipoResidencia = eTipoResidencia;
        }

        public Guid Logradouro { get; private set; }
        public Guid Numero { get; private set; }
        public Guid BairroCidade { get; private set; }
        public Guid CidadeEstado { get; private set; }
        public Guid Pais { get; private set; }
        public Enum ETipoResidencia { get; private set; }
    }
}
