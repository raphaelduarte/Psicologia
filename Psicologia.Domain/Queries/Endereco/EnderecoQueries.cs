using System.Linq.Expressions;

namespace Psicologia.Domain.Queries.Endereco;

public static class EnderecoQueries
{
    public static Expression<Func<Entities.Endereco.Endereco, bool>> GetAll(
        Guid idLogradouro,
        Guid idNumero,
        Guid idBairroCidade,
        Guid idCidadeEstado,
        Guid idPais)
    {
        return x =>
            x.Logradouro == idLogradouro &&
            x.Numero == idNumero &&
            x.BairroCidade == idBairroCidade &&
            x.CidadeEstado == idCidadeEstado &&
            x.Pais == idPais;
    }
    
    public static Expression<Func<Entities.Endereco.Endereco, bool>> GetAll()
    {
        return x =>
            x.Logradouro == x.Logradouro &&
            x.Numero == x.Numero &&
            x.BairroCidade == x.BairroCidade &&
            x.CidadeEstado == x.CidadeEstado &&
            x.Pais == x.Pais;
    }
}