using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Repositories.Endereco;

public interface ILogradouroRepository
{
    void Create(Logradouro logradouroName);
    void Update(Logradouro logradouroName);
    void Remove(Logradouro logradouroName);
    Logradouro GetById(Guid id);
    IEnumerable<Logradouro> GetAll();
}