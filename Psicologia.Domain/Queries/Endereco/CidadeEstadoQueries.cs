using System.Linq.Expressions;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Queries.Endereco;

public static class CidadeEstadoQueries
{
    public static Expression<Func<CidadeEstado, bool>> GetAll(Guid idCidadeEstado)
    {
        return x => x.Id == idCidadeEstado;
    }

    public static Expression<Func<CidadeEstado, bool>> GetAll()
    {
        return x => x.Id == x.Id;
    }
}