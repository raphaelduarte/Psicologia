using Microsoft.EntityFrameworkCore;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Queries.Endereco;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Infrastructure.Contexts;

namespace Psicologia.Infrastructure.Repositories.Endereco;

public class EstadoRepository : IEstadoRepository
{
    private readonly DataContext _context;

    public EstadoRepository(DataContext context)
    {
        _context = context;
    }
    public void Create(Estado estadoName)
    {
        _context.Add(estadoName);
        _context.SaveChanges();
    }

    public void Update(Estado estadoName)
    {
        _context.Entry(estadoName).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Remove(Estado estadoName)
    {
        _context.Remove(estadoName);
        _context.SaveChanges();
    }

    public Estado GetById(Guid id)
    {
        _context.Estados.FirstOrDefault(x => x.Id == id);
        return _context
            .Estados
            .FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Estado> GetAll()
    {
        return _context.Estados
            .AsNoTracking()
            .Where(EstadoQueries.GetAll())
            .OrderBy(x => x.EstadoName);
    }
}