using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Repositories.Endereco;

    public interface IBairroCidadeRepository
    {
        void Create(BairroCidade bairroCidade);
        void Update(BairroCidade bairroCidade);
        void Remove(BairroCidade bairroCidade);
        BairroCidade GetById(Guid idBairroCidade);
        IEnumerable<BairroCidade> GetAll();
    }