using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Queries.Endereco
{
    public static class LogradouroQueries
    {
        public static Expression<Func<Logradouro, bool>> GetAll(string logradouroName)
        {
            return x => x.LogradouroName == logradouroName;
        }

        public static Expression<Func<Logradouro, bool>> GetAll()
        {
            return x => x.LogradouroName == x.LogradouroName;
        }
    }

}
