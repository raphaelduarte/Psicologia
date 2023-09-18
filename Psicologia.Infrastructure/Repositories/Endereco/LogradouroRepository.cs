using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Psicologia.Domain.Entities.Endereco;
using Psicologia.Domain.Queries.Endereco;
using Psicologia.Domain.Repositories.Endereco;
using Psicologia.Infrastructure.Contexts;

namespace Psicologia.Infrastructure.Repositories.Endereco
{
    public class LogradouroRepository : ILogradouroRepository
    {
        private readonly DataContext _context;

        public LogradouroRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Logradouro logradouro)
        {
            _context.Add(logradouro);
            _context.SaveChanges();
        }

        public void Update(Logradouro logradouro)
        {
            _context.Entry(logradouro).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Logradouro logradouro)
        {
            _context.Remove(logradouro);
            _context.SaveChanges();
        }

        public Logradouro GetById(Guid id)
        {
            _context.Logradouros.FirstOrDefault(x => x.Id == id);

            return _context
                .Logradouros
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Logradouro> GetAll()
        {
            return _context.Logradouros
                .AsNoTracking()
                .Where(LogradouroQueries.GetAll())
                .OrderBy(x => x.LogradouroName);
        }
    }
}
