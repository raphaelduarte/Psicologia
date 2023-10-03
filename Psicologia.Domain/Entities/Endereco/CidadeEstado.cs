﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psicologia.Domain.Entities.Endereco
{
    public class CidadeEstado : Entity
    {
        public CidadeEstado(
            Cidade cidade,
            Estado estado)
        {
            IdCidade = Cidade.Id;
            Cidade = cidade;
            IdEstado = Estado.Id;
            Estado = estado;
        }

        public Guid IdCidade { get; private set; }
        public Cidade Cidade { get; private set; }
        public Guid IdEstado { get; private set; }
        public Estado Estado { get; private set; }
    }
}
