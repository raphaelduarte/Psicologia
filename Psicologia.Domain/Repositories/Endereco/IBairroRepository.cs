using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Repositories.Endereco;

    public interface IBairroRepository
    {
        void Create(Bairro bairroName);
        void Update(Bairro bairroName);
        void Remove(Bairro bairroName);
        Bairro GetById(Guid id);
        Bairro GetByName(string bairroName);
        IEnumerable<Bairro> GetByNameLink(string bairroName);
        IEnumerable<Bairro> GetAll();
    }
