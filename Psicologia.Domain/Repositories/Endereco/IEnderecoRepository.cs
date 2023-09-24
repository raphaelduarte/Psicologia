﻿namespace Psicologia.Domain.Repositories.Endereco;

public interface IEnderecoRepository
{
    void Create(Entities.Endereco.Endereco endereco);
    void Update(Entities.Endereco.Endereco endereco);
    void Remove(Entities.Endereco.Endereco endereco);
    Entities.Endereco.Endereco GetById(
        Guid idLogradouro,
        Guid idNumero,
        Guid idBairroCidade,
        Guid idCidadeEstado,
        Guid idPais);
    IEnumerable<Entities.Endereco.Endereco> GetAll();
}