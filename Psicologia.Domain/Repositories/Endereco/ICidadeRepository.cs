using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Repositories.Endereco;

public interface ICidadeRepository
{
    void Create(Cidade cidadeName);
    void Update(Cidade cidadeName);
    void Remove(Cidade cidadeName);
    Cidade GetById(Guid id);
    IEnumerable<Cidade> GetAll();
}