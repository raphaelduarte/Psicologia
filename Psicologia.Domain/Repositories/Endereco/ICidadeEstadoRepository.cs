using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Repositories.Endereco;

public interface ICidadeEstadoRepository
{
    void Create(CidadeEstado cidadeEstado);
    void Update(CidadeEstado cidadeEstado);
    void Remove(CidadeEstado cidadeEstado);
    CidadeEstado GetById(Guid idCidadeEstado);
    IEnumerable<CidadeEstado> GetAll();
}