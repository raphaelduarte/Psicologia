using System.Diagnostics;
using System.Linq.Expressions;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Queries.Endereco;

public static class BairroCidadeQueries
{
    public static Expression<Func<BairroCidade, bool>> GetAll(Guid idBairro, Guid idCidade)
    {
        return x => x.Bairro == idBairro && x.Cidade == idCidade;
    }
    public static Expression<Func<BairroCidade, bool>> GetAll()
    {
        return x => x.Bairro == x.Bairro && x.Cidade == x.Cidade;
    }
}