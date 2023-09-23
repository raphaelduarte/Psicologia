using System.Linq.Expressions;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Queries.Endereco;

public static class CidadeEstadoQueries
{
    public static Expression<Func<CidadeEstado, bool>> GetAll(Guid idCidade, Guid idEstado)
    {
        return x => x.Cidade == idCidade && x.Estado == idEstado;
    }

    public static Expression<Func<CidadeEstado, bool>> GetAll()
    {
        return x => x.Cidade == x.Cidade &&
                    x.Estado == x.Estado;
    }
}