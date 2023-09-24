using Microsoft.EntityFrameworkCore;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Queries.Endereco;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Infrastructure.Contexts;

namespace Psicologia.Infrastructure.Repositories.Endereco;

public class EnderecoRepository : IEnderecoRepository
{
    private readonly DataContext _context;

    public EnderecoRepository(DataContext context)
    {
        _context = context;
    }
    
    public void Create(Domain.Entities.Endereco.Endereco endereco)
    {
        _context.Add(endereco);
        _context.SaveChanges();
    }

    public void Update(Domain.Entities.Endereco.Endereco endereco)
    {
        _context.Entry(endereco).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Remove(Domain.Entities.Endereco.Endereco endereco)
    {
        _context.Remove(endereco);
        _context.SaveChanges();
    }

    public Domain.Entities.Endereco.Endereco GetById(Guid id)
    {
        _context.Enderecos.FirstOrDefault(x => x.Id == id);
        return _context
            .Enderecos
            .FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Domain.Entities.Endereco.Endereco> GetAll()
    {
        return _context.Enderecos
            .AsNoTracking()
            .Where(EnderecoQueries.GetAll())
            .OrderBy(x => x.CidadeEstado);
    }
}