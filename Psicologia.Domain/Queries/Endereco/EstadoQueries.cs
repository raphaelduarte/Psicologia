using System.Linq.Expressions;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Queries.Endereco;

public static class EstadoQueries
{
    public static Expression<Func<Estado, bool>> GetAll(string estado)
    {
        return x => x.EstadoName == estado;
    }

    public static Expression<Func<Estado, bool>> GetAll()
    {
        return x => x.EstadoName == x.EstadoName;
    }
}