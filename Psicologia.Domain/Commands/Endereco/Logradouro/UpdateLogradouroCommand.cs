using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psicologia.Domain.Commands.Endereco.Logradouro
{
    public class UpdateLogradouroCommand
    {
        public UpdateLogradouroCommand(){}

        public UpdateLogradouroCommand(Guid id, string logradouroName)
        {
            Id = id;
            LogradouroName = logradouroName;
        }

        public Guid Id { get; private set; }
        public string LogradouroName { get; private set; }
    }
}
