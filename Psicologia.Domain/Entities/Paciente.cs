using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Psicologia.Domain.Entities
{
    public class Paciente : Entity
    {
        public Paciente(string nome, string descricao, double preco)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double Preco { get; private set; }

    }
}
