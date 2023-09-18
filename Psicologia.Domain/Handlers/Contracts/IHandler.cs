using Psicologia.Domain.Commands.Contracts;

namespace Psicologia.Domain.Handlers.Contracts
{
    public interface IHandler<T>
    {
        ICommandResult Handle(T command);
    }
}

