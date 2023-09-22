using System.Linq.Expressions;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Queries.Endereco;

public static class NumeroEnderecoQueries
{
    public static Expression<Func<NumeroEndereco, bool>> GetAll(int numeroEndereco)
    {
        return x => x.Numero == numeroEndereco;
    }

    public static Expression<Func<NumeroEndereco, bool>> GetAll()
    {
        return x => x.Numero == x.Numero;
    }
}