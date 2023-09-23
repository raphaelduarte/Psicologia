using Microsoft.EntityFrameworkCore;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Queries.Endereco;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Infrastructure.Contexts;

namespace Psicologia.Infrastructure.Repositories.Endereco;

public class CidadeEstadoRepository : ICidadeEstadoRepository
{
    private readonly DataContext _context;

    public CidadeEstadoRepository(DataContext context)
    {
        _context = context;
    }
    
    public void Create(CidadeEstado cidadeEstado)
    {
        _context.Add(cidadeEstado);
        _context.SaveChanges();
    }

    public void Update(CidadeEstado cidadeEstado)
    {
        _context.Entry(cidadeEstado).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Remove(CidadeEstado cidadeEstado)
    {
        _context.Remove(cidadeEstado);
        _context.SaveChanges();
    }

    public CidadeEstado GetById(Guid idCidade, Guid idEstado)
    {
        _context.CidadesEstados.FirstOrDefault(x => 
            x.Cidade == idCidade &&
            x.Estado == idEstado);
        return _context
            .CidadesEstados
            .FirstOrDefault(x => 
                x.Cidade == idCidade &&
                x.Estado == idEstado);
    }

    public IEnumerable<CidadeEstado> GetAll()
    {
        return _context.CidadesEstados
            .AsNoTracking()
            .Where(CidadeEstadoQueries.GetAll())
            .OrderBy(x => x.Estado);
    }
}