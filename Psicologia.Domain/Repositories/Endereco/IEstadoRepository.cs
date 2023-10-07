using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Repositories.Endereco;

public interface IEstadoRepository
{
    void Create(Estado estadoName);
    void Update(Estado estadoName);
    void Remove(Estado estadoName);
    void UpdateEstadoName(string estadoName);
    Estado GetById(Guid id);
    Estado GetByName(string estadoName);
    IEnumerable<Estado> GetByNameLink(string estadoName);
    IEnumerable<Estado> GetAll();
}