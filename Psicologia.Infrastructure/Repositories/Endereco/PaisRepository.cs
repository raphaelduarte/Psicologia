using Microsoft.EntityFrameworkCore;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Queries.Endereco;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Infrastructure.Contexts;

namespace Psicologia.Infrastructure.Repositories.Endereco;

public class PaisRepository : IPaisRepository
{
    private readonly DataContext _context;

    public PaisRepository(DataContext context)
    {
        _context = context;
    }
    
    public void Create(Pais paisName)
    {
        _context.Add(paisName);
        _context.SaveChanges();
    }

    public void Update(Pais paisName)
    {
        _context.Entry(paisName).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Remove(Pais paisName)
    {
        _context.Remove(paisName);
        _context.SaveChanges();
    }

    public Pais GetById(Guid id)
    {
        _context.Paises.FirstOrDefault(x => x.Id == id);
        return _context
            .Paises
            .FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Pais> GetAll()
    {
        return _context.Paises
            .AsNoTracking()
            .Where(PaisQueries.GetAll())
            .OrderBy(x => x.PaisName);
    }
}