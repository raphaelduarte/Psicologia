using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Repositories.Endereco;

public interface IEstadoRepository
{
    void Create(Estado estadoName);
    void Update(Estado estadoName);
    void Remove(Estado estadoName);
    Estado GetById(Guid id);
    IEnumerable<Estado> GetAll();
}