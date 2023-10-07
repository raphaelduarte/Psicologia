using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Repositories.Endereco;

public interface IPaisRepository
{
    void Create(Pais paisName);
    void Update(Pais paisName);
    void Remove(Pais paisName);
    void UpdatePaisName(string paisName);
    Pais GetById(Guid id);
    IEnumerable<Pais> GetAll();
}