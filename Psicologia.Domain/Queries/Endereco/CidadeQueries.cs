using System.Linq.Expressions;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Queries.Endereco;

    public static class CidadeQueries
    {
        public static Expression<Func<Cidade, bool>> Get(string cidade)
        {
            return x => x.CidadeName == cidade;
        }

        public static Expression<Func<Cidade, bool>> GetAll()
        {
            return x => x.CidadeName == x.CidadeName;
        }
    }


