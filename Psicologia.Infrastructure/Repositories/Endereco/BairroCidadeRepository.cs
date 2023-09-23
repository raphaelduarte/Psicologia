using Microsoft.EntityFrameworkCore;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Queries.Endereco;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Infrastructure.Contexts;

namespace Psicologia.Infrastructure.Repositories.Endereco;

public class BairroCidadeRepository : IBairroCidadeRepository
{
    private readonly DataContext _context;

    public BairroCidadeRepository(DataContext context)
    {
        _context = context;
    }
    public void Create(BairroCidade bairroCidade)
    {
        _context.Add(bairroCidade);
        _context.SaveChanges();
    }

    public void Update(BairroCidade bairroCidade)
    {
        _context.Entry(bairroCidade).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Remove(BairroCidade bairroCidade)
    {
        _context.Remove(bairroCidade);
        _context.SaveChanges();
    }

    public BairroCidade GetById(Guid idBairro, Guid idCidade)
    {
        _context.BairrosCidades.FirstOrDefault(x => 
            x.Bairro == idBairro &&
            x.Cidade == idCidade);
        return _context
            .BairrosCidades
            .FirstOrDefault(x => 
                x.Bairro == idBairro &&
                x.Cidade == idCidade);
    }

    public IEnumerable<BairroCidade> GetAll()
    {
        return _context.BairrosCidades
            .AsNoTracking()
            .Where(BairroCidadeQueries.GetAll())
            .OrderBy(x => x.Cidade);
    }
}