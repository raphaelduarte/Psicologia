using System.Linq.Expressions;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Queries.Endereco;

public static class PaisQueries
{
    public static Expression<Func<Pais, bool>> GetAll(string pais)
    {
        return x => x.PaisName == pais;
    }

    public static Expression<Func<Pais, bool>> GetAll()
    {
        return x => x.PaisName == x.PaisName;
    }
}