using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Entities.Endereco
{
    public class Endereco : Entity
    {
        public Endereco(
            Logradouro logradouro,
            NumeroEndereco numero,
            ETipoResidencia eTipoResidencia,
            BairroCidade bairroCidade,
            CidadeEstado cidadeEstado,
            Pais pais)
        {
            Logradouro = logradouro;
            Numero = numero;
            ETipoResidencia = eTipoResidencia;
            BairroCidade = bairroCidade;
            CidadeEstado = cidadeEstado;
            Pais = pais;
        }

        public Logradouro Logradouro { get; private set; }
        public NumeroEndereco Numero { get; private set; }
        public BairroCidade BairroCidade { get; private set; }
        public CidadeEstado CidadeEstado { get; private set; }
        public Pais Pais { get; private set; }
        public ETipoResidencia ETipoResidencia { get; private set; }
    }
}
