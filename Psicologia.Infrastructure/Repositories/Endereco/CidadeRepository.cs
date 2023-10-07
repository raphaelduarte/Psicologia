using Microsoft.EntityFrameworkCore;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Queries.Endereco;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Infrastructure.Contexts;

namespace Psicologia.Infrastructure.Repositories.Endereco;

public class CidadeRepository : ICidadeRepository
{
    private readonly DataContext _context;

    public CidadeRepository(DataContext context)
    {
        _context = context;
    }
    public void Create(Cidade cidadeName)
    {
        _context.Add(cidadeName);
        _context.SaveChanges();
    }

    public void Update(Cidade cidadeName)
    {
        _context.Entry(cidadeName).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Remove(Cidade cidadeName)
    {
        _context.Remove(cidadeName);
        _context.SaveChanges();
    }

    public Cidade GetById(Guid id)
    {
        _context.Cidades.FirstOrDefault(x => x.Id == id);
        return _context
            .Cidades
            .FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Cidade> GetAll()
    {
        return _context.Cidades
            .AsNoTracking()
            .Where(CidadeQueries.GetAll())
            .OrderBy(x => x.CidadeName);
    }
    
    public IEnumerable<Cidade> GetByNameLink(string cidade)
    {
        return _context.Cidades
            .AsNoTracking()
            .Where(CidadeQueries.Get(cidade))
            .OrderBy(x => x.CidadeName);
    }
    
    public Cidade GetByName(string cidade)
    {
        return _context.Cidades
            .FirstOrDefault(x => x.CidadeName == cidade);
    }
}