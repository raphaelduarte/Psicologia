namespace Psicologia.Domain.Services;

public interface IEspecificacao<T>
{
    bool IsSatisfiedBy(T entity);
}