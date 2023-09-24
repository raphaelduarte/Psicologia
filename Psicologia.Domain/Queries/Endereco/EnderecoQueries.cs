using System.Linq.Expressions;
using Psicologia.Domain.Repositories.Endereco;

namespace Psicologia.Domain.Queries.Endereco;

public static class EnderecoQueries
{
    public static Expression<Func<Entities.Endereco.Endereco, bool>> GetAll(
        Guid id)
    {
        return x => x.Id == id;
    }
    
    public static Expression<Func<Entities.Endereco.Endereco, bool>> GetAll()
    {
        return x => x.Id == x.Id;
    }
}