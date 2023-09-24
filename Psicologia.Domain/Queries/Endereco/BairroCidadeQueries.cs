using System.Diagnostics;
using System.Linq.Expressions;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Queries.Endereco;

public static class BairroCidadeQueries
{
    public static Expression<Func<BairroCidade, bool>> GetAll(Guid idBairroCidade)
    {
        return x => x.Id == idBairroCidade;
    }
    public static Expression<Func<BairroCidade, bool>> GetAll()
    {
        return x => x.Id == x.Id;
    }
}