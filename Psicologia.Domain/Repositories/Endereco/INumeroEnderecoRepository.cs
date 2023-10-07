using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Repositories.Endereco;

public interface INumeroEnderecoRepository
{
    void Create(NumeroEndereco numeroEndereco);
    void Update(NumeroEndereco numeroEndereco);
    void Remove(NumeroEndereco numeroEndereco);
    void UpdateNumero(int numeroEndereco);
    NumeroEndereco GetById(Guid id);
    IEnumerable<NumeroEndereco> GetAll();
}
