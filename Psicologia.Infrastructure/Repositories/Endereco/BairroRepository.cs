using Microsoft.EntityFrameworkCore;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Queries.Endereco;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Infrastructure.Contexts;

namespace Psicologia.Infrastructure.Repositories.Endereco;

public class BairroRepository : IBairroRepository
{
    private readonly DataContext _context;

    public BairroRepository(DataContext context)
    {
        _context = context;
    }
    public void Create(Bairro bairroName)
    {
        _context.Add(bairroName);
        _context.SaveChanges();
    }

    public void Update(Bairro bairroName)
    {
        _context.Entry(bairroName).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Remove(Bairro bairroName)
    {
        _context.Remove(bairroName);
        _context.SaveChanges();
    }

    public void UpdateBairroName(string bairroName)
    {
        _context.Entry(bairroName).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public Bairro GetById(Guid id)
    {
        _context.Bairros.FirstOrDefault(x => x.Id == id);
        return _context
            .Bairros
            .FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Bairro> GetAll()
    {
        return _context.Bairros
            .AsNoTracking()
            .Where(BairroQueries.GetAll())
            .OrderBy(x => x.BairroName);
    }

    public IEnumerable<Bairro> GetByNameLink(string bairro)
    {
        return _context.Bairros
            .AsNoTracking()
            .Where(BairroQueries.Get(bairro))
            .OrderBy(x => x.BairroName);
    }

    public Bairro GetByName(string bairro)
    {
        return _context.Bairros
            .FirstOrDefault(x => x.BairroName == bairro);
    }
}