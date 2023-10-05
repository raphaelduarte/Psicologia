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

    public CidadeEstado GetById(Guid idCidadeEstado)
    {
        _context.CidadesEstados.FirstOrDefault(x => 
            x.Id == idCidadeEstado);
        return _context
            .CidadesEstados
            .FirstOrDefault(x => 
                x.Id == idCidadeEstado);
    }

    public IEnumerable<CidadeEstado> GetAll()
    {
        return _context.CidadesEstados
            .AsNoTracking()
            .Where(CidadeEstadoQueries.GetAll())
            .OrderBy(x => x.Id);
    }
}