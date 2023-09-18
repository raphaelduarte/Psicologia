using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psicologia.Domain.Entities.Value_Objects
{
    public class Email : Entity
    {
        public Email(string enderecoEmail)
        {
            EnderecoEmail = enderecoEmail;
        }
        public string EnderecoEmail { get; private set; }
    }
}
