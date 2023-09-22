using Microsoft.EntityFrameworkCore;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Queries.Endereco;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Infrastructure.Contexts;

namespace Psicologia.Infrastructure.Repositories.Endereco;

public class NumeroEnderecoRepository : INumeroEnderecoRepository
{
    private readonly DataContext _context;

    public NumeroEnderecoRepository(DataContext context)
    {
        _context = context;
    }

    public void Create(NumeroEndereco numeroEndereco)
    {
        _context.Add(numeroEndereco);
        _context.SaveChanges();
    }

    public void Update(NumeroEndereco numeroEndereco )
    {
        _context.Entry(numeroEndereco).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Remove(NumeroEndereco numeroEndereco)
    {
        _context.Remove(numeroEndereco);
        _context.SaveChanges();
    }

    public NumeroEndereco GetById(Guid id)
    {
        _context.NumeroEnderecos.FirstOrDefault(x => x.Id == id);

        return _context
            .NumeroEnderecos
            .FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<NumeroEndereco> GetAll()
    {
        return _context.NumeroEnderecos
            .AsNoTracking()
            .Where(NumeroEnderecoQueries.GetAll())
            .OrderBy(x => x.Numero);
    }
}
