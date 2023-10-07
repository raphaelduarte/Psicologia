using System.Linq.Expressions;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Queries.Endereco;

public static class BairroQueries
{
    public static Expression<Func<Bairro, bool>> Get(string bairro)
    {
        return x => x.BairroName == bairro;
    }

    public static Expression<Func<Bairro, bool>> GetAll()
    {
        return x => x.BairroName == x.BairroName;
    }
}